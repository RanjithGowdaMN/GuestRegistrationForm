using System.Diagnostics;
using System.Text.Json;

public sealed class ScannerService(string root, StoragePaths paths)
{
    readonly SemaphoreSlim gate = new(1, 1);
    internal static string? FindHelper(string contentRoot, string applicationDirectory)
    {
        foreach (var location in new[] { contentRoot, applicationDirectory }.Distinct(StringComparer.OrdinalIgnoreCase))
        {
            var candidate = Path.GetFullPath(Path.Combine(location, "VisitorDesk.Scanner", "bin", "VisitorDesk.Scanner.exe"));
            if (File.Exists(candidate)) return candidate;
        }
        return null;
    }

    public async Task<IResult> Execute(bool scan, CancellationToken disconnected)
    {
        if (!await gate.WaitAsync(0, disconnected)) return Results.Json(new { error = "Scanner is busy. Wait for the current scan to finish." }, statusCode: 409);
        var directory = Path.Combine(paths.Temp, "scans", Guid.NewGuid().ToString("N"));
        try
        {
            var exe = FindHelper(root, AppContext.BaseDirectory);
            if (exe is null) return Results.Json(new { error = "Scanner helper is missing from this app installation. Rebuild VisitorDesk.Web on Windows or copy the complete published output. Expected VisitorDesk.Scanner/bin/VisitorDesk.Scanner.exe under " + Path.GetFullPath(root) + " or " + AppContext.BaseDirectory + "." }, statusCode: 503);
            Directory.CreateDirectory(directory);
            var start = new ProcessStartInfo(exe) { UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true, RedirectStandardError = true, WorkingDirectory = Path.GetDirectoryName(exe)! };
            start.ArgumentList.Add(scan ? "scan" : "status");
            if (scan) start.ArgumentList.Add(directory);
            using var process = Process.Start(start)!;
            var output = process.StandardOutput.ReadToEndAsync();
            var error = process.StandardError.ReadToEndAsync();
            using var timeout = CancellationTokenSource.CreateLinkedTokenSource(disconnected);
            timeout.CancelAfter(TimeSpan.FromSeconds(scan ? 90 : 20));
            try { await process.WaitForExitAsync(timeout.Token); }
            catch (OperationCanceledException) { if (!process.HasExited) process.Kill(true); await process.WaitForExitAsync(); return Results.Json(new { error = "Scan cancelled or timed out. Check the feeder before retrying." }, statusCode: 408); }
            await error;
            var result = JsonSerializer.Deserialize<JsonElement>(await output);
            return Results.Json(result, statusCode: result.TryGetProperty("error", out _) ? 503 : 200);
        }
        catch (Exception ex) when (ex is System.ComponentModel.Win32Exception or JsonException)
        { return Results.Json(new { error = "Unable to start the scanner SDK. Check the installed Fujitsu SDK and PaperStream driver." }, statusCode: 503); }
        finally { try { if (Directory.Exists(directory)) Directory.Delete(directory, true); } finally { gate.Release(); } }
    }
}
