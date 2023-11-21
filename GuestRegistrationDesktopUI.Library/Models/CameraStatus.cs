using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.Models
{
    public class CameraStatus
    {
        public bool CameraSessionActive { get; set; } = false;
        public bool CameraConnected { get; set; } = false;
        public string ErrorMessage { get; set; } = null;
        public string ImagePath { get; set; } = "D:\\VisitorData\\Photos\\photo00001.jpg";
    }
}
