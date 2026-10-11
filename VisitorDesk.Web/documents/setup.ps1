$ErrorActionPreference = 'Stop'
$projectRoot = Split-Path $PSScriptRoot -Parent
$environmentPath = Join-Path $projectRoot '.venv-documents'
python -m venv $environmentPath
if ($LASTEXITCODE -ne 0) { throw 'Unable to create the document Python environment.' }
& "$environmentPath/Scripts/python.exe" -m pip install -r "$PSScriptRoot/requirements.txt"
if ($LASTEXITCODE -ne 0) { throw 'Unable to install document dependencies.' }
