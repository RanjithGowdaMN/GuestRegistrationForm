using GuestRegistrationDeskUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.Models
{
    public class ConcatenatedDataBinding
    {
        public VisitorDataSheet visitorDataSheet { get; set; }
        public ConfidentialityAgreementForVisitor  CAforVisitor { get; set; }
        public VisitorsLogBook  vlBook { get; set; }
        public HighlySecurityControlAreaLog  hsaLog { get; set; }
        public ConsultantApplicationForm consultantApplicationForm { get; set; }
    }
}
