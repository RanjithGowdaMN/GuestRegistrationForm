# Implementation status — 7 October 2026

Software implementation completed for original three sections and the additional eight-item request. See README.md for setup, storage, database schema and verification.

Running server: VisitorDesk.Web/bin/SqlVerify/VisitorDesk.Web.exe, PID 31448 at time of validation, port 5080. Runtime data in repository-root VisitorData. SQL GuestData with original 12 tables / 13 procedures plus ReceptionVisits. Connection stored in DPAPI-protected ignored VisitorData/Data/database.secret. Confidential ReadQID DLL was only compiled against / called via the user-supplied sample; never inspected or uploaded.

Confirmed: SQL record create/read, document update, checkout; synthetic OCR name/ID/DOB/expiry extraction; PDF responses and rendered pages; browser Settings and saved-record document/card preview generation; clock. Real QID read and physical printer output remain hardware acceptance checks; no readable card was available, and no print job was sent.

Preserve prior changes in legacy csproj files, FI800Scan, VisitorDesk.Scanner and the web app. No commits or uploads made. Usage rule remains stop at <=3% remaining in either window and resume only after reset. Do not resume periodic development after completed software work unless user requests changes or hardware checks.

8 October OCR follow-up complete: one-side extraction, editable review, conflict reporting, explicit application, cancel, stale-result guard, low-confidence fallback, improved labels/date parsing. Parser regression checks and synthetic API/browser extraction passed. Latest build: bin/OcrFinal. No real identity test data or physical printer jobs used.
