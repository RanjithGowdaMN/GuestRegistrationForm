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
        public gConcatenatedDataBinding()
        {
            visitorDataSheet = new gVisitorDataSheet();
            CAforVisitor = new gConfidentialityAgreementForVisitor();
            vlBook = new gVisitorsLogBook();
            hsaLog = new gHighlySecurityControlAreaLog();
            consultantApplicationForm = new gConsultantApplicationForm();
        }
        public gVisitorDataSheet visitorDataSheet { get; set; }
        public gConfidentialityAgreementForVisitor  CAforVisitor { get; set; }
        public gVisitorsLogBook  vlBook { get; set; }
        public gHighlySecurityControlAreaLog  hsaLog { get; set; }
        public gConsultantApplicationForm consultantApplicationForm { get; set; }
    }
}
