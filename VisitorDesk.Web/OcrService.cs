using System.Diagnostics;
using System.Text.Json;
public sealed class OcrService(string root, StoragePaths paths)
{
    readonly SemaphoreSlim gate = new(1, 1);
    public async Task<IResult> Extract(HttpRequest request, CancellationToken cancellation)
    {
        if (!request.HasFormContentType) return Results.BadRequest(new { error = "Upload an image." });
        var form = await request.ReadFormAsync(cancellation);
        var file = form.Files.GetFile("document");
        if (file is null || file.Length is 0 or > 8 * 1024 * 1024 || file.ContentType is not ("image/jpeg" or "image/png")) return Results.BadRequest(new { error = "Choose a PNG or JPEG under 8 MB." });
        if (!await gate.WaitAsync(0, cancellation)) return Results.Json(new { error = "OCR is busy. Please retry shortly." }, statusCode: 409);
        var temp = Path.Combine(paths.Temp, Guid.NewGuid() + ".image");
        try {
            var executable = Path.GetFullPath(Path.Combine(root, "VisitorDesk.Ocr", "bin", "VisitorDesk.Ocr.exe"));
            if (!File.Exists(executable)) return Results.Json(new { error = "Build local OCR with VisitorDesk.Ocr/build.ps1." }, statusCode: 503);
            await using (var stream = File.Create(temp)) await file.CopyToAsync(stream, cancellation);
            var start = new ProcessStartInfo(executable) { UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true, RedirectStandardError = true };
            start.ArgumentList.Add(temp);start.ArgumentList.Add(Path.Combine(Path.GetDirectoryName(executable)!, "tessdata"));
            using var process = Process.Start(start)!;
            var output = process.StandardOutput.ReadToEndAsync();var error = process.StandardError.ReadToEndAsync();
            using var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellation);timeout.CancelAfter(TimeSpan.FromSeconds(45));
            try { await process.WaitForExitAsync(timeout.Token); }
            catch (OperationCanceledException) { if (!process.HasExited) process.Kill(true);await process.WaitForExitAsync();await output;await error;return Results.Json(new { error = "OCR timed out or was cancelled." }, statusCode: 503); }
            await error;
            if (process.ExitCode != 0) return Results.Json(new { error = "OCR could not read the image. Try a clearer scan." }, statusCode: 503);
            var result = JsonSerializer.Deserialize<JsonElement>(await output);
            var text = result.GetProperty("text").GetString() ?? "";
            var confidence = result.TryGetProperty("confidence", out var score) ? Math.Clamp(score.GetDouble(), 0, 1) : 0;
            return Results.Ok(new { text, confidence, fields = IdentityTextProcessor.Extract(text), message = "Review all extracted details against the original document." });
        } catch (Exception ex) when (ex is System.ComponentModel.Win32Exception or JsonException) { return Results.Json(new { error = "Local OCR could not start. Check its runtime and language data." }, statusCode: 503); }
        finally { try { if (File.Exists(temp)) File.Delete(temp); } finally { gate.Release(); } }
    }
}
