using GuestDataManager.Library.Internal.DataAccess;
using GuestRegistrationDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestDataManager.Library.DataAccess
{
    public class InsertData
    {
        SqlDataAccess sql;
        public InsertData()
        {
            sql = new SqlDataAccess();
        }
        public void GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = Id };

            //var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "GuestData");

            //return output;
        }

        public void InsertVisitorRecord(ScannedFileModel scannedFileInfo, ScannedData scannedData, CameraStatus cameraStatus,
                            ConsultantApplicationForm consultantApplicationForm, VisitorDataSheet visitorDataSheet)
        {
            byte[] imageFrontSide = File.ReadAllBytes("D:\\VisitorData\\ScannedID\\image00001.jpg");
            byte[] imageBackSide = File.ReadAllBytes(scannedFileInfo.BackSideFileName);

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Name", scannedData.Name },
                { "@IdNumber", scannedData.IDno},
                { "@Dob", scannedData.DateOfBirth},
                { "@IdType", 2},
                { "@IdFrontSide", imageFrontSide},
            };
            sql.SaveData("dbo.spUserLookup", parameters, "GuestData");
        }
    }
}
