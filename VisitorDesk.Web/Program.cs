using System.Text.Json;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5080");
builder.WebHost.ConfigureKestrel(o => o.Limits.MaxRequestBodySize = 16 * 1024 * 1024);
var app = builder.Build();
var paths = new StoragePaths(app.Environment.ContentRootPath);
var dataPath = paths.Records;
Directory.CreateDirectory(dataPath);
var gate = new SemaphoreSlim(1, 1);
var repository = new VisitRepository(paths, builder.Configuration);
await repository.Initialize();
app.Use(async (ctx, next) => {
    if (ctx.Request.Host.Host is not ("localhost" or "127.0.0.1" or "::1")) { ctx.Response.StatusCode = 403; return; }
    if (ctx.Request.Headers.TryGetValue("Origin", out var origin) && origin != $"{ctx.Request.Scheme}://{ctx.Request.Host}") { ctx.Response.StatusCode = 403; return; }
    ctx.Response.Headers["Cache-Control"] = "no-store";
    ctx.Response.Headers["X-Content-Type-Options"] = "nosniff";
    await next();
});
app.UseDefaultFiles();
app.UseStaticFiles();
var scannerService = new ScannerService(app.Environment.ContentRootPath, paths);
var documentService = new DocumentService(app.Environment.ContentRootPath, builder.Configuration, paths);
var chipService = new ChipService(app.Environment.ContentRootPath);
var cameraService = new CameraService(app.Environment.ContentRootPath, paths);
app.MapGet("/api/camera/status", (CancellationToken ct) => cameraService.Execute(false, ct));
app.MapPost("/api/camera/capture", (CancellationToken ct) => cameraService.Execute(true, ct));
app.MapGet("/api/chip/status", (CancellationToken ct) => chipService.Execute(false, ct));
app.MapPost("/api/chip/read", (CancellationToken ct) => chipService.Execute(true, ct));
var settingsService = new SettingsService(paths);
app.MapGet("/api/settings", () => settingsService.Read());
app.MapPut("/api/settings", (Dictionary<string,string[]> settings) => settingsService.Save(settings));
app.MapPost("/api/documents", (JsonElement input, CancellationToken ct) => documentService.Generate(input, ct));
app.MapGet("/api/scanner/status", (CancellationToken ct) => scannerService.Execute(false, ct));
app.MapPost("/api/scanner/scan", (CancellationToken ct) => scannerService.Execute(true, ct));
app.MapGet("/api/status", () => Results.Ok(new { camera = "Canon EDSDK: /api/camera/status; webcam also available", scanner = "Use /api/scanner/status for live fi-800R status", chip = "Local QID bridge; use /api/chip/status", ocr = "Local Tesseract with existing Qatar ID and MRZ processing", storage = paths.Root }));
app.MapGet("/api/visits", async () => {
    await gate.WaitAsync();
    try { return Results.Ok((await repository.List()).Select(v => new { v.Id, v.Name, v.Company, v.Host, v.Purpose, v.CheckIn, v.CheckOut })); }
    finally { gate.Release(); }
});
app.MapGet("/api/visits/{id:guid}", async (Guid id) => {
    await gate.WaitAsync();
    try {
        var visit = await repository.Get(id);
        return visit is not null ? Results.Ok(visit) : Results.NotFound();
    } finally { gate.Release(); }
});
app.MapPut("/api/visits/{id:guid}/documents", async (Guid id, Dictionary<string, string> fields) => {
    if (!DocumentService.ValidFields(fields)) return Results.BadRequest(new { error = "Invalid document fields." });
    await gate.WaitAsync();
    try {
        var visit = await repository.Get(id);
        if (visit is null) return Results.NotFound();
        visit.DocumentFields = fields;
        await repository.Save(visit);
        return Results.Ok();
    } finally { gate.Release(); }
});
app.MapPost("/api/visits", async (Visit v) => {
    if (!DocumentService.ValidFields(v.DocumentFields)) return Results.BadRequest(new { error = "Invalid document fields." });
    if (new[] { v.Name, v.IdNumber, v.Host, v.Purpose }.Any(string.IsNullOrWhiteSpace)) return Results.BadRequest(new { error = "Name, ID number, host and purpose are required." });
    if (new[] { v.Name, v.IdNumber, v.Host, v.Purpose, v.Company, v.Nationality, v.Phone }.Any(s => s is null || s.Length > 200)) return Results.BadRequest(new { error = "Fields must be text with 200 characters or fewer." });
    bool ValidImage(string s) { try { var prefix = s.StartsWith("data:image/png;base64,") ? "data:image/png;base64," : "data:image/jpeg;base64,"; if (!s.StartsWith(prefix)) return false; var b = Convert.FromBase64String(s[prefix.Length..]); return b.Length is > 100 and < 5000000 && ((b[0] == 137 && b[1] == 80) || (b[0] == 255 && b[1] == 216)); } catch { return false; } }
    if (!v.Consent || !ValidImage(v.Signature) || !ValidImage(v.Photo)) return Results.BadRequest(new { error = "A photo, signature and confirmation are required." });
    if (!ValidImage(v.DocumentFront) || !ValidImage(v.DocumentBack)) return Results.BadRequest(new { error = "Both front and back document images are required." });
    v.Id = Guid.NewGuid(); v.CheckIn = DateTimeOffset.UtcNow; v.CheckOut = null;
    await gate.WaitAsync();
    try { await repository.Save(v, true); }
    finally { gate.Release(); }
    return Results.Ok(new { v.Id, v.CheckIn });
});
app.MapPost("/api/visits/{id:guid}/checkout", async (Guid id) => {
    await gate.WaitAsync();
    try { var v = await repository.Get(id); if (v is null) return Results.NotFound(); v.CheckOut ??= DateTimeOffset.UtcNow; await repository.Save(v); return Results.Ok(); }
    finally { gate.Release(); }
});
var ocrService = new OcrService(app.Environment.ContentRootPath, paths);
app.MapPost("/api/extract", (HttpRequest request, CancellationToken ct) => ocrService.Extract(request, ct));
app.Run();

public class Visit {
    public string Department { get; set; } = "";
    public Dictionary<string, string> DocumentFields { get; set; } = new();
    public string DocumentFront { get; set; } = "";
    public string DocumentBack { get; set; } = "";
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string IdNumber { get; set; } = "";
    public string Nationality { get; set; } = "";
    public string Dob { get; set; } = "";
    public string Expiry { get; set; } = "";
    public string Company { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Host { get; set; } = "";
    public string Purpose { get; set; } = "";
    public string Photo { get; set; } = "";
    public string Signature { get; set; } = "";
    public bool Consent { get; set; }
    public DateTimeOffset CheckIn { get; set; }
    public DateTimeOffset? CheckOut { get; set; }
}
