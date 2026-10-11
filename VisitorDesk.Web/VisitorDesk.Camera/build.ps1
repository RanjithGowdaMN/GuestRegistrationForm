param([string]$SdkDirectory)
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$sdk = Join-Path $root 'Dependencies/Canon'
$output = Join-Path $PSScriptRoot 'bin'
$dlls = @('EDSDK.dll', 'EdsImage.dll', 'EDSDKLib.dll')
function Assert-X86([string]$path) {
    $bytes = [IO.File]::ReadAllBytes($path)
    if ($bytes.Length -lt 64) { throw "Invalid DLL: $path" }
    $offset = [BitConverter]::ToInt32($bytes, 60)
    if ($offset -lt 0 -or $offset + 6 -gt $bytes.Length -or [BitConverter]::ToUInt32($bytes, $offset) -ne 0x4550 -or [BitConverter]::ToUInt16($bytes, $offset + 4) -ne 0x14c) { throw "Expected an x86 Windows DLL: $path" }
}
if ($SdkDirectory) {
    foreach ($dll in $dlls) { Assert-X86 (Join-Path $SdkDirectory $dll) }
    New-Item -ItemType Directory -Force $sdk | Out-Null
    foreach ($dll in $dlls) { Copy-Item -LiteralPath (Join-Path $SdkDirectory $dll) -Destination $sdk -Force }
}
foreach ($dll in $dlls) {
    $path = Join-Path $sdk $dll
    if (!(Test-Path -LiteralPath $path)) { throw "Missing $dll. Supply your licensed x86 runtime and EDSDKLib wrapper with ./VisitorDesk.Camera/build.ps1 -SdkDirectory <folder>. See VisitorDesk.Camera/README.md." }
    Assert-X86 $path
}
New-Item -ItemType Directory -Force $output | Out-Null
foreach ($dll in $dlls) { Copy-Item -LiteralPath (Join-Path $sdk $dll) -Destination $output -Force }
& "$env:WINDIR/Microsoft.NET/Framework/v4.0.30319/csc.exe" /nologo /target:exe /platform:x86 "/out:$output\VisitorDesk.Camera.exe" /r:System.Core.dll /r:System.Drawing.dll /r:System.Windows.Forms.dll /r:System.Web.Extensions.dll "/r:$output\EDSDKLib.dll" "$PSScriptRoot\CameraBridge.cs"
if ($LASTEXITCODE -ne 0) { throw 'Canon camera bridge build failed.' }
Write-Host 'Canon bridge built. Check readiness with ./VisitorDesk.Camera/bin/VisitorDesk.Camera.exe status'
