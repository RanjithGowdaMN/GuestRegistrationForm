$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$source = Join-Path $root 'Dependencies/Ocr'
$output = Join-Path $PSScriptRoot 'bin'
New-Item -ItemType Directory -Force "$output/x86", "$output/tessdata" | Out-Null
Copy-Item -LiteralPath "$source/Tesseract.dll" -Destination $output -Force
Copy-Item "$source/x86/*.dll" -Destination "$output/x86" -Force
Copy-Item -LiteralPath "$source/tessdata/eng.traineddata" -Destination "$output/tessdata" -Force
& "$env:WINDIR/Microsoft.NET/Framework/v4.0.30319/csc.exe" /nologo /target:exe /platform:x86 "/out:$output\VisitorDesk.Ocr.exe" /r:System.Web.Extensions.dll "/r:$output\Tesseract.dll" "$PSScriptRoot\OcrBridge.cs"
if ($LASTEXITCODE -ne 0) { throw 'OCR bridge build failed.' }
