# Single-folder project

Copy the complete VisitorDesk.Web folder. All source, helper build inputs, helper outputs, templates and working files are inside this folder. Shared dependencies were copied so legacy projects remain intact. The sibling VisitorData folder is a retained old copy; the app now uses VisitorDesk.Web/VisitorData exclusively.

## Contents

- wwwroot: browser UI.
- TextProcessing: parser source.
- VisitorDesk.Scanner, VisitorDesk.Ocr, VisitorDesk.Chip: helper source and builds.
- Dependencies: scanner interop DLLs, Tesseract wrapper/native x86 DLLs, English model and SmartCardManager DLL.
- Lib: locally supplied private QID DLLs.
- documents and database: PDF generation and database setup.
- VisitorData: templates, configuration, working files and encrypted database connection.
- VisitorDesk.Tests: parser regression checks.
- MigrationBackup: preserved pre-consolidation bundled data; not needed to run.

## New computer

Install Windows, .NET 8 SDK, .NET Framework 4.x with its Windows compiler, Python with pip, and SQL Server (or access to an existing SQL Server). Scanning requires Fujitsu Scanner Control SDK and PaperStream IP TWAIN driver. QID requires its reader driver and authorized ReadQID.Library.dll and SCBase.dll in Lib. These private libraries are not for redistribution; obtain authorized copies for the recipient.

From this folder in PowerShell, run ./setup.ps1.
For a new database run: sqlcmd -S localhost -U sa -C -b -i ./database/deploy.sql
Then run ./database/configure.ps1 and dotnet run --project ./VisitorDesk.Web.csproj.
Open http://localhost:5080. Run in the logged-in desktop session for scanner access.

SQL registrations and images are stored in SQL Server, not in this folder. Back up/restore GuestData separately to transfer existing registrations. VisitorData/Data/database.secret only works for its original Windows account/machine; configure the connection again on the destination, or set ConnectionStrings__GuestData. The configuration script accepts -Server, -Database and -User.

Recreate .venv-documents with setup.ps1 after relocating; Python virtual environments are not portable. You may omit .vs, bin/obj outputs, logs, VisitorData/Temp and MigrationBackup. Keep Dependencies, authorized Lib files, templates and configuration. VisitorData contains personal records/files; include it only for the intended data handover.

Dependencies and local/private data are ignored by Git. A Git clone alone does not contain all installed binary dependencies; a filesystem copy must include them. NuGet restores Microsoft.Data.SqlClient 7.1.1 and System.Security.Cryptography.ProtectedData 8.0.0. PDF setup installs documents/requirements.txt. OCR uses the bundled native helper.

## Verification

dotnet build ./VisitorDesk.Web.csproj
dotnet run --project ./VisitorDesk.Tests/VisitorDesk.Tests.csproj

This is a source-folder handover. Plain dotnet publish output is not a complete hardware/data deployment package.

## Canon camera preparation

`setup.ps1` builds the Canon helper. Preserve the three locally staged x86 DLLs in `Dependencies/Canon` when handing over this folder under their applicable licences; they are Git-ignored. See [EOS 4000D setup](VisitorDesk.Camera/README.md).
