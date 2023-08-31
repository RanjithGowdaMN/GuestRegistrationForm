using GuestRegistrationDeskUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.Models
{
    public class gConcatenatedDataBinding
    {
        public gVisitorDataSheet visitorDataSheet { get; set; }
        public gConfidentialityAgreementForVisitor  CAforVisitor { get; set; }
        public gVisitorsLogBook  vlBook { get; set; }
        public gHighlySecurityControlAreaLog  hsaLog { get; set; }
        public gConsultantApplicationForm consultantApplicationForm { get; set; }
    }
}
