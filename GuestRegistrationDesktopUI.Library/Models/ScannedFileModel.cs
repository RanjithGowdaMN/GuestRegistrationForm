using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.Models
{
    public class ScannedFileModel
    {
        public string FrontSideFileName { get; set; } = "D:\\VisitorData\\temp\\IDCardFront.jpg";
        public string BackSideFileName { get; set; } = "D:\\VisitorData\\temp\\IDCardBack.jpg";
        public bool IsSecondSide { get; set; }
    }
}
