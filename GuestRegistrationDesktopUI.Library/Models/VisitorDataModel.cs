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
        //TBD
    }
}
