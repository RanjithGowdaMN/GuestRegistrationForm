using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateDocument.Library
{
    public class GeneratePDFVisitorDoc
    {
        public void GenerateVisitorDocument(GuestDataModel guestDataModel, string inputFilePath,
                                            string outputFilePath, string imagePath)
        {
            inputFilePath = @"D:\VisitorData\BaseDocument\Visitor.pdf";
            DateTime currentDate = DateTime.Now;
          
            // adding text for 3rd page
            List<Tuple<float, float, string>> textsToAdd1 = new List<Tuple<float, float, string>>
            {

            new Tuple<float, float, string>(110, 638, guestDataModel.Name),
            
                           
            };

            //adding text for 2nd page
            List<Tuple<float, float, string>> textsToAdd = new List<Tuple<float, float, string>>
            {
                new Tuple<float, float, string>(180, 645, guestDataModel.Name),
                new Tuple<float, float, string>(480,645,currentDate.ToString("dd/MM/yyyy")),
                new Tuple<float, float, string>(480, 600, guestDataModel.IDno),
                new Tuple<float, float, string>(480,550,guestDataModel.DateOfBirth),
                new Tuple<float, float, string>(480, 500,guestDataModel.Expiry),
                new Tuple<float, float, string>(480,453,guestDataModel.Nationality)
                
                // To be add other data

            };


            outputFilePath = $"D:\\VisitorData\\GeneratedDocument\\V_{guestDataModel.Name}.pdf";

            // Modify the PDF with the image and texts
            GeneratePDFdocument.ModifyPdf(inputFilePath, textsToAdd1, textsToAdd, outputFilePath, imagePath, "visitor");
        }
    }
}
