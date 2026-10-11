public sealed class StoragePaths
{
    public string Root { get; }
    public string Records => Path.Combine(Root, "Records");
    public string Temp => Path.Combine(Root, "Temp");
    public string Templates => Path.Combine(Root, "BaseDocument");
    public string ConfigurationFile => Path.Combine(Root, "Data", "DataConfiguration.json");
    public StoragePaths(string contentRoot)
    {
        Root = Path.GetFullPath(Path.Combine(contentRoot, "VisitorData"));
        foreach (var name in new[] { "Records", "Temp", "BaseDocument", "Data", "ScannedID", "Photos", "GeneratedDocument" }) Directory.CreateDirectory(Path.Combine(Root, name));
        var legacy = Path.Combine(contentRoot, "App_Data");
        if (Directory.Exists(legacy)) foreach (var file in Directory.GetFiles(legacy, "*.json")) {
            var target = Path.Combine(Records, Path.GetFileName(file));
            if (!File.Exists(target)) File.Copy(file, target);
        }
    }
}
