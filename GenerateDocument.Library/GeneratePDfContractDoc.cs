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
        public void GenerateContractDocument(GuestDataModel guestDataModel, gScannedFileModel gScannedFileModel, gConcatenatedDataBinding gConcatenatedDataBinding, string inputFilePath,
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

           

            List<Tuple<float, float, string, float>> textForSecondPage = new List<Tuple<float, float, string, float>>();
            List<Tuple<float, float, string>> textForThirdPage = new List<Tuple<float, float, string>>();

            if (guestDataModel.IsPassport)
            {
                //Text position for Passport
               //consultant Application Form
                textForSecondPage.Add(new Tuple<float, float, string, float>(390, 580, firstName, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(230, 580, scndName, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(70, 580, lastName, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(340, 550, gConcatenatedDataBinding.consultantApplicationForm.Address, 16.0f));         
                textForSecondPage.Add(new Tuple<float, float, string, float>(240, 550, gConcatenatedDataBinding.consultantApplicationForm.City, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(140, 550, gConcatenatedDataBinding.consultantApplicationForm.State, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(100, 515, gConcatenatedDataBinding.consultantApplicationForm.Zip, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(318, 513, gConcatenatedDataBinding.consultantApplicationForm.Email, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(200, 513, gConcatenatedDataBinding.consultantApplicationForm.CellPhone, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(70, 513, gConcatenatedDataBinding.consultantApplicationForm.Homephone, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(310, 483, gConcatenatedDataBinding.consultantApplicationForm.SecurityNo, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(310, 453, gConcatenatedDataBinding.consultantApplicationForm.CompanyName, 16.0f));
                               
                textForSecondPage.Add(new Tuple<float, float, string, float>(160, 450, guestDataModel.DateOfBirth, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(160, 415, guestDataModel.IDno, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(160, 385, guestDataModel.Expiry, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(160, 355, guestDataModel.Nationality, 16.0f));

                textForSecondPage.Add(new Tuple<float, float, string, float>(310, 383, gConcatenatedDataBinding.consultantApplicationForm.DateandPlaceofIssue, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(310,350, gConcatenatedDataBinding.consultantApplicationForm.PurposeOfVisit, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(310, 315, gConcatenatedDataBinding.consultantApplicationForm.Duration, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(100,315, gConcatenatedDataBinding.consultantApplicationForm.EmergencyContactNo, 16.0f));

                

                //confidentiality Agreement Form


                textForThirdPage.Add(new Tuple<float, float, string>(110, 710, guestDataModel.Name));
                textForThirdPage.Add(new Tuple<float, float, string>(110, 680, gConcatenatedDataBinding.CAforVisitor.Title));
                textForThirdPage.Add(new Tuple<float, float, string>(350, 680, gConcatenatedDataBinding.CAforVisitor.Company));
                textForThirdPage.Add(new Tuple<float, float, string>(400, 500, gConcatenatedDataBinding.CAforVisitor.Date));
            }
            else
            {
                //Text position for Qatar ID 
                //Consultant Application Form           
                textForSecondPage.Add(new Tuple<float, float, string, float>(390, 580, firstName, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(230, 580, scndName, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(70, 580, lastName, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(160, 450, guestDataModel.DateOfBirth, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(340, 415, guestDataModel.IDno, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(160, 385, guestDataModel.Expiry, 16.0f));
                                                         
                textForSecondPage.Add(new Tuple<float, float, string, float>(160, 355, guestDataModel.Nationality, 16.0f));


                textForSecondPage.Add(new Tuple<float, float, string, float>(340, 550, gConcatenatedDataBinding.consultantApplicationForm.Address, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(240, 550, gConcatenatedDataBinding.consultantApplicationForm.City, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(140, 550, gConcatenatedDataBinding.consultantApplicationForm.State, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(70, 528, gConcatenatedDataBinding.consultantApplicationForm.Zip, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(318, 513, gConcatenatedDataBinding.consultantApplicationForm.Email, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(200, 513, gConcatenatedDataBinding.consultantApplicationForm.CellPhone, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(70, 513, gConcatenatedDataBinding.consultantApplicationForm.Homephone, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(310, 483, gConcatenatedDataBinding.consultantApplicationForm.SecurityNo, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(310, 453, gConcatenatedDataBinding.consultantApplicationForm.CompanyName, 16.0f));

                textForSecondPage.Add(new Tuple<float, float, string, float>(310, 383, gConcatenatedDataBinding.consultantApplicationForm.DateandPlaceofIssue, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(310, 350, gConcatenatedDataBinding.consultantApplicationForm.PurposeOfVisit, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(310, 315, gConcatenatedDataBinding.consultantApplicationForm.Duration, 16.0f));
                textForSecondPage.Add(new Tuple<float, float, string, float>(100, 315, gConcatenatedDataBinding.consultantApplicationForm.EmergencyContactNo, 16.0f));


                //confidentiality Agreement For Contractors

                textForThirdPage.Add(new Tuple<float, float, string>(110, 710, guestDataModel.Name));
                textForThirdPage.Add(new Tuple<float, float, string>(110, 680, gConcatenatedDataBinding.CAforVisitor.Title));
                textForThirdPage.Add(new Tuple<float, float, string>(350, 680, gConcatenatedDataBinding.CAforVisitor.Company));
               textForThirdPage.Add(new Tuple<float, float, string>(400, 500, gConcatenatedDataBinding.CAforVisitor.Date));
            }
            // adding text



            
            outputFilePath = $"D:\\VisitorData\\GeneratedDocument\\C_{guestDataModel.IDno}__{DateTime.Now.ToString("ddMMyyyyHHmm")}.pdf";

            // Modify the PDF with the image and texts
            GeneratePDFdocument.ModifyPdf(inputFilePath, textForSecondPage, textForThirdPage, outputFilePath, imagePath, "contract",gScannedFileModel,guestDataModel);
        }
    }
}
