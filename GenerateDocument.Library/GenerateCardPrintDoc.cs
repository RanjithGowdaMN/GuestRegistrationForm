using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GenerateDocument.Library
{
    public class GenerateCardPrintDoc : IGenerateCardPrintDoc
    {
        public float cardWidth = 244; //4 inches
        public float cardHeight = 155; //2 inches

        public void printCard(string outputPath, string sppLogo, string imagePath,
                            string visitorName, string visitorNumber, string visitorType)
        {
            Document document = new Document(new Rectangle(cardWidth, cardHeight));

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));
            document.Open();

            // Create a content byte
            PdfContentByte contentByte = writer.DirectContent;
            // Draw a background color (light gray) for the entire card
            contentByte.SetColorFill(new BaseColor(250, 249, 246));
            contentByte.Rectangle(0, 0, cardWidth, cardHeight);
            contentByte.Fill();

            // Load the image
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);
            image.ScaleToFit(80, 80);
            iTextSharp.text.Image image1 = iTextSharp.text.Image.GetInstance(sppLogo);

            // image1.ScaleToFit(50, 750);
            float imageScalingFactor = .10f; // You can adjust this value as needed
            image1.ScaleToFit(image1.Width * imageScalingFactor, image1.Height * imageScalingFactor);

            // Position the image
            image.SetAbsolutePosition(3, 30);
            contentByte.AddImage(image);

            image1.SetAbsolutePosition(10, 120);
            contentByte.AddImage(image1);


            int a = 1;
            if (a == 1)
            {
                //string text2 = "CONTRACTOR";
                contentByte.BeginText();
                contentByte.SetFontAndSize(BaseFont.CreateFont(), 10); // You can customize the font and size
                contentByte.SetColorFill(BaseColor.BLACK);
                contentByte.ShowTextAligned(Element.ALIGN_JUSTIFIED_ALL, visitorType, 90, 82, 0);
                contentByte.EndText();

                //string text3 = "001";
                contentByte.BeginText();
                contentByte.SetFontAndSize(BaseFont.CreateFont(), 10); // You can customize the font and size
                contentByte.SetColorFill(BaseColor.BLACK);
                contentByte.ShowTextAligned(Element.ALIGN_JUSTIFIED_ALL, visitorNumber, 90, 62, 0);
                contentByte.EndText();

                // Add text content
                //string text1 = "Sachin Ramesh Tendulkar Cricket";
                contentByte.BeginText();
                contentByte.SetFontAndSize(BaseFont.CreateFont(), 10); // You can customize the font and size
                contentByte.SetColorFill(BaseColor.BLACK);
                contentByte.ShowTextAligned(Element.ALIGN_JUSTIFIED_ALL, visitorName, 90, 102, 0);
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
                contentByte.SetFontAndSize(BaseFont.CreateFont(), 10); // You can customize the font and size
                contentByte.SetColorFill(BaseColor.BLACK);
                contentByte.ShowTextAligned(Element.ALIGN_JUSTIFIED_ALL, visitorType, 90, 82, 0);
                contentByte.EndText();

                //string text3 = "001";
                contentByte.BeginText();
                contentByte.SetFontAndSize(BaseFont.CreateFont(), 10); // You can customize the font and size
                contentByte.SetColorFill(BaseColor.BLACK);
                contentByte.ShowTextAligned(Element.ALIGN_JUSTIFIED_ALL, visitorNumber, 90, 62, 0);
                contentByte.EndText();

                // Add text content
                //string text1 = "Sachin Ramesh Tendulkar Cricket";
                contentByte.BeginText();
                contentByte.SetFontAndSize(BaseFont.CreateFont(), 10); // You can customize the font and size
                contentByte.SetColorFill(BaseColor.BLACK);
                contentByte.ShowTextAligned(Element.ALIGN_JUSTIFIED_ALL, visitorName, 90, 102, 0);
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
