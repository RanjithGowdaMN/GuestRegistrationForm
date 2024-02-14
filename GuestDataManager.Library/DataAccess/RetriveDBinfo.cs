using GuestDataManager.Library.Internal.DataAccess;
using GuestDataManager.Library.Models;
using GuestRegistrationDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestDataManager.Library.DataAccess
{
    public class RetriveDBinfo
    {
        SqlDataAccess sql;
        public RetriveDBinfo()
        {
            sql = new SqlDataAccess();
        }
        public VisitorInformation GetVisitorByIdNumber(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { IdNumber = Id };

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@IdNumber", Id },
            };
            return sql.LoadData("dbo.spGetVisitorByIdNumber", parameters, "GuestData");
        }
        public List<CompanyNameList> GetCompanyname()
        {
            var p = new { };
            return sql.LoadData<CompanyNameList, dynamic>("dbo.spRetriveCompanyName", p, "GuestData");
        }
        public List<VisitorVisitPurpose> GetVisitorVisitPurpose()
        {
            var p = new { };
            return sql.LoadData<VisitorVisitPurpose, dynamic>("dbo.spVisitorVisitPurpose", p, "GuestData");
        }
        public List<PersonToBeVisited> GetPersontobeVisited()
        {
            var p = new { };
            return sql.LoadData<PersonToBeVisited, dynamic>("dbo.spPersontobeVisited", p, "GuestData");
        }
        public List<AreaToBeVisited> GetAreatobeVisited()
        {
            var p = new { };
            return sql.LoadData<AreaToBeVisited, dynamic>("dbo.spAreatobeVisited", p, "GuestData");
        }
        public List<DepartmentManager> GetDepartmentManager()
        {
            var p = new { };
            return sql.LoadData<DepartmentManager, dynamic>("dbo.spDepartmentManager", p, "GuestData");
        }
        public List<DepartmentNames> GetDepartmentNames()
        {
            var p = new { };
            return sql.LoadData<DepartmentNames, dynamic>("dbo.spDepartmentNames", p, "GuestData");
        }
        public List<SecurityController> GetSecurityController()
        {
            var p = new { };
            return sql.LoadData<SecurityController, dynamic>("dbo.spSecurityController", p, "GuestData");
        }
        public List<ProductionManagers> GetProductionManagers()
        {
            var p = new { };
            return sql.LoadData<ProductionManagers, dynamic>("dbo.spProductionManagers", p, "GuestData");
        }

        public List<VisitorTitle> GetVisitorTitle()
        {
            var p = new { };
            return sql.LoadData<VisitorTitle, dynamic>("dbo.spGetVisitorTitle", p, "GuestData");
        }

        public List<CardId> GetCardIds()
        {
            var p = new { };
            
            return sql.LoadData<CardId, dynamic>("dbo.spGetCardIds", p, "GuestData");
        }

        public List<CardId> GetCards()
        {
            
            var p = new { };
                                   
            return sql.LoadData<CardId, dynamic>("dbo.spGetAllocatedCard", p, "GuestData");
        }

        public VisitorInformation GetVisitorbyCard (string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { CardNumber = Id };

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@CardNumber", Id },
            };
            return sql.LoadData("dbo.spGetVisitorByCardNumber", parameters, "GuestData");
        }


    }
}
