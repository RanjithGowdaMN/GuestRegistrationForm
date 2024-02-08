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
    public class InsertData
    {
        SqlDataAccess sql;
        public InsertData()
        {
            sql = new SqlDataAccess();
        }

        public void InsertNewCompanyNames(string CompnayName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@CompanyNames", CompnayName);
            sql.SaveData("dbo.spInsertInToCompanyName", parameters, "GuestData");
        }

        public void InsertVisitorRecord(ScannedFileModel scannedFileInfo, ScannedData scannedData, CameraStatus cameraStatus,
                            ConsultantApplicationForm consultantApplicationForm, VisitorDataSheet visitorDataSheet)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters = BuildspParameters(scannedFileInfo, scannedData, cameraStatus, consultantApplicationForm, visitorDataSheet);

            sql.SaveData("dbo.spInsertVisitorInformation", parameters, "GuestData");
        }

        public void InsertVisitorRecordTest(ScannedFileModel scannedFileInfo, ScannedData scannedData, CameraStatus cameraStatus,
                            ConsultantApplicationForm consultantApplicationForm, VisitorDataSheet visitorDataSheet)
        {
            byte[] imageFrontSide = File.ReadAllBytes(scannedFileInfo.FrontSideFileName);
            byte[] imageBackSide = File.ReadAllBytes(scannedFileInfo.BackSideFileName);

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Name", scannedData.Name },
                { "@IdNumber", scannedData.IdNumber},
                { "@Dob", scannedData.DateOfBirth},
                { "@IdType", 2},
                { "@IdFrontSide", imageFrontSide},
            };

            List<string> p = new List<string>();
            p.Add("Name1");
            p.Add("IdNumber");
            p.Add("Dob");
            p.Add("IdType");

            sql.SaveData<List<string>>("dbo.spInsertVisitorInformation", p, "GuestData");
        }

        public Dictionary<string, object> BuildspParameters(ScannedFileModel scannedFileInfo, ScannedData scannedData, CameraStatus cameraStatus,
                            ConsultantApplicationForm consultantApplicationForm, VisitorDataSheet visitorDataSheet)
        {
            //byte[] imageFrontSide = File.ReadAllBytes("D:\\VisitorData\\ScannedID\\image00001.jpg");
            //byte[] imageBackSide = Encoding.UTF8.GetBytes(SqlDbType.VarBinary.ToString());;
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@Name",scannedData.Name},//[nvarchar](50)         -- Mandatory
                {"@IdNumber",scannedData.IdNumber},//[nvarchar](15)     -- Mandatory
                {"@Dob",scannedData.DateOfBirth},//[nvarchar](15) 
                {"@IdExpiry",scannedData.Expiry},//[nvarchar](15)   -- Mandatory

                //Fields specific to Contractor
                {"@City",                   consultantApplicationForm.City ?? string.Empty},//[nvarchar](25)
                {"@Address",                consultantApplicationForm.Address ?? string.Empty},//[nvarchar](25)
                {"@Zip",                    consultantApplicationForm.Zip ?? string.Empty},//[nvarchar](25)
                {"@State",                  consultantApplicationForm.State ?? string.Empty},//[nvarchar](25)
                {"@CellPhone",              consultantApplicationForm.CellPhone ?? string.Empty},//[nvarchar](25)
                {"@Email",                  consultantApplicationForm.Email ??string.Empty},//[nvarchar](25)
                {"@SocialSecurityNumber",   consultantApplicationForm.SocialSecurityNumber ?? string.Empty},//[nvarchar](25)
                {"@HomePhoneNo",            consultantApplicationForm.HomePhoneNo??string.Empty},//[nvarchar](25)
                {"@PassportNumber",         consultantApplicationForm.PassportNumber??string.Empty},//[nvarchar](25)
                {"@PassportIssuePlace",     consultantApplicationForm.PlaceofIssue??string.Empty},//[nvarchar](50)
                {"@PassportIssuedOn",       consultantApplicationForm.PassportDateofIssue??string.Empty},//[nvarchar](25)
                {"@PassportValidity",       consultantApplicationForm.PassportValidity??string.Empty},//[nvarchar](25)
                {"@EmergencyContact",       consultantApplicationForm.EmergencyContactNo??string.Empty},//[nvarchar](25)
                {"@AliasName",              consultantApplicationForm.Alias??string.Empty},//[nvarchar](50)
                {"@Previous7YrResidency",   consultantApplicationForm.Previous7YrResidency??string.Empty},//[nvarchar](150)
                {"@DurationStart",          string.Empty},//[nvarchar](15)
                {"@DurationEnd",            string.Empty},//[nvarchar](15)
                {"@Duration",               string.Empty},//[nvarchar](15)
                { "@CardNumber",             consultantApplicationForm.CardNumber??string.Empty },

                //Fields specific to Visitor
                {"@PersonToBeVisited",      visitorDataSheet.PersonToBeVisited??string.Empty},//[nvarchar](150)
                {"@AreaToBeVisited",        visitorDataSheet.AreaVisited??string.Empty},//[nvarchar](50)
                {"@VisitDate",              visitorDataSheet.VisitDateFrom??string.Empty},//[nvarchar](15)
                {"@VisitTime",              string.Empty},//[nvarchar](15)
                {"@VisitFromDate",          string.Empty},//[nvarchar](15)
                {"@VisitToDuration",        string.Empty},//[nvarchar](15)
                {"@StartTime",              string.Empty},//[nvarchar](15)
                {"@EndTime",                string.Empty},//[nvarchar](15)
                {"@VisitDuration",          string.Empty},//[nvarchar](15)
                {"@DepartmentManager",      visitorDataSheet.DepartmentManager??string.Empty},//[nvarchar](50)
                {"@ProductionManager",      visitorDataSheet.ProductionManager??string.Empty},//[nvarchar](50)
                {"@SecurityController",     visitorDataSheet.SecurityController??string.Empty},//[nvarchar](50)
                {"@RFU1",                   string.Empty},//[nvarchar](100)
                {"@RFU2",                   string.Empty},//[nvarchar](100)
                {"@RFU3",                   string.Empty},//[nvarchar](100)
                {"@RFU4",                   string.Empty},//[nvarchar](100)
                {"@RFU5",                   string.Empty},//[nvarchar](100)
                {"@RFU6",                   string.Empty},//[nvarchar](100)
                {"@RFU7",                   string.Empty},//[nvarchar](100)
                {"@RFU8",                   string.Empty},//[nvarchar](100)
                {"@RFU9",                   scannedData.Nationality},//[nvarchar](100)
                {"@RFU10",                  scannedFileInfo.VisitorType},//[nvarchar](100)
                 
            };
            //byte[] nullValue = new byte[0];

            parameters.Add("@Convicted", false);
            parameters.Add("@IdType", 2); //TBD

            parameters.Add("@Title", consultantApplicationForm.Title ?? visitorDataSheet.Title ?? string.Empty);
            parameters.Add("@PurposeOfVisit", consultantApplicationForm.PurposeOfVisit ?? visitorDataSheet.PurposeOfVisit ?? string.Empty);
            parameters.Add("@CompanyName", consultantApplicationForm.CompanyName ?? visitorDataSheet.CompanyName ?? string.Empty);

           
            if (!string.IsNullOrEmpty(scannedFileInfo.FrontSideFileName))
            {
                parameters.Add("@IdFrontSide", Convert.ToBase64String(File.ReadAllBytes(scannedFileInfo.FrontSideFileName)));
            }
            else
            {
                parameters.Add("@IdFrontSide", string.Empty);
            }

            if (!string.IsNullOrEmpty(scannedFileInfo.BackSideFileName))
            {
                parameters.Add("@IdBackSide", Convert.ToBase64String(File.ReadAllBytes(scannedFileInfo.BackSideFileName)));
            }
            else
            {
                parameters.Add("@IdBackSide", string.Empty);
            }

            if (!string.IsNullOrEmpty(cameraStatus.ImagePath))
            {
                parameters.Add("@Photo", Convert.ToBase64String(File.ReadAllBytes(cameraStatus.ImagePath)));
            } 
            else
            {
                parameters.Add("@Photo", string.Empty);
            }

            return parameters;
        }
    }
}
