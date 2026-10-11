$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$sdk = Join-Path $root 'Dependencies/Scanner'
$output = Join-Path $PSScriptRoot 'bin'
$compiler = Join-Path $env:WINDIR 'Microsoft.NET/Framework/v4.0.30319/csc.exe'
if (!(Test-Path -LiteralPath $compiler)) { throw 'The scanner helper requires the Windows .NET Framework 4.x compiler/runtime.' }
foreach ($dll in @('AxInterop.FiScnLib.dll', 'Interop.FiScnLib.dll')) {
    $dependency = Join-Path $sdk $dll
    if (!(Test-Path -LiteralPath $dependency)) { throw "Scanner dependency missing: $dependency. Restore the supplied scanner interop files into Dependencies/Scanner." }
}
New-Item -ItemType Directory -Force $output | Out-Null
foreach ($dll in @('AxInterop.FiScnLib.dll', 'Interop.FiScnLib.dll')) {
    Copy-Item -LiteralPath (Join-Path $sdk $dll) -Destination $output -Force
}
& "$env:WINDIR/Microsoft.NET/Framework/v4.0.30319/csc.exe" /nologo /target:exe /platform:x86 "/out:$output\VisitorDesk.Scanner.exe" /r:System.Windows.Forms.dll /r:System.Drawing.dll /r:System.Web.Extensions.dll "/r:$output\AxInterop.FiScnLib.dll" "/r:$output\Interop.FiScnLib.dll" "$PSScriptRoot\ScannerBridge.cs"
if ($LASTEXITCODE -ne 0) { throw 'Scanner bridge build failed.' }

