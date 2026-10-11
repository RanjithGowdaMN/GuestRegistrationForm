# Canon EOS 4000D preparation

The Photo page in `VisitorDesk.Web` now has **Check Canon camera** and **Capture with Canon**. Capture triggers the shutter through EDSDK and uses the downloaded JPEG as the visitor portrait. Frame using the camera viewfinder; streaming Canon live view is not implemented. Webcam and upload remain available.

## Prepared on this computer

- Copied the existing local `CanonEDSDK/bin/Debug` runtime into `Dependencies/Canon` and built `VisitorDesk.Camera/bin/VisitorDesk.Camera.exe`.
- Runtime files: `EDSDK.dll` (file version 3.8.0.1), `EdsImage.dll` (3.8.20.0), `EDSDKLib.dll` (existing EOSDigital wrapper). All three are x86 and must remain together. The wrapper is a separate component, not supplied by a new Canon SDK download.
- The helper uses Windows .NET Framework 4.x and runs separately from the .NET 8 web server. On 11 October 2026, this computer detected the EOS 4000D, opened a session, captured and downloaded a JPEG, and displayed a second capture in the browser Photo preview.
- The native binaries remain local and Git-ignored. Include them only in a permitted local handover under their applicable licences; a source clone does not contain them.

## Connect and capture

1. Connect the EOS 4000D directly to this PC with a data-capable USB cable matching its terminal. Use a charged battery (or compatible power adapter for extended reception use).
2. Turn the camera on, use a still-photo mode such as P, and select JPEG or RAW+JPEG. RAW-only does not supply the portrait JPEG. Disable Wi-Fi if USB communication is unavailable; extend/disable auto power-off for reception use.
3. Close EOS Utility and other camera control software, including automatic startup on camera connection. Let Windows finish recognizing the device.
4. Start VISMA, open Photo, and select **Check Canon camera**. A connected response means the helper successfully opened a camera session.
5. Frame the visitor, then select **Capture with Canon**. Review the portrait. Retake as needed before completing registration. If autofocus cannot lock, improve lighting/distance or use manual focus.

## Rebuild / new computer

Use the supported Windows/.NET prerequisites described in the main handover. Install the .NET Framework runtime and any Microsoft Visual C++ runtime specified by the exact Canon SDK package you use. No extra runtime install was needed for the successful SDK-load check on this PC.

Windows web builds now build the camera helper automatically and include its executable plus all three DLLs in build/publish output. The service checks both the app content root and the directory beside the web executable. Keep Dependencies/Canon available when building from source.

For a manual helper build, from the VisitorDesk.Web folder:

```powershell
# With the prepared local Dependencies/Canon files:
./VisitorDesk.Camera/build.ps1
./VisitorDesk.Camera/bin/VisitorDesk.Camera.exe status

# Or import the three matching x86 DLLs from an authorised local folder:
./VisitorDesk.Camera/build.ps1 -SdkDirectory 'C:\CanonRuntime'
```

The build rejects non-x86 DLLs. Do not replace only one DLL or mix releases/architectures. The existing wrapper has been compiled against the supplied runtime; upgrading the SDK requires validating wrapper compatibility and physical capture again.

Canon lists EOS Rebel T100 / EOS 4000D / EOS 3000D as EDSDK-compatible: [Canon compatibility list](https://developercommunity.usa.canon.com/resource/1727731595000/CDC_EDSDKRAW_Compat_List). Obtain newer SDK packages from the [Canon Europe Developer Programme](https://developers.canon-europe.com/) for Europe/Middle East. Access and downloads may require registration and accepting Canon's terms. The listed compatibility does not establish that every old SDK version supports this camera; confirm the prepared runtime against the actual device when connected.

## Behaviour and troubleshooting

Verification: helper compilation, web build (nine existing text-parser warnings), JavaScript syntax checks, SDK initialization, and camera-service checks for missing helper, disconnected capture, temporary cleanup and retry passed. Hardware verification now passed: Windows detection, SDK session, shutter and JPEG download, browser connection check, portrait preview, and temporary capture cleanup. The app launched with SQL Server and USB access outside the agent sandbox. Published output was checked for the helper and all three runtime DLLs. No visitor registration was submitted. Run the independent service checks from this folder with `dotnet run --project VisitorDesk.Camera/Tests/CameraTests.csproj -- .`.

- `GET /api/camera/status`: SDK/session readiness. With no camera, HTTP 200 and `ready:false, sdkLoaded:true`; a missing or broken runtime returns HTTP 503.
- `POST /api/camera/capture`: returns a JPEG data URL; no camera returns HTTP 503 with connection guidance. It never substitutes a webcam image.
- Only one request may use the helper at a time. The web service and a Windows mutex protect access. Capture times out after 50 seconds at the process boundary; cancelled/hung helpers are terminated.
- Camera SaveTo is set to Host for capture and restored on normal completion. A forcibly terminated process cannot guarantee restoration; power-cycle/reconnect the camera after a timeout if necessary.
- Downloaded originals stay in a unique `VisitorData/Temp/camera` job folder and are removed after the request. The returned portrait is orientation-corrected, resized to at most 1600 pixels, and JPEG encoded. It becomes a saved record only when registration is submitted.
- If SDK initialization succeeds but no camera appears: check cable/data support, power, Wi-Fi, competing software and the SDK release's model support. Never fetch replacement DLLs from untrusted DLL-download sites.
- First hardware acceptance check: connection, capture/retake, focus failure, unplug/reconnect, sleep/wake, and saved portrait orientation. Connection and capture passed. Focus failure, unplug/reconnect, sleep/wake and saved-record portrait orientation remain unverified.
