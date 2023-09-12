using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GenerateDocument.Library
{
    public class GenerateCardPrintDoc : IGenerateCardPrintDoc
    {
        public float cardWidth = 252.72f; //4 inches
        public float cardHeight = 153.09f; //2 inches

        public void printCard(string outputPath, string sppLogo, string imagePath,
                            string visitorName, string visitorNumber, string visitorType)
        {
            Document document = new Document(new Rectangle(cardWidth, cardHeight));

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));
            document.Open();

            if (String.IsNullOrEmpty(visitorName) || String.IsNullOrWhiteSpace(visitorName))
            {
                visitorName = "";
            }
            if (String.IsNullOrEmpty(visitorNumber) || String.IsNullOrWhiteSpace(visitorNumber))
            {
                visitorNumber = "00000";
            }
            // Create a content byte
            PdfContentByte contentByte = writer.DirectContent;
            // Draw a background color (light gray) for the entire card
            contentByte.SetColorFill(new BaseColor(250, 249, 246));
            // contentByte.Rectangle(0, 0, cardWidth, cardHeight);
            // contentByte.Fill();

            // Load the image
            if (String.IsNullOrEmpty(imagePath))
            {
                imagePath = "D:\\VisitorData\\Photos\\photo00001.jpg";
            }
            
                Image image = Image.GetInstance(imagePath);
                image.RotationDegrees = 270;
                image.ScaleToFit(150, 100);
          
           

            //Load the Logo

            iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(sppLogo);

            // image1.ScaleToFit(50, 750);
            float imageScalingFactor = .10f; // You can adjust this value as needed
            image1.ScaleToFit(image1.Width * imageScalingFactor, image1.Height * imageScalingFactor);

            // Position the image
            image.SetAbsolutePosition(10, 40);
           contentByte.AddImage(image);
            

            //position of Logo
            image1.SetAbsolutePosition(100, 120);
            contentByte.AddImage(image1);


            
            if (!(visitorType == "VISITOR"))
            {
                //type";
                contentByte.BeginText();
                BaseFont boldFont1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                contentByte.SetFontAndSize(boldFont1, 16);
                contentByte.SetColorFill(BaseColor.BLACK);
                contentByte.ShowTextAligned(Element.ALIGN_JUSTIFIED_ALL, visitorType, 120, 60, 0);
                contentByte.EndText();

                //idnumber;
                contentByte.BeginText();
                BaseFont boldFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                contentByte.SetFontAndSize(boldFont, 16);
                contentByte.SetColorFill(BaseColor.BLACK);
                contentByte.ShowTextAligned(Element.ALIGN_JUSTIFIED_ALL, visitorNumber, 150, 100, 0);
                contentByte.EndText();

                //name
                float fontSize = 10;
                BaseFont baseFont = BaseFont.CreateFont();
                contentByte.BeginText();
                bool textFits = false;
                while (!textFits && fontSize > 0)
                {
                    contentByte.SetFontAndSize(baseFont, fontSize);
                    float textWidth = baseFont.GetWidthPoint(visitorName, fontSize);
                    
                    if (textWidth <= cardWidth)
                    {
                        textFits = true;
                    }
                    else
                    {
                        fontSize -= 1; // Reduce font size if text exceeds maxWidth
                    }
                }
                float xPosition = 1;
                float yPosition = 25;
                // Center-align the text within the maxWidth
                float textX = xPosition + (cardWidth - baseFont.GetWidthPoint(visitorName, fontSize)) / 2;
                contentByte.SetColorFill(BaseColor.BLACK);
                contentByte.ShowTextAligned(Element.ALIGN_JUSTIFIED_ALL, visitorName, textX, yPosition, 0);
                contentByte.EndText();


                // Reset graphic state for full opacity
                contentByte.SetGState(new PdfGState() { FillOpacity = 60f });

                // Draw a brown color bar at the bottom
                contentByte.SetColorFill(new BaseColor(169, 104, 49)); // Brown color
                contentByte.Rectangle(0, 0, cardWidth, 20); // Adjust the height as needed
                contentByte.Fill();
            }

            else
            {
                //string text2 = "VISITOR";
                contentByte.BeginText();
                BaseFont boldFont1 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                contentByte.SetFontAndSize(boldFont1, 16);
                contentByte.SetColorFill(BaseColor.BLACK);
                contentByte.ShowTextAligned(Element.ALIGN_JUSTIFIED_ALL, visitorType, 140, 60, 0);
                contentByte.EndText();

                //idnumber";
                contentByte.BeginText();
                BaseFont boldFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                contentByte.SetFontAndSize(boldFont, 16);
                contentByte.SetColorFill(BaseColor.BLACK);
                contentByte.ShowTextAligned(Element.ALIGN_JUSTIFIED_ALL, visitorNumber, 150, 100, 0);
                contentByte.EndText();


                // Name
                float fontSize = 10;
                BaseFont baseFont = BaseFont.CreateFont();
                contentByte.BeginText();
                bool textFits = false;

                while (!textFits && fontSize > 0)
                {
                    contentByte.SetFontAndSize(baseFont, fontSize);
                    float textWidth = baseFont.GetWidthPoint(visitorName, fontSize);

                    if (textWidth <= cardWidth)
                    {
                        textFits = true;
                    }
                    else
                    {
                        fontSize -= 1; // Reduce font size if text exceeds maxWidth
                    }
                }

                float xPosition = 1;
                float yPosition = 25;

                // Center-align the text within the maxWidth
                float textX = xPosition + (cardWidth - baseFont.GetWidthPoint(visitorName, fontSize)) / 2;

                contentByte.SetColorFill(BaseColor.BLACK);
                contentByte.ShowTextAligned(Element.ALIGN_JUSTIFIED_ALL, visitorName, textX, yPosition, 0);
                contentByte.EndText();



                // Reset graphic state for full opacity
                contentByte.SetGState(new PdfGState() { FillOpacity = 60f });

                contentByte.SetColorFill(BaseColor.GRAY); //  color
                contentByte.Rectangle(0, 0, cardWidth, 20); // Adjust the height as needed
                contentByte.Fill();
            }

            // Close the document
            document.Close();

            //Console.WriteLine($"PDF created at {outputPath}");
        }
    }
}
