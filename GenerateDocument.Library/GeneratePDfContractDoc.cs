using GuestRegistrationDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateDocument.Library
{
    public class GeneratePDfContractDoc
    {
        public string GenerateContractDocument(GuestDataModel guestDataModel, gScannedFileModel gScannedFileModel, gConcatenatedDataBinding gConcatenatedDataBinding, string inputFilePath,
                                            string outputFilePath, string imagePath)
        {
            inputFilePath = @"D:\VisitorData\BaseDocument\Contractor.pdf";
            string fullName = guestDataModel.Name;
            string[] nameParts = new string[10];
            if (!string.IsNullOrEmpty(fullName))
            {
                nameParts = fullName.Split(' ');
            }

            string firstName = nameParts[0];
            string scndName = string.Empty;
            try
            {
                scndName = nameParts[1];
            }
            catch (IndexOutOfRangeException ex)
            {
                scndName = string.Empty;
            }

            string lastName = string.Join(" ", nameParts.Skip(2));

           

            List<Tuple<float, float, string>> textForSecondPage = new List<Tuple<float, float, string>>();
            List<Tuple<float, float, string>> textForThirdPage = new List<Tuple<float, float, string>>();

            if (guestDataModel.IsPassport)
            {
                //Text position for Passport
               //consultant Application Form
                textForSecondPage.Add(new Tuple<float, float, string>(390, 580, firstName));
                textForSecondPage.Add(new Tuple<float, float, string>(228, 580, scndName));
                textForSecondPage.Add(new Tuple<float, float, string>(65, 580, lastName));
                textForSecondPage.Add(new Tuple<float, float, string>(340, 550, gConcatenatedDataBinding.consultantApplicationForm.Address));         
                textForSecondPage.Add(new Tuple<float, float, string>(235, 550, gConcatenatedDataBinding.consultantApplicationForm.City));
                textForSecondPage.Add(new Tuple<float, float, string>(130, 550, gConcatenatedDataBinding.consultantApplicationForm.State));
                textForSecondPage.Add(new Tuple<float, float, string>(100, 515, gConcatenatedDataBinding.consultantApplicationForm.Zip));
                textForSecondPage.Add(new Tuple<float, float, string>(318, 515, gConcatenatedDataBinding.consultantApplicationForm.Email));
                textForSecondPage.Add(new Tuple<float, float, string>(197, 515, gConcatenatedDataBinding.consultantApplicationForm.CellPhone));
                textForSecondPage.Add(new Tuple<float, float, string>(65, 515, gConcatenatedDataBinding.consultantApplicationForm.Homephone));
                textForSecondPage.Add(new Tuple<float, float, string>(310, 483, gConcatenatedDataBinding.consultantApplicationForm.SecurityNo));
                textForSecondPage.Add(new Tuple<float, float, string>(307, 450, gConcatenatedDataBinding.consultantApplicationForm.CompanyName));
                               
                textForSecondPage.Add(new Tuple<float, float, string>(110, 450, guestDataModel.DateOfBirth));
                textForSecondPage.Add(new Tuple<float, float, string>(150, 417, guestDataModel.IDno));
                textForSecondPage.Add(new Tuple<float, float, string>(150, 385, guestDataModel.Expiry));
                textForSecondPage.Add(new Tuple<float, float, string>(90, 353, guestDataModel.Nationality));

                textForSecondPage.Add(new Tuple<float, float, string>(310, 385, gConcatenatedDataBinding.consultantApplicationForm.DateandPlaceofIssue));
                textForSecondPage.Add(new Tuple<float, float, string>(370, 385, gConcatenatedDataBinding.consultantApplicationForm.PDateofIssue));
                textForSecondPage.Add(new Tuple<float, float, string>(310,353, gConcatenatedDataBinding.consultantApplicationForm.PurposeOfVisit));
                textForSecondPage.Add(new Tuple<float, float, string>(310, 317, gConcatenatedDataBinding.consultantApplicationForm.Duration));
                textForSecondPage.Add(new Tuple<float, float, string>(150,317, gConcatenatedDataBinding.consultantApplicationForm.EmergencyContactNo));

                

                //confidentiality Agreement Form


                textForThirdPage.Add(new Tuple<float, float, string>(110, 710, guestDataModel.Name));
                textForThirdPage.Add(new Tuple<float, float, string>(100, 680, gConcatenatedDataBinding.CAforVisitor.Title));
                textForThirdPage.Add(new Tuple<float, float, string>(350, 680, gConcatenatedDataBinding.CAforVisitor.Company));
                textForThirdPage.Add(new Tuple<float, float, string>(410, 500, DateTime.Now.ToString("dd-MM-YYYY")));
            }
            else
            {
                //Text position for Qatar ID 
                //Consultant Application Form           
                textForSecondPage.Add(new Tuple<float, float, string>(390, 580, firstName));
                textForSecondPage.Add(new Tuple<float, float, string>(228, 580, scndName));
                textForSecondPage.Add(new Tuple<float, float, string>(65, 580, lastName));
                textForSecondPage.Add(new Tuple<float, float, string>(110, 450, guestDataModel.DateOfBirth));
                textForSecondPage.Add(new Tuple<float, float, string>(310, 417, guestDataModel.IDno));
                textForSecondPage.Add(new Tuple<float, float, string>(150, 385, guestDataModel.Expiry));
                                                         
                textForSecondPage.Add(new Tuple<float, float, string>(90, 353, guestDataModel.Nationality));


                textForSecondPage.Add(new Tuple<float, float, string>(340, 550, gConcatenatedDataBinding.consultantApplicationForm.Address));
                textForSecondPage.Add(new Tuple<float, float, string>(235, 550, gConcatenatedDataBinding.consultantApplicationForm.City));
                textForSecondPage.Add(new Tuple<float, float, string>(130, 550, gConcatenatedDataBinding.consultantApplicationForm.State));

                textForSecondPage.Add(new Tuple<float, float, string>(65, 543, gConcatenatedDataBinding.consultantApplicationForm.Zip));
                textForSecondPage.Add(new Tuple<float, float, string>(318, 515, gConcatenatedDataBinding.consultantApplicationForm.Email));
                textForSecondPage.Add(new Tuple<float, float, string>(197, 515, gConcatenatedDataBinding.consultantApplicationForm.CellPhone));
                textForSecondPage.Add(new Tuple<float, float, string>(65, 515, gConcatenatedDataBinding.consultantApplicationForm.Homephone));
                textForSecondPage.Add(new Tuple<float, float, string>(310, 483, gConcatenatedDataBinding.consultantApplicationForm.SecurityNo));
                textForSecondPage.Add(new Tuple<float, float, string>(85, 483, gConcatenatedDataBinding.consultantApplicationForm.CcFelony));
                textForSecondPage.Add(new Tuple<float, float, string>(307, 450, gConcatenatedDataBinding.consultantApplicationForm.CompanyName));
                textForSecondPage.Add(new Tuple<float, float, string>(150, 417, gConcatenatedDataBinding.consultantApplicationForm.PassportNo));
                textForSecondPage.Add(new Tuple<float, float, string>(310, 385, gConcatenatedDataBinding.consultantApplicationForm.DateandPlaceofIssue));
                textForSecondPage.Add(new Tuple<float, float, string>(370, 385, gConcatenatedDataBinding.consultantApplicationForm.PDateofIssue));
                textForSecondPage.Add(new Tuple<float, float, string>(310, 353, gConcatenatedDataBinding.consultantApplicationForm.PurposeOfVisit));
                textForSecondPage.Add(new Tuple<float, float, string>(365, 317, gConcatenatedDataBinding.consultantApplicationForm.Duration));
               // textForSecondPage.Add(new Tuple<float, float, string>(340, 317, gConcatenatedDataBinding.consultantApplicationForm.Durationto));

                textForSecondPage.Add(new Tuple<float, float, string>(150, 317, gConcatenatedDataBinding.consultantApplicationForm.EmergencyContactNo));

                textForSecondPage.Add(new Tuple<float, float, string>(65, 190, gConcatenatedDataBinding.consultantApplicationForm.PResidence));
                textForSecondPage.Add(new Tuple<float, float, string>(425, 73, DateTime.Now.ToString("dd-MM-yyyy")));

                //confidentiality Agreement For Contractors

                textForThirdPage.Add(new Tuple<float, float, string>(110, 710, guestDataModel.Name));
                textForThirdPage.Add(new Tuple<float, float, string>(100, 680, gConcatenatedDataBinding.CAforVisitor.Title));
                textForThirdPage.Add(new Tuple<float, float, string>(350, 680, gConcatenatedDataBinding.CAforVisitor.Company));
               textForThirdPage.Add(new Tuple<float, float, string>(400, 505, DateTime.Now.ToString("dd-MM-yyyy")));
            }
            // adding text



            
            outputFilePath = $"D:\\VisitorData\\GeneratedDocument\\C_{guestDataModel.IDno}__{DateTime.Now.ToString("ddMMyyyyHHmm")}.pdf";

            // Modify the PDF with the image and texts
            GeneratePDFdocument.ModifyPdf(inputFilePath, textForSecondPage, textForThirdPage, outputFilePath, imagePath, "contract",gScannedFileModel,guestDataModel);
            
            return outputFilePath;
        }
    }
}
