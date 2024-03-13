using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.Models
{
    public sealed class ConsultantApplicationForm
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string HomePhoneNo { get; set; }
        public string SocialSecurityNumber { get; set; }
        public bool IsYes { get; set; }
        public bool IsNo { get; set; }
        public string CompanyName { get; set; }
        public string IdNo { get; set; }
        public string PassportNumber { get; set; }
        public string PlaceofIssue { get; set; }
        public string  DateOfIssue { get; set; }
        public string PassportDateofIssue { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public string PassportValidity { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public string PurposeOfVisit { get; set; }
        public string Duration { get; set; }
        //public string Durationto { get; set; }
        public string EmergencyContactNo { get; set; }

        public string Previous7YrResidency { get; set; }
        public bool ConvictedFelony { get; set; }
        public string Alias { get; set; }

        public string CardNumber { get; set; }

        public string Status { get; set; }

        public string DurationStart { get; set; }

        private static ConsultantApplicationForm instance;
        private static readonly object lockObject = new object();
        private ConsultantApplicationForm()
        {

        }
        public static ConsultantApplicationForm Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new ConsultantApplicationForm();
                        }
                    }
                }
                return instance;
            }
        }

        public static ConsultantApplicationForm reset()
        {
            instance = null;
            lock (lockObject)
            {
                return instance = new ConsultantApplicationForm();
            }
        }
    }
}
