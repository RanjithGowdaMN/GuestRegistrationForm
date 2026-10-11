$ErrorActionPreference = 'Stop'
Push-Location $PSScriptRoot
try {
    & ./VisitorDesk.Camera/build.ps1
    & ./VisitorDesk.Scanner/build.ps1
    & ./VisitorDesk.Ocr/build.ps1
    & ./VisitorDesk.Chip/build.ps1
    & ./documents/setup.ps1
    dotnet build ./VisitorDesk.Web.csproj
    if ($LASTEXITCODE -ne 0) { throw 'Web build failed.' }
} finally { Pop-Location }
