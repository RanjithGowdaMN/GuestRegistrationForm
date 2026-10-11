using System.Text.Json;
using Microsoft.AspNetCore.Http;

var root = Path.GetFullPath(args.Length > 0 ? args[0] : ".");
var temporary = Path.Combine(root, "VisitorData", "Temp", "camera-tests-" + Guid.NewGuid().ToString("N"));
try
{
    var paths = new StoragePaths(temporary);
    var missing = await new CameraService(temporary, paths).Execute(false, CancellationToken.None);
    if (((IStatusCodeHttpResult)missing).StatusCode != 503) throw new Exception("Missing helper must return 503.");
    var service = new CameraService(root, paths);
    var status = await service.Execute(false, CancellationToken.None);
    if (((IStatusCodeHttpResult)status).StatusCode != 200) throw new Exception("SDK readiness check failed: " + JsonSerializer.Serialize(((IValueHttpResult)status).Value));
    var body = (JsonElement)((IValueHttpResult)status).Value!;
    if (!body.GetProperty("sdkLoaded").GetBoolean()) throw new Exception("SDK did not load.");
    if (!body.GetProperty("ready").GetBoolean())
    {
        var capture = await service.Execute(true, CancellationToken.None);
        if (((IStatusCodeHttpResult)capture).StatusCode != 503) throw new Exception("Disconnected capture must return 503.");
        var failure = (JsonElement)((IValueHttpResult)capture).Value!;
        if (!failure.GetProperty("error").GetString()!.Contains("No Canon camera")) throw new Exception("Missing disconnected guidance.");
        if (Directory.Exists(Path.Combine(paths.Temp, "camera")) && Directory.GetDirectories(Path.Combine(paths.Temp, "camera")).Length != 0) throw new Exception("Capture job was not cleaned up.");
        var retry = await service.Execute(false, CancellationToken.None);
        if (((IStatusCodeHttpResult)retry).StatusCode != 200) throw new Exception("Camera gate was not released after failure.");
        Console.WriteLine("Passed: missing helper, SDK loading, disconnected capture, temporary cleanup, retry after failure.");
    }
    else Console.WriteLine("Passed: missing helper and connected status. Shutter test skipped to avoid taking an unattended photo.");
}
finally { if (Directory.Exists(temporary)) Directory.Delete(temporary, true); }
