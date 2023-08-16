using GuestRegistrationDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GuestRegistrationDesktopUI.Library.CentralHub.CentralHub;

namespace GuestRegistrationDesktopUI.Library.CentralHub
{
    public interface ICentralHub
    {
        VisitorDataModel StartScanning();

        CameraStatus TakePhoto();

        void CloseAllSession();

        void OnPhotoDownloadCompleted(string path);

        //event PropertyChangedEventHandler PropertyChanged;

        event OnPhotoDownloadCompletedEventHandler CanonImageDownload;

        void GenerateDocument();

        void GenerateContractDocument();

    }
}
