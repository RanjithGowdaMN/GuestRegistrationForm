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
            string fullName = guestDataModel.Name;
            string[] nameParts = fullName.Split(' ');

            string firstName = nameParts[1];
            string scndName = nameParts[2];
            string lastName = string.Join(" ", nameParts.Skip(3));
            // adding text
            List<Tuple<float, float, string>> textsToAdd1 = new List<Tuple<float, float, string>>
            {

            new Tuple<float, float, string>(390, 580, firstName),
               new Tuple<float, float, string>(230, 580, scndName),
                new Tuple<float, float, string>(70, 580, lastName),
              /*  new Tuple<float, float, string>(340, 550, "ad"),
                new Tuple<float, float, string>(240, 550, "city"),
                new Tuple<float, float, string>(140, 550, "stste"),
                new Tuple<float, float, string>(70, 536, "zip"),
                new Tuple<float, float, string>(315, 513, "email"),
                new Tuple<float, float, string>(210, 513, "cell"),
                new Tuple<float, float, string>(80, 513, "tel"),
                new Tuple<float, float, string>(310, 483, "ss"),
                new Tuple<float, float, string>(110, 453, "cn"),*/
                new Tuple<float, float, string>(310, 415, guestDataModel.IDno),
              /*  new Tuple<float, float, string>(100, 415, "pn"),
                new Tuple<float, float, string>(310, 383, "pd"),
                new Tuple<float, float, string>(100, 383, "pv"),
                new Tuple<float, float, string>(210, 350, "purpos"),
                new Tuple<float, float, string>(310, 315, "dura"),
                new Tuple<float, float, string>(110, 315, "ec"),
                new Tuple<float, float, string>(110, 260, "ex"),*/

            };
            List<Tuple<float, float, string>> textsToAdd = new List<Tuple<float, float, string>>
            {
                new Tuple<float, float, string>(110, 710, guestDataModel.Name),
               // new Tuple<float, float, string>(310, 415, guestDataModel.IDno),
                //new Tuple<float, float, string>(350, 680,guestDataModel.Expiry),
                
                // To be add other data

            };

            outputFilePath = $"D:\\VisitorData\\GeneratedDocument\\V_{guestDataModel.Name}.pdf";

            // Modify the PDF with the image and texts
            GeneratePDFdocument.ModifyPdf(inputFilePath, textsToAdd1, textsToAdd, outputFilePath, imagePath);
        }
    }
}
