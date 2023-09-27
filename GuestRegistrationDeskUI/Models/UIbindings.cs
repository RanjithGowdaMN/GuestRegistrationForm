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
        public List<string> Felony { get; set; }

        public List<string> State { get; set; }

        public List<string> Production { get; set; }
        public List<string> ITandSecurity { get; set; }
        public List<string> Management { get; set; }

        public List<string> Maintenance { get; set; }
        public List<string> PlanningAndDevelopment { get; set; }
        public List<string> AccountingAndProcurement { get; set; }

        public List<string> Office { get; set; }
        public List<string> Store { get; set; }
        public List<string> GraphicDesign { get; set; }
        public List<string> Quality { get; set; }
        public List<string> Personalisation { get; set; }


        public List<string> AreaToBeVisited { get; set; }
        public List<string> DepartmentManager { get; set; }

        public List<string> ProductionManager_DeputyManager { get; set; }

    }
}
