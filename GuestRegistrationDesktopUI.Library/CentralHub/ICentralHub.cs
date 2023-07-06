using GuestRegistrationDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.CentralHub
{
    public interface ICentralHub
    {
        VisitorDataModel StartScanning();

        CameraStatus TakePhoto();

        void CloseAllSession();
    }
}
