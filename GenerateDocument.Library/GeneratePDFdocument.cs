using System;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GenerateDocument.Library
{
    public class GeneratePDFdocument : IGeneratePDFdocument
    {
        public void GeneratePdfDoc(GuestDataModel guestDataModel, string inputFilePath,
                                    string outputFilePath, string imagePath, string docType)
        {
            inputFilePath = @"D:\VisitorData\BaseDocument\Contractor.pdf";
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

            outputFilePath = $"D:\\VisitorData\\GeneratedDocument\\Visotor_{guestDataModel.IDno}.pdf";

            // Modify the PDF with the image and texts
            ModifyPdf(inputFilePath, textsToAdd1, textsToAdd, outputFilePath, imagePath);
        }

        private void ModifyPdf(string inputFilePath, List<Tuple<float, float, string>> textsToAdd1, List<Tuple<float, float, string>> textsToAdd,
                                string outputFilePath, string imagePath)
        {
            // Check if the PDF and image files exist
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("PDF or image file not found.");
                return;
            }

            try
            {
                using (FileStream pdfFile = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
                using (FileStream outputPdfFile = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                {
                    // Create a PdfReader to read the original PDF
                    PdfReader pdfReader = new PdfReader(pdfFile);

                    // Create a PdfStamper to modify the PDF
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, outputPdfFile);

                    // Add image to PDF
                    AddImageToPdf(pdfStamper, imagePath);//targetPage);//, xPosition, yPosition, width, height);

                    // Add texts to PDF
                    AddTextToTargetPage(pdfStamper, textsToAdd1);

                    // Add texts to PDF
                    AddTextToPdf(pdfStamper, textsToAdd);

                    // Close the PdfStamper and PdfReader
                    pdfStamper.Close();
                    pdfReader.Close();
                }

                Console.WriteLine("Modified PDF saved to: " + outputFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private void AddTextToPdf(PdfStamper pdfStamper, List<Tuple<float, float, string>> textsToAdd)
        {
            try
            {
                int targetPge = 2;

                // Get the target page content
                PdfContentByte content = pdfStamper.GetOverContent(targetPge);

                // Add text to the target page
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                content.BeginText();
                content.SetFontAndSize(bf, 8);

                foreach (var text in textsToAdd)
                {
                    content.SetTextMatrix(text.Item1, text.Item2);
                    content.ShowText(text.Item3);
                }

                content.EndText();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding texts: " + ex.Message);
            }
        }

       private void AddTextToTargetPage(PdfStamper pdfStamper, List<Tuple<float, float, string>> textsToAdd1)
        {
            try
            {
                int targetPage = 3;

                // Get the target page content
                PdfContentByte content = pdfStamper.GetOverContent(targetPage);

                // Add text to the target page
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                content.BeginText();
                content.SetFontAndSize(bf, 8);

                foreach (var text in textsToAdd1)
                {
                    content.SetTextMatrix(text.Item1, text.Item2);
                    content.ShowText(text.Item3);
                }

                content.EndText();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding texts: " + ex.Message);
            }
        }

        private void AddImageToPdf(PdfStamper pdfStamper, string imagePath)
        {
            try
            {
                int targetPage = 3;
                // Load the image
                Image image = Image.GetInstance(imagePath);

                // Set the position and size of the image on the page
                image.SetAbsolutePosition(410, 632);
                image.ScaleToFit(120, 120);

                // Get the number of pages in the PDF
                int pageCount = pdfStamper.Reader.NumberOfPages;

                // Check if the target page is within the valid range
                if (targetPage > 0 && targetPage <= pageCount)
                {
                    // Get the target page content
                    PdfContentByte content = pdfStamper.GetOverContent(targetPage);

                    // Add the image to the target page
                    content.AddImage(image);
                }
                else
                {
                    Console.WriteLine("Target page is out of range.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the image: " + ex.Message);
            }
        }
    }
}
