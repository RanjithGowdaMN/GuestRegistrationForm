$ErrorActionPreference = 'Stop'
$output = Join-Path $PSScriptRoot 'bin'
New-Item -ItemType Directory -Force $output | Out-Null
Copy-Item -LiteralPath (Join-Path (Split-Path $PSScriptRoot -Parent) 'Dependencies/Chip/SmartCardManager.dll') -Destination $output -Force
& "$env:WINDIR/Microsoft.NET/Framework/v4.0.30319/csc.exe" /nologo /target:exe /platform:x86 "/out:$output\VisitorDesk.Chip.exe" /r:System.Web.Extensions.dll "/r:$output\SmartCardManager.dll" "$PSScriptRoot\ChipBridge.cs"
if ($LASTEXITCODE -ne 0) { throw 'Chip bridge build failed.' }
$library = Join-Path (Split-Path $PSScriptRoot -Parent) 'Lib'
if (Test-Path -LiteralPath "$library/ReadQID.Library.dll") {
    foreach ($name in @('ReadQID.Library.dll','SCBase.dll')) { Copy-Item -LiteralPath "$library/$name" -Destination $output -Force }
    & "$env:WINDIR/Microsoft.NET/Framework/v4.0.30319/csc.exe" /nologo /target:exe /platform:x86 "/out:$output\VisitorDesk.Qid.exe" /r:System.Web.Extensions.dll "/r:$output\SmartCardManager.dll" "/r:$output\ReadQID.Library.dll" "/r:$output\SCBase.dll" "$PSScriptRoot\QidBridge.cs"
    if ($LASTEXITCODE -ne 0) { throw 'QID bridge build failed. Check the public namespace supplied with qIDReading.txt.' }
}
