using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDeskUI.Models
{
    public class ConsultantApplicationForm
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string Homephone { get; set; }
        public string SecurityNo { get; set; }
        public bool IsYes { get; set; }
        public bool IsNo { get; set; }
        public string CompanyName { get; set; }
        public string IdNo { get; set; }
        public string PassportNo { get; set; }
        public string DateandPlaceofIssue { get; set; }

        public string PDateofIssue { get; set; }
        public string PassportValidity { get; set; }
        public string PurposeOfVisit { get; set; }
        public string Duration { get; set; }
        //public string Durationto { get; set; }
        public string EmergencyContactNo { get; set; }

        public string PResidence { get; set; }
        public string CcFelony { get; set; }
        public string Alias { get; set; }
    }
}
