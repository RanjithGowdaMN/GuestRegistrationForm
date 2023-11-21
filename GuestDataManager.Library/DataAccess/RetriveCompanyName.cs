using GuestDataManager.Library.Internal.DataAccess;
using GuestDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestDataManager.Library.DataAccess
{
    public class RetriveCompanyName
    {
        public List<CompanyNameList> GetCompanyname()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { };

            var output = sql.LoadData<CompanyNameList, dynamic>("dbo.spRetriveCompanyName", p, "GuestData");

            return output;
        }
    }
}
