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

           

            List<Tuple<float, float, string>> textForSecondPage = new List<Tuple<float, float, string>>();
            List<Tuple<float, float, string>> textForThirdPage = new List<Tuple<float, float, string>>();

            if (guestDataModel.IsPassport)
            {
                //Text position for Passport
               //consultant Application Form
                textForSecondPage.Add(new Tuple<float, float, string>(390, 580, firstName));
                textForSecondPage.Add(new Tuple<float, float, string>(230, 580, scndName));
                textForSecondPage.Add(new Tuple<float, float, string>(70, 580, lastName));
                textForSecondPage.Add(new Tuple<float, float, string>(340, 550, gConcatenatedDataBinding.consultantApplicationForm.Address));
                textForSecondPage.Add(new Tuple<float, float, string>(240, 550, gConcatenatedDataBinding.consultantApplicationForm.City));
                textForSecondPage.Add(new Tuple<float, float, string>(140, 550, gConcatenatedDataBinding.consultantApplicationForm.State));
                textForSecondPage.Add(new Tuple<float, float, string>(60, 545, gConcatenatedDataBinding.consultantApplicationForm.Zip));
                textForSecondPage.Add(new Tuple<float, float, string>(318, 513, gConcatenatedDataBinding.consultantApplicationForm.Email));
                textForSecondPage.Add(new Tuple<float, float, string>(200, 513, gConcatenatedDataBinding.consultantApplicationForm.CellPhone));
                textForSecondPage.Add(new Tuple<float, float, string>(70, 513, gConcatenatedDataBinding.consultantApplicationForm.Homephone));
                textForSecondPage.Add(new Tuple<float, float, string>(310, 483, gConcatenatedDataBinding.consultantApplicationForm.SecurityNo));
                textForSecondPage.Add(new Tuple<float, float, string>(310, 453, gConcatenatedDataBinding.consultantApplicationForm.CompanyName));
                               
                textForSecondPage.Add(new Tuple<float, float, string>(160, 450, guestDataModel.DateOfBirth));
                textForSecondPage.Add(new Tuple<float, float, string>(160, 415, guestDataModel.IDno));
                textForSecondPage.Add(new Tuple<float, float, string>(160, 385, guestDataModel.Expiry));
                textForSecondPage.Add(new Tuple<float, float, string>(160, 355, guestDataModel.Nationality));

                textForSecondPage.Add(new Tuple<float, float, string>(310, 383, gConcatenatedDataBinding.consultantApplicationForm.DateandPlaceofIssue));
                textForSecondPage.Add(new Tuple<float, float, string>(310,350, gConcatenatedDataBinding.consultantApplicationForm.PurposeOfVisit));
                textForSecondPage.Add(new Tuple<float, float, string>(310, 315, gConcatenatedDataBinding.consultantApplicationForm.Duration));
                textForSecondPage.Add(new Tuple<float, float, string>(100,315, gConcatenatedDataBinding.consultantApplicationForm.EmergencyContactNo));

                

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
                textForSecondPage.Add(new Tuple<float, float, string>(390, 580, firstName));
                textForSecondPage.Add(new Tuple<float, float, string>(230, 580, scndName));
                textForSecondPage.Add(new Tuple<float, float, string>(70, 580, lastName));
                textForSecondPage.Add(new Tuple<float, float, string>(160, 450, guestDataModel.DateOfBirth));
                textForSecondPage.Add(new Tuple<float, float, string>(340, 415, guestDataModel.IDno));
                textForSecondPage.Add(new Tuple<float, float, string>(160, 385, guestDataModel.Expiry));
                textForSecondPage.Add(new Tuple<float, float, string>(160, 355, guestDataModel.Nationality));

                textForSecondPage.Add(new Tuple<float, float, string>(340, 550, gConcatenatedDataBinding.consultantApplicationForm.Address));
                textForSecondPage.Add(new Tuple<float, float, string>(240, 550, gConcatenatedDataBinding.consultantApplicationForm.City));
                textForSecondPage.Add(new Tuple<float, float, string>(140, 550, gConcatenatedDataBinding.consultantApplicationForm.State));
                textForSecondPage.Add(new Tuple<float, float, string>(70, 528, gConcatenatedDataBinding.consultantApplicationForm.Zip));
                textForSecondPage.Add(new Tuple<float, float, string>(318, 513, gConcatenatedDataBinding.consultantApplicationForm.Email));
                textForSecondPage.Add(new Tuple<float, float, string>(200, 513, gConcatenatedDataBinding.consultantApplicationForm.CellPhone));
                textForSecondPage.Add(new Tuple<float, float, string>(70, 513, gConcatenatedDataBinding.consultantApplicationForm.Homephone));
                textForSecondPage.Add(new Tuple<float, float, string>(310, 483, gConcatenatedDataBinding.consultantApplicationForm.SecurityNo));
                textForSecondPage.Add(new Tuple<float, float, string>(310, 453, gConcatenatedDataBinding.consultantApplicationForm.CompanyName));

                textForSecondPage.Add(new Tuple<float, float, string>(310, 383, gConcatenatedDataBinding.consultantApplicationForm.DateandPlaceofIssue));
                textForSecondPage.Add(new Tuple<float, float, string>(310, 350, gConcatenatedDataBinding.consultantApplicationForm.PurposeOfVisit));
                textForSecondPage.Add(new Tuple<float, float, string>(310, 315, gConcatenatedDataBinding.consultantApplicationForm.Duration));
                textForSecondPage.Add(new Tuple<float, float, string>(100, 315, gConcatenatedDataBinding.consultantApplicationForm.EmergencyContactNo));


                //confidentiality Agreement For Contractors

                textForThirdPage.Add(new Tuple<float, float, string>(110, 710, guestDataModel.Name));
                textForThirdPage.Add(new Tuple<float, float, string>(110, 680, gConcatenatedDataBinding.CAforVisitor.Title));
                textForThirdPage.Add(new Tuple<float, float, string>(350, 680, gConcatenatedDataBinding.CAforVisitor.Company));
               textForThirdPage.Add(new Tuple<float, float, string>(400, 500, gConcatenatedDataBinding.CAforVisitor.Date));
            }
            // adding text

           


            outputFilePath = $"D:\\VisitorData\\GeneratedDocument\\C_{guestDataModel.IDno}_{DateTime.Now.ToString()}.pdf";

            // Modify the PDF with the image and texts
            GeneratePDFdocument.ModifyPdf(inputFilePath, textForSecondPage, textForThirdPage, outputFilePath, imagePath, "contract",gScannedFileModel,guestDataModel);
        }
    }
}
