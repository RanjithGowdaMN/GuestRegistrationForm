var temporary = Path.Combine(Path.GetTempPath(), "scanner-path-tests-" + Guid.NewGuid().ToString("N"));
try
{
    var source = Path.Combine(temporary, "source");
    var output = Path.Combine(temporary, "output");
    var unrelated = Path.Combine(temporary, "unrelated-working-directory");
    if (ScannerService.FindHelper(source, output) is not null) throw new Exception("Missing helper must not resolve.");
    var outputHelper = Path.Combine(output, "VisitorDesk.Scanner", "bin", "VisitorDesk.Scanner.exe");
    Directory.CreateDirectory(Path.GetDirectoryName(outputHelper)!);
    File.WriteAllText(outputHelper, "path fixture; never executed");
    if (ScannerService.FindHelper(unrelated, output) != outputHelper) throw new Exception("Launching from another folder must find the packaged helper.");
    var sourceHelper = Path.Combine(source, "VisitorDesk.Scanner", "bin", "VisitorDesk.Scanner.exe");
    Directory.CreateDirectory(Path.GetDirectoryName(sourceHelper)!);
    File.WriteAllText(sourceHelper, "path fixture; never executed");
    if (ScannerService.FindHelper(source, output) != sourceHelper) throw new Exception("Source-folder launches must use their own helper.");
    Console.WriteLine("Passed: missing installation, packaged helper with unrelated working directory, source-folder helper.");
}
finally { if (Directory.Exists(temporary)) Directory.Delete(temporary, true); }
