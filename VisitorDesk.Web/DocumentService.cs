using System.Diagnostics;
using System.Text.Json;

public sealed class DocumentService(string root, IConfiguration configuration, StoragePaths paths)
{
    public static readonly HashSet<string> FieldNames = new("template identityType cardType cardNumber title area duration visitDate departmentManager productionManager securityController address city state zip email homePhone securityNo felony passportNumber passportPlace passportIssued passportExpiry emergencyPhone alias residence".Split(' '));
    public static bool ValidFields(Dictionary<string, string>? fields) => fields is not null && fields.Count <= FieldNames.Count && fields.All(p => FieldNames.Contains(p.Key) && p.Value is not null && p.Value.Length <= 200);
    private readonly SemaphoreSlim gate = new(1, 1);
    public async Task<IResult> Generate(JsonElement input, CancellationToken cancellation)
    {
        if (input.ValueKind != JsonValueKind.Object) return Results.BadRequest(new { error = "Document details are required." });
        foreach (var property in input.EnumerateObject())
            if (property.Value.ValueKind != JsonValueKind.String || property.Value.GetString()!.Length > (property.Name is "photo" or "signature" or "documentFront" or "documentBack" ? 7_000_000 : 500))
                return Results.BadRequest(new { error = "Invalid document field." });
        string Field(string name) => input.TryGetProperty(name, out var value) ? value.GetString() ?? "" : "";
        if (Field("template") is not ("visitor" or "contractor" or "card")) return Results.BadRequest(new { error = "Select a supported template." });
        if (string.IsNullOrWhiteSpace(Field("name")) || string.IsNullOrWhiteSpace(Field("idNumber"))) return Results.BadRequest(new { error = "Name and identity number are required." });
        if (!await gate.WaitAsync(0, cancellation)) return Results.Json(new { error = "Another PDF is being prepared. Please retry shortly." }, statusCode: 409);
        var directory = Path.Combine(paths.Temp, "documents", Guid.NewGuid().ToString("N"));
        var output = Path.Combine(directory, "document.pdf");
        try
        {
            Directory.CreateDirectory(directory);
            var localPython = Path.Combine(root, ".venv-documents", "Scripts", "python.exe");
            var start = new ProcessStartInfo(configuration["Documents:Python"] ?? (File.Exists(localPython) ? localPython : "python")) {
                UseShellExecute = false, CreateNoWindow = true, RedirectStandardInput = true,
                RedirectStandardOutput = true, RedirectStandardError = true
            };
            start.Environment["PYTHONUTF8"] = "1";
            start.ArgumentList.Add(Path.Combine(root, "documents", "generate.py"));
            start.ArgumentList.Add(paths.Templates);
            start.ArgumentList.Add(output);
            using var process = Process.Start(start)!;
            var stdout = process.StandardOutput.ReadToEndAsync();
            var stderr = process.StandardError.ReadToEndAsync();
            using var deadline = CancellationTokenSource.CreateLinkedTokenSource(cancellation);
            deadline.CancelAfter(TimeSpan.FromSeconds(30));
            try {
                await process.StandardInput.WriteAsync(input.GetRawText().AsMemory(), deadline.Token);
                process.StandardInput.Close();
                await process.WaitForExitAsync(deadline.Token);
                await stdout; await stderr;
            } catch (OperationCanceledException) {
                if (!process.HasExited) process.Kill(true);
                await process.WaitForExitAsync(CancellationToken.None);
                await stdout; await stderr;
                return Results.Json(new { error = "Document generation cancelled or timed out." }, statusCode: 503);
            }
            if (process.ExitCode == 2) {
                var result = JsonSerializer.Deserialize<JsonElement>(await stdout);
                return Results.Json(result, statusCode: 400);
            }
            if (process.ExitCode != 0 || !File.Exists(output)) return Results.Json(new { error = "Document generation failed. Check the PDF templates and Python document dependencies." }, statusCode: 503);
            return Results.File(await File.ReadAllBytesAsync(output, cancellation), "application/pdf", Field("template") + ".pdf");
        }
        catch (System.ComponentModel.Win32Exception) { return Results.Json(new { error = "Configure Documents:Python and install the document requirements." }, statusCode: 503); }
        finally { try { if (Directory.Exists(directory)) Directory.Delete(directory, true); } finally { gate.Release(); } }
    }
}
