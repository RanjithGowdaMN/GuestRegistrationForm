using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateDocument.Library
{
    public class GeneratePDfContractDoc
    {
        public void GenerateContractDocument(GuestDataModel guestDataModel, string inputFilePath,
                                            string outputFilePath, string imagePath)
        {
            inputFilePath = @"D:\VisitorData\BaseDocument\Contractor.pdf";


            string fullName = guestDataModel.Name;
            string[] nameParts = fullName.Split(' ');

            string firstName = nameParts[1];
            string scndName = nameParts[2];
            string lastName = string.Join(" ", nameParts.Skip(3));

            List<Tuple<float, float, string>> textForSecondPage = new List<Tuple<float, float, string>>();
            List<Tuple<float, float, string>> textForThirdPage = new List<Tuple<float, float, string>>();

            if (guestDataModel.IsPassport)
            {
                //Text position for Passport
                textForSecondPage.Add(new Tuple<float, float, string>(390, 580, firstName));
                textForSecondPage.Add(new Tuple<float, float, string>(230, 580, scndName));
                textForSecondPage.Add(new Tuple<float, float, string>(70, 580, lastName));
                textForSecondPage.Add(new Tuple<float, float, string>(210, 415, guestDataModel.IDno));

                textForThirdPage.Add(new Tuple<float, float, string>(110, 710, guestDataModel.Name));
            }
            else
            {
                //Text position for Qatar ID 
                textForSecondPage.Add(new Tuple<float, float, string>(390, 580, firstName));
                textForSecondPage.Add(new Tuple<float, float, string>(230, 580, scndName));
                textForSecondPage.Add(new Tuple<float, float, string>(70, 580, lastName));
                textForSecondPage.Add(new Tuple<float, float, string>(310, 415, guestDataModel.IDno));

                textForThirdPage.Add(new Tuple<float, float, string>(110, 710, guestDataModel.Name));
            }
            // adding text


            outputFilePath = $"D:\\VisitorData\\GeneratedDocument\\C_{guestDataModel.Name}_{guestDataModel.IDno}.pdf";

            // Modify the PDF with the image and texts
            GeneratePDFdocument.ModifyPdf(inputFilePath, textForSecondPage, textForThirdPage, outputFilePath, imagePath, "contract");
        }
    }
}
