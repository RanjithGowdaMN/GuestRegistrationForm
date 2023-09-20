using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDeskUI.Models
{
    public class UIbindingModel
    {
        public List<string> VisitorVisitPurpose { get; set; }
        public List<string> VisitorCompanyName { get; set; }
        public List<string> DepartmentNames { get; set; }

        public List<string> Production { get; set; }
        public List<string> IT { get; set; }
        public List<string> Security { get; set; }

    }
}
