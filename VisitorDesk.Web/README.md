# VISMA reception app

Canon EOS 4000D USB capture is prepared in this VisitorDesk.Web app. See [Canon setup](VisitorDesk.Camera/README.md). EOS 4000D connection, physical capture, JPEG download and browser photo preview were verified on 11 October 2026. Camera runtime files are included in Windows build/publish output.

Run `dotnet run --project VisitorDesk.Web.csproj`, then open http://localhost:5080 in Edge or Chrome. Requires .NET 8, Windows, local SQL Server and the configured hardware drivers.

## Installed workflow

- Dashboard, identity scanning/cropping, visitor photo, registration and visitor log.
- Read ID chip: local x86 helper using the public `ConnectReader`, `ReadQIDData`, `Disconnect` calls supplied in `Lib/qIDReading.txt`. Review the result before applying it. Existing registration fields are preserved; the portrait fills only an empty photo. The confidential DLL is used locally and is ignored by Git. It is not decompiled or uploaded.
- Document filling: visitor/contractor PDF overlays reuse the original form coordinates. Choose the current draft or a saved visitor, enter supplementary fields, generate, review and download/print. Save document details to retain supplementary fields for a saved record. The contractor application is page 3; its agreement is page 2. Signatures on the original agreements remain available for signing.
- ID card printing: visitor/contractor layout, portrait, name and card number. Generate a PDF and print through the PDF viewer. Card dimensions follow the legacy layout, 252.72 x 153.09 points; use actual-size scaling and matching printer stock. Generation alone does not print.
- Settings: editable department/employee lists and all imported reception lookup lists. One entry per line. Employee lists are keyed by department name. Registration uses these lists for department, host, company, purpose and document-field suggestions. Device checks and storage/setup information are also here.
- A seconds clock sits next to the date. Typography uses the local Segoe UI/Arial stack without external font requests.

## Working data

All application-owned working data uses `<web-folder>/VisitorData`, outside the public web root and excluded from Git:

- `BaseDocument/Visitor.pdf` and `Contractor.pdf`: copied from the supplied templates, read only during generation.
- `Data/DataConfiguration.json`: imported lookup configuration; Settings saves here. SQL department/employee tables were seeded from this file during database recreation; later Settings changes update this JSON configuration, not the legacy lookup tables.
- `Data/database.secret`: Windows DPAPI-encrypted connection string for the current Windows account. No password is checked into source. Alternatively provide `ConnectionStrings__GuestData` through the environment.
- `Temp`: transient scanner/OCR/PDF jobs, removed after each operation; development verification and server logs are also here.
- `Records`: migration source for older JSON registrations. Existing root JSON records in the former `App_Data` directory are copied here once; SQL import never overwrites an existing SQL record.
- `Photos`, `ScannedID`, `GeneratedDocument`: reserved for file-based integrations. Registration images and document details currently reside in SQL together with their record.

## Database

`database/deploy.sql` recreates the tables and procedures from the supplied GuestData project, creating missing tables and altering procedures without dropping data. It was applied to `localhost/GuestData` with the supplied SQL login. It created the original 12 tables and 13 procedures; 11 departments and 42 employees were loaded from DataConfiguration.json.

The web app adds `dbo.ReceptionVisits` to persist the complete registration payload, including images, signatures and document fields, without truncating data to the older schema's short column lengths. Legacy `VisitorInformation` remains intact; web records are stored in ReceptionVisits. Startup requires SQL access and imports any older local records. Checkout and document updates persist in SQL.

To configure another Windows account, run `database/configure.ps1` and enter its database password at the prompt. Run `sqlcmd -S localhost -U sa -C -b -i database/deploy.sql` to apply the schema (sqlcmd will request the password). The configured local SQL connection trusts the local server certificate; use a validated server certificate for a shared deployment.

## Hardware and dependencies

Run the bridge builds from inside VisitorDesk.Web:

```powershell
./VisitorDesk.Scanner/build.ps1
./VisitorDesk.Ocr/build.ps1
./VisitorDesk.Chip/build.ps1
./documents/setup.ps1
```

The scanner requires the installed Fujitsu SDK and PaperStream driver. OCR reuses the existing Tesseract 5.2 wrapper, native libraries and English traineddata from Dependencies/Ocr. It runs entirely locally. Qatar label extraction is ported from ProcessTextData, preserving names and returning ISO dates instead of error strings. The original checksum-aware MRZ Parser, Document and CountryCode sources are linked directly. Each request has fresh parsing state. Review all OCR results.

QID requires the user-supplied ReadQID.Library.dll and SCBase.dll in Lib, plus the reader driver. These private binaries and symbols are ignored by Git; do not distribute them. Build the helper locally. Card operations run in a separate process with a timeout, so SDK failures do not terminate the web server.

PDF dependencies live in the ignored `.venv-documents` environment, selected automatically. `Documents__Python` can override its interpreter. The supplied English identity fields are supported; unsupported characters and overlong fields produce a validation error rather than silent replacement. Template pages are preserved. Use Edge/Chrome or the downloaded PDF if an embedded browser cannot display the PDF viewer.

## Verification and limits

Verified: web build; bridge compilation; synthetic local OCR extracting name, ID, birth and expiry; visitor/contractor/card PDF generation and rendered layout checks; SQL create/read/update/checkout; Settings load; saved-record document/card preparation in the browser; live clock. The imported legacy text-processing sources still emit nullable/unreachable-code warnings.

Reader detection found Broadcom Corp Contacted SmartCard 0. A successful real QID read remains unverified because no readable card was available; SDK errors are reported in the UI. No physical print job was sent. The site remains loopback-only and has no application login or retention policy; it is intended for the local reception desktop.

## OCR review update — 8 October 2026

Use **Scan → Extract identity details** after capturing either side. OCR runs locally and presents editable suggestions with their front/back source. Conflicting values require a manual choice; existing registration values are unchecked. **Apply selected details** applies only reviewed choices. Changing a scan invalidates its review; changing registration values after extraction blocks stale results from overwriting them. Cancel stops the extraction without applying fields. Both scan sides are still required for final registration.

The engine retries tightly cropped/low-confidence images using single-block segmentation. Low recognition confidence is shown as a review warning, not an identity-verification score. Label parsing handles compact and split labels, labelled passport numbers, ISO and day/month/year dates. The existing MRZ parser validates check digits. Run `dotnet run --project VisitorDesk.Tests` for parser regression checks.

Verified with a synthetic single-side ID image through both the API and browser: five identity fields extracted, no registration mutation before Apply, reviewed fields populated afterward. Original scans are preserved. Real document accuracy still depends on scan quality; inspect every extracted value.

## Single-folder handover

See HANDOVER.md for the folder layout and new-computer setup. Run setup.ps1 from this folder. All app file dependencies now resolve within this folder; SQL Server and installed device drivers remain machine prerequisites.
