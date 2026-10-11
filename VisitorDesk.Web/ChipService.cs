using System.Diagnostics;
using System.Text.Json;

public sealed class ChipService(string root)
{
    private readonly SemaphoreSlim gate = new(1, 1);
    public async Task<IResult> Execute(bool read, CancellationToken cancellation)
    {
        if (!await gate.WaitAsync(0, cancellation)) return Results.Json(new { error = "Reader check is already running." }, statusCode: 409);
        try
        {
            var executable = Path.GetFullPath(Path.Combine(root, "VisitorDesk.Chip", "bin", read ? "VisitorDesk.Qid.exe" : "VisitorDesk.Chip.exe"));
            if (!File.Exists(executable)) return Results.Json(new { error = "Build the card-reader bridge with VisitorDesk.Chip/build.ps1." }, statusCode: 503);
            using var process = Process.Start(new ProcessStartInfo(executable) { UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true, RedirectStandardError = true })!;
            var output = process.StandardOutput.ReadToEndAsync();
            var errors = process.StandardError.ReadToEndAsync();
            using var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellation);
            timeout.CancelAfter(TimeSpan.FromSeconds(read ? 45 : 15));
            try { await process.WaitForExitAsync(timeout.Token); }
            catch (OperationCanceledException) {
                if (!process.HasExited) process.Kill(true);
                await process.WaitForExitAsync(CancellationToken.None);
                await output; await errors;
                return Results.Json(new { error = "Reader check timed out or was cancelled." }, statusCode: 503);
            }
            await errors;
            var result = JsonSerializer.Deserialize<JsonElement>(await output);
            return Results.Json(result, statusCode: process.ExitCode == 0 ? 200 : 503);
        }
        catch (Exception ex) when (ex is System.ComponentModel.Win32Exception or JsonException)
        { return Results.Json(new { error = "The card-reader bridge could not run. Check its SDK and driver installation." }, statusCode: 503); }
        finally { gate.Release(); }
    }
}
