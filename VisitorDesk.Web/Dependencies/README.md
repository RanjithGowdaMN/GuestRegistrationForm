# Local dependencies for VisitorDesk.Web

All bundled hardware/OCR build inputs are inside this project. Build scripts resolve these paths relative to their own location; they do not depend on the legacy projects or the separate VISMA repository.

| Feature | Files inside VisitorDesk.Web | Setup |
| --- | --- | --- |
| Canon camera | `Dependencies/Canon/EDSDK.dll`, `EdsImage.dll`, `EDSDKLib.dll` | `VisitorDesk.Camera/build.ps1`; also built by Windows web builds |
| fi-800R scanner | `Dependencies/Scanner/AxInterop.FiScnLib.dll`, `Interop.FiScnLib.dll` | `VisitorDesk.Scanner/build.ps1`; also built by Windows web builds |
| Local OCR | `Dependencies/Ocr/Tesseract.dll`, `x86/leptonica-1.82.0.dll`, `x86/tesseract50.dll`, `tessdata/eng.traineddata` | `VisitorDesk.Ocr/build.ps1` |
| Card reader | `Dependencies/Chip/SmartCardManager.dll`; private `Lib/ReadQID.Library.dll` and `Lib/SCBase.dll` | `VisitorDesk.Chip/build.ps1` |
| PDF generation | `documents/requirements.txt`, `documents/generate.py`; installed packages in `.venv-documents` | `documents/setup.ps1` |
| PDF templates | `VisitorData/BaseDocument/Visitor.pdf`, `Contractor.pdf` | Preserve the provided templates during local handover |
| Web packages | PackageReference entries in `VisitorDesk.Web.csproj` | `dotnet restore` |

Run `./setup.ps1` from the project folder for all helpers and PDF dependencies. Windows device drivers, native Fujitsu Scanner Control SDK, .NET runtimes, Python and SQL Server are machine prerequisites; copying DLLs does not install those components. Recreate the Python environment on each computer.

## Visibility and Git

The project explicitly lists local dependencies and helper source as **None** items so Visual Studio can show them without compiling helper source into the web assembly. Reload the project if Solution Explorer has not refreshed.

Binary dependency folders, private Lib DLLs, generated bin/obj files, virtual environments and VisitorData remain ignored by Git. This inventory is versionable; it does not make the licensed/private binaries public. A filesystem handover must include the required authorised local files. A Git clone alone is not a complete installed application.

If Git shows only `?? VisitorDesk.Web/`, use `git status --short --untracked-files=all -- VisitorDesk.Web` from the parent repository to see individual source files. The separate `VISMA` repository will not show changes made to `VisitorDesk.Web`.
