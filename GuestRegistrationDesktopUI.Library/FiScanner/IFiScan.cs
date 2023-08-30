using GuestRegistrationDesktopUI.Library.Models;
using System;

namespace GuestRegistrationDesktopUI.Library.FiScanner
{
    public interface IFiScan
    {
        (VisitorDataModel, string) StartScanning(int IdType);

        //void OnScanCompleted();
    }
}