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
            if (docType == "visitor")
            {
                GeneratePDFVisitorDoc generatePDFVisitorDoc = new GeneratePDFVisitorDoc();
                generatePDFVisitorDoc.GenerateVisitorDocument(guestDataModel, inputFilePath, outputFilePath, imagePath);
            }
            else if (docType == "contract")
            {
                GeneratePDfContractDoc generatePDfContractDoc = new GeneratePDfContractDoc();
                generatePDfContractDoc.GenerateContractDocument(guestDataModel, inputFilePath, outputFilePath, imagePath);
            }
            else
            {

            }
        }

        public static void ModifyPdf(string inputFilePath, List<Tuple<float, float, string>> textsToAdd1, List<Tuple<float, float, string>> textsToAdd,
                                string outputFilePath, string imagePath, string docType)
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
                    AddImageToPdf(pdfStamper, imagePath, docType);//targetPage);//, xPosition, yPosition, width, height);

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

        public static void AddTextToPdf(PdfStamper pdfStamper, List<Tuple<float, float, string>> textsToAdd)
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

        public static void AddTextToTargetPage(PdfStamper pdfStamper, List<Tuple<float, float, string>> textsToAdd1)
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

        public static void AddImageToPdf(PdfStamper pdfStamper, string imagePath, string docType)
        {
            try
            {

                int targetPage = 3;
               

                // Load the image
                Image image = Image.GetInstance(imagePath);
                if (docType == "contract")
                // Set the position and size of the image on the page
                {
                    image.SetAbsolutePosition(410, 632);
                    image.ScaleToFit(120, 200);
                }
                else
                {
                    image.SetAbsolutePosition(410, 662);
                    image.ScaleToFit(120, 120);

                }

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
