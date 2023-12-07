using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.Models
{
    public class VisitorDataModel
    {
        public string Name { get; set; }
        public string IDno { get; set; }
        public string DateOfBirth { get; set; }
        public string Expiry { get; set; }
        public string Nationality { get; set; }
        public bool IsPassport { get; set; }
        public List<bool> isDataFromDb { get; set; }
        //TBD

        private static VisitorDataModel instance;
        private static readonly object lockObject = new object();
        private VisitorDataModel()
        {

        }
        public static VisitorDataModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new VisitorDataModel();
                        }
                    }
                }
                return instance;
            }
        }

        public static VisitorDataModel reset()
        {
            instance = null;
            lock (lockObject)
            {
                return instance = new VisitorDataModel();
            }
        }
    }
}
