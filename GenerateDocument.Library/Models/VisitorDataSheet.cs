using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDeskUI.Models
{
    public class gVisitorDataSheet
    {
        public string VisitorName { get; set; }
        public string Date { get; set; }
        public string Company { get; set; }
        public string VisitorIdNo { get; set; }
        public string ReasonForVisit { get; set; }
        public string PersontobeVisited { get; set; }
        public string AreaVisited { get; set; } = string.Empty;
        public string VisitDateTime { get; set; }
        public string VisitDuration { get; set; }
        public string DepartmentManager { get; set; }
        public string ProductionManager { get; set; }
        public string SecurityController { get; set; }
        public string Title { get; set; }
        public string VisitorDuration { get; set; }
        public string VisitDateFrom { get; set; }
    }
}
