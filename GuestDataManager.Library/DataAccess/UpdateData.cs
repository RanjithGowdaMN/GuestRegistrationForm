using GuestDataManager.Library.Internal.DataAccess;
using GuestRegistrationDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestDataManager.Library.DataAccess
{
    public  class UpdateData
    {
        SqlDataAccess sql;

        public UpdateData()

        {
            sql = new SqlDataAccess();

        }

        public void UpdateCardStatus(string CardNumber)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@CardNumber", CardNumber);
            sql.SaveData("dbo.spUpdateCardStatus", parameters, "GuestData");
        }
        
        public void RecoverCardStatus(string CardNumber)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@CardNumber", CardNumber);
            sql.SaveData("dbo.spRecoverCardStatus", parameters, "GuestData");
        }

        public void UpdateContractorStatus(string CardNumber)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@CardNumber", CardNumber);
            sql.SaveData("dbo.spUpdateContractorStatusVistorInformation", parameters, "GuestData");
        }

    }

      

}
