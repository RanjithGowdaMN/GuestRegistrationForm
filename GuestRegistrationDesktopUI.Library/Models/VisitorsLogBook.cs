using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDeskUI.Models
{
    class VisitorsLogBook
    {
        public string IdDateOfIssue { get; set; }
        public string PlaceOfIssue { get; set; }
        public string VisitorAndCompanyName { get; set; }
        public string VisitorsBadgeNo { get; set; }
        public string PurposeOfVisit { get; set; }
        public string Date { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
        public string EmployeetobeVisited { get; set; }
    }

}
