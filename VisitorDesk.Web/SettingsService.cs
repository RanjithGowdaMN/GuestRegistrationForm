using System.Text.Json;
public sealed class SettingsService(StoragePaths paths)
{
    private readonly SemaphoreSlim gate = new(1,1);
    public async Task<IResult> Read()
    {
        await gate.WaitAsync();
        try { return Results.Ok(File.Exists(paths.ConfigurationFile) ? JsonSerializer.Deserialize<Dictionary<string,string[]>>(await File.ReadAllTextAsync(paths.ConfigurationFile)) : new()); }
        finally { gate.Release(); }
    }
    public async Task<IResult> Save(Dictionary<string,string[]> data)
    {
        if (data.Count > 100 || data.Any(p => string.IsNullOrWhiteSpace(p.Key) || p.Key.Length > 100 || p.Value is null || p.Value.Length > 1000 || p.Value.Any(v => v is null || v.Length > 200))) return Results.BadRequest(new {error="Settings contain invalid or excessively long entries."});
        if (!data.TryGetValue("DepartmentNames",out var departments) || departments.Any(string.IsNullOrWhiteSpace)) return Results.BadRequest(new {error="A department list is required."});
        var cleaned = data.ToDictionary(p=>p.Key,p=>p.Value.Select(v=>v.Trim()).Where(v=>v.Length>0).Distinct(StringComparer.OrdinalIgnoreCase).ToArray());
        await gate.WaitAsync();
        try {
            await File.WriteAllTextAsync(paths.ConfigurationFile+".tmp",JsonSerializer.Serialize(cleaned,new JsonSerializerOptions{WriteIndented=true}));
            File.Move(paths.ConfigurationFile+".tmp",paths.ConfigurationFile,true);
            return Results.Ok(cleaned);
        } finally { gate.Release(); }
    }
}
