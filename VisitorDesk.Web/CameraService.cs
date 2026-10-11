using System.Diagnostics;
using System.Text.Json;

public sealed class CameraService(string root, StoragePaths paths)
{
    readonly SemaphoreSlim gate = new(1, 1);
    internal static string? FindHelper(string contentRoot, string applicationDirectory)
    {
        foreach (var directory in new[] { contentRoot, applicationDirectory }.Distinct(StringComparer.OrdinalIgnoreCase))
        {
            var path = Path.GetFullPath(Path.Combine(directory, "VisitorDesk.Camera", "bin", "VisitorDesk.Camera.exe"));
            if (File.Exists(path)) return path;
        }
        return null;
    }
    public async Task<IResult> Execute(bool capture, CancellationToken cancellation)
    {
        if (!await gate.WaitAsync(0, cancellation)) return Results.Json(new { error = "Canon camera is busy. Wait for the current request." }, statusCode: 409);
        var directory = Path.Combine(paths.Temp, "camera", Guid.NewGuid().ToString("N"));
        try
        {
            var executable = FindHelper(root, AppContext.BaseDirectory);
            if (executable is null) return Results.Json(new { error = "Canon helper is missing. Rebuild VisitorDesk.Web on Windows with Dependencies/Canon present, or copy the complete published app." }, statusCode: 503);
            var start = new ProcessStartInfo(executable) { UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true, RedirectStandardError = true, WorkingDirectory = Path.GetDirectoryName(executable)! };
            start.ArgumentList.Add(capture ? "capture" : "status");
            if (capture) { Directory.CreateDirectory(directory); start.ArgumentList.Add(directory); }
            using var process = Process.Start(start)!;
            var output = process.StandardOutput.ReadToEndAsync();
            var errors = process.StandardError.ReadToEndAsync();
            using var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellation);
            timeout.CancelAfter(TimeSpan.FromSeconds(capture ? 50 : 20));
            try { await process.WaitForExitAsync(timeout.Token); }
            catch (OperationCanceledException)
            {
                if (!process.HasExited) process.Kill(true);
                await process.WaitForExitAsync(CancellationToken.None);
                await Task.WhenAll(output, errors);
                return Results.Json(new { error = "Canon request cancelled or timed out. Check USB, camera power and focus before retrying." }, statusCode: 408);
            }
            await errors;
            var result = JsonSerializer.Deserialize<JsonElement>(await output);
            return Results.Json(result, statusCode: process.ExitCode == 0 && !result.TryGetProperty("error", out _) ? 200 : 503);
        }
        catch (Exception ex) when (ex is System.ComponentModel.Win32Exception or JsonException or IOException)
        { return Results.Json(new { error = "Canon helper could not run. Rebuild it and check the x86 SDK dependencies." }, statusCode: 503); }
        finally
        {
            try { if (Directory.Exists(directory)) Directory.Delete(directory, true); }
            catch (IOException) { /* A locked temporary file must not keep the camera gate locked. */ }
            catch (UnauthorizedAccessException) { }
            finally { gate.Release(); }
        }
    }
}
