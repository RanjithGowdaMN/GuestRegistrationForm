using System;

namespace Fi800ScanLibrary.Scanner
{
    public interface IScanDocument
    {
        IntPtr Handle { get; }

        void OpenScanner();
        void StartScan();
    }
}