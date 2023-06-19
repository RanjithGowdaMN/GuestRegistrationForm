using GuestRegistrationDesktopUI.Library.Models;
using System;

namespace GuestRegistrationDesktopUI.Library.FiScanner
{
    public interface IFiScan
    {
        VisitorDataModel StartScanning();

        //void OnScanCompleted();
    }
}