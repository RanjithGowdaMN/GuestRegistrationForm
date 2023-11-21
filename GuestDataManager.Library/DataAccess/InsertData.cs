using GuestDataManager.Library.Internal.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestDataManager.Library.DataAccess
{
    public class InsertData
    {
        public void GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = Id };

            //var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "GuestData");

            //return output;
        }
    }
}
