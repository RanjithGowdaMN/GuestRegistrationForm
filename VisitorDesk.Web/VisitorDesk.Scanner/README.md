# fi-800R bridge

## Another laptop: helper missing / build.ps1 not found

The old message "Scanner bridge is not built. Run VisitorDesk.Scanner/build.ps1" means the application could not find **VisitorDesk.Scanner.exe**; it does not test whether the script exists or whether drivers are installed.

For a source-folder installation, open PowerShell in the folder containing `VisitorDesk.Web.csproj` and run:

```powershell
powershell.exe -NoProfile -ExecutionPolicy Bypass -File .\VisitorDesk.Scanner\build.ps1
```

If the script itself is missing, copy `VisitorDesk.Scanner/build.ps1` and `ScannerBridge.cs` from the updated project, and ensure both interop DLLs are in `Dependencies/Scanner`. Do not use the all-device setup script just to repair the scanner.

The updated Windows web build automatically builds the helper and copies the executable and its two interop DLLs into build and publish output at `VisitorDesk.Scanner/bin`. Transfer the complete output folder. A published installation does not need the build script. The service also checks beside the web executable when the working/content directory differs. Scanner drivers and the native Scanner Control SDK still need installation on the receiving laptop.

Verification of this packaging fix: web build, publish inclusion of all three helper files, and source/output path regression checks. The receiving laptop has not been inspected or tested.

## Runtime

Build from the VisitorDesk.Web folder with `./VisitorDesk.Scanner/build.ps1` in PowerShell. This copies the existing `AxInterop.FiScnLib.dll` and `Interop.FiScnLib.dll` from `Dependencies/Scanner` into an ignored output directory and compiles an x86 .NET Framework helper using the installed Windows compiler. Keep the Fujitsu Scanner Control SDK and PaperStream IP TWAIN driver installed; copying the interop DLLs alone does not register the native ActiveX component.

The web server starts one helper per operation. The helper owns an STA WinForms message loop, selects only a source containing `800R`, opens it, and closes it on completion. `status` opens the scanner without feeding a page. `scan <private-output-directory>` captures one simplex RGB 300 dpi page, returns a PNG, and closes the device. Scan mode constants and event contracts come from the existing FI800Scan SDK sample.

Run the web server in the logged-in Windows desktop session, not as a service. The helper's host window is invisible; the driver can still show its own error dialog. The server serializes scanner operations, applies timeouts, and kills the helper on request cancellation. Cancellation may require reinserting the document. Temporary scan files are removed from the server-generated private job directory after completion, errors or cancellation.

The browser captures front and back separately. Flip/reinsert the ID before scanning the other side. Both sides are required before registration can proceed. Crop and rotation edits are local until saved; reset restores the original for that side while the form is open. Saving the visitor persists the two edited images alongside photo/signature in the SQL registration record. Reset and undo history are not persisted. OCR sends the edited front and back to the local Tesseract helper; dependencies are still required.

Verified on this machine: helper builds and the SDK opens `PaperStream IP fi-800R`. Physical document feed, orientation, and scan results must be checked with an actual card.
