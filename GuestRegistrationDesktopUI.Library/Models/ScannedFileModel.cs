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
        public string VisitorType { get; set; } = string.Empty;

        private static ScannedFileModel instance;
        private static readonly object lockObject = new object();
        private ScannedFileModel()
        {

        }
        public static ScannedFileModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new ScannedFileModel();
                        }
                    }
                }
                return instance;
            }
        }

        public static ScannedFileModel reset()
        {
            instance = null;
            lock (lockObject)
            {
                return instance = new ScannedFileModel();
            }
        }
    }
}
