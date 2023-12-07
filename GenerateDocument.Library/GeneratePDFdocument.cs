using System;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GuestRegistrationDesktopUI.Library.Models;

namespace GenerateDocument.Library
{
    public class GeneratePDFdocument : IGeneratePDFdocument
    {
        public string  GeneratePdfDoc(GuestDataModel guestDataModel, gScannedFileModel gScannedFileModel, gConcatenatedDataBinding gConcatenatedDataBinding, string inputFilePath,
                                    string outputFilePath, string imagePath, string docType)
        {
            if (docType == "visitor")
            {
                GeneratePDFVisitorDoc generatePDFVisitorDoc = new GeneratePDFVisitorDoc();
                return generatePDFVisitorDoc.GenerateVisitorDocument(guestDataModel, gScannedFileModel, gConcatenatedDataBinding, inputFilePath, outputFilePath, imagePath);
            }
            else if (docType == "contractor")
            {
                GeneratePDfContractDoc generatePDfContractDoc = new GeneratePDfContractDoc();
                return generatePDfContractDoc.GenerateContractDocument(guestDataModel, gScannedFileModel, gConcatenatedDataBinding, inputFilePath, outputFilePath, imagePath);
            }
            else
            {
                return "";
            }
        }

        public static void ModifyPdf(string inputFilePath, List<Tuple<float, float, string>> textsToAdd1, List<Tuple<float, float, string>> textsToAdd,
                                string outputFilePath, string imagePath, string docType,gScannedFileModel gScannedFileModel,GuestDataModel guestDataModel)
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
                  

                    //Add Scanned images
                    AddImageToPdf(pdfStamper, gScannedFileModel, docType, guestDataModel);

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
                content.SetFontAndSize(bf,8);

                foreach (var text in textsToAdd)
                {
                   
                    if (text.Item3 != null)
                    {
                        //     text.Item3.ToUpper();
                        string uppercaseText = text.Item3.ToUpper();
                        content.SetTextMatrix(text.Item1, text.Item2);
                        content.ShowText(uppercaseText);
                    }
                    else
                    {
                        content.ShowText("");
                    }
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

                    if (!string.IsNullOrEmpty(text.Item3))
                    {
                        string uppercaseText = text.Item3.ToUpper();
                        content.SetTextMatrix(text.Item1, text.Item2);
                        // text.Item3.ToUpper();
                        content.ShowText(uppercaseText);
                    }
                    else
                    {
                        content.ShowText("");
                    }
                    
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
                   //image.RotationDegrees = 270;
                    image.SetAbsolutePosition(440, 632);
                    image.ScaleToFit(100, 100);
                }
                else
                {
                    //image.RotationDegrees = 270;
                    image.SetAbsolutePosition(470, 662);
                    image.ScaleToFit(120, 80);

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


        public static void AddImageToPdf(PdfStamper pdfStamper, gScannedFileModel gScannedFileModel, string docType,GuestDataModel guestDataModel)
        {
            try
            {


                if (guestDataModel.IsPassport)
                {

                    if (docType == "contract")
                    {
                        int targetPage1 = 2;


                        // Load the image of front
                        Image image1 = Image.GetInstance(gScannedFileModel.FrontSideFileName);

                        image1.SetAbsolutePosition(100, 32);
                        image1.ScaleToFit(350, 280);



                        // Get the number of pages in the PDF
                        int pageCount1 = pdfStamper.Reader.NumberOfPages;

                        // Check if the target page is within the valid range
                        if (targetPage1 > 0 && targetPage1 <= pageCount1)
                        {
                            // Get the target page content
                            PdfContentByte content = pdfStamper.GetOverContent(targetPage1);

                            // Add the image to the target page
                            content.AddImage(image1);
                        }
                        else
                        {
                            Console.WriteLine("Target page is out of range.");
                        }

                    }
                    else if(docType=="visitor")

                    {
                        int targetPage12 = 3;


                        // Load the image of front
                        Image image1 = Image.GetInstance(gScannedFileModel.FrontSideFileName);

                        image1.SetAbsolutePosition(100, 22);
                        image1.ScaleToFit(350, 280);



                        // Get the number of pages in the PDF
                        int pageCount1 = pdfStamper.Reader.NumberOfPages;

                        // Check if the target page is within the valid range
                        if (targetPage12 > 0 && targetPage12 <= pageCount1)
                        {
                            // Get the target page content
                            PdfContentByte content = pdfStamper.GetOverContent(targetPage12);

                            // Add the image to the target page
                            content.AddImage(image1);
                        }
                        else
                        {
                            Console.WriteLine("Target page is out of range.");
                        }

                    }

                }
                else
                {
                    if (docType == "contract")

                    {

                        int targetPage = 2;


                        // Load the image of front
                        Image image = Image.GetInstance(gScannedFileModel.FrontSideFileName);

                        image.SetAbsolutePosition(30, 102);
                        image.ScaleToFit(250, 150);

                        //Load the image of back
                        Image img = Image.GetInstance(gScannedFileModel.BackSideFileName);
                        img.SetAbsolutePosition(300, 102);
                        img.ScaleToFit(250, 150);


                        // Get the number of pages in the PDF
                        int pageCount = pdfStamper.Reader.NumberOfPages;

                        // Check if the target page is within the valid range
                        if (targetPage > 0 && targetPage <= pageCount)
                        {
                            // Get the target page content
                            PdfContentByte content = pdfStamper.GetOverContent(targetPage);

                            // Add the image to the target page
                            content.AddImage(image);
                            content.AddImage(img);
                        }
                        else
                        {
                            Console.WriteLine("Target page is out of range.");
                        }
                    }
                   
                    else if(docType=="visitor")
                    {
                        int targetPage = 3;


                        // Load the image of front
                        Image image = Image.GetInstance(gScannedFileModel.FrontSideFileName);

                        image.SetAbsolutePosition(10, 102);
                        image.ScaleToFit(250, 150);

                        //Load the image of back
                        Image img = Image.GetInstance(gScannedFileModel.BackSideFileName);
                        img.SetAbsolutePosition(300, 102);
                        img.ScaleToFit(250, 150);


                        // Get the number of pages in the PDF
                        int pageCount = pdfStamper.Reader.NumberOfPages;

                        // Check if the target page is within the valid range
                        if (targetPage > 0 && targetPage <= pageCount)
                        {
                            // Get the target page content
                            PdfContentByte content = pdfStamper.GetOverContent(targetPage);

                            // Add the image to the target page
                            content.AddImage(image);
                            content.AddImage(img);
                        }
                        else
                        {
                            Console.WriteLine("Target page is out of range.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the image: " + ex.Message);
            }
        }
    }
}
