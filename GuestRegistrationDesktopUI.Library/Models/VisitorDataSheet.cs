using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.Models
{
    public class VisitorDataSheet
    {
        public string Title { get; set; }
        public string VisitorName { get; set; }  //scan form
        public string Date { get; set; }
        public string CompanyName { get; set; }
        public string VisitorIdNo { get; set; }
        public string PurposeOfVisit { get; set; }
        public string PersonToBeVisited { get; set; }
        public string AreaVisited { get; set; }
        public string VisitDateFrom { get; set; }
        public string VisitDateTo { get; set; }
        public string VisitTimeHrFrom { get; set; } = "00";
        public string VisitTimeHrTo { get; set; } = "00";
        public string VisitTimeMinFrom { get; set; } = "00";
        public string VisitTimeMinTo { get; set; } = "00";
        public string VisitDuration { get; set; }
        public string DepartmentManager { get; set; }
        public string ProductionManager { get; set; }
        public string SecurityController { get; set; }
        public string VisitorDuration { get; set; }
    }
}
