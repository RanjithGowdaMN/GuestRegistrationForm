using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using WordDocument = Microsoft.Office.Interop.Word.Document;
namespace GenerateDocument.Library
{
    public class GenerateWordDocument : IGenerateWordDocument
    {
        public void GenerateWordDoc(GuestDataModel guestDataModel,  string inputFilePath,
                                    string outputFilePath, string imagePath)
        {
            inputFilePath = @"D:\VisitorData\BaseDocument\visitors1.docx"; // Path to the input Word document
            outputFilePath = @"D:\VisitorData\GeneratedDocument\visit1.docx"; // Path to save the modified Word document
            //imagePath = @"E:\misnad\imgevisit\Sachin.jpg"; // Path to the image file
                                        //    int pageNumber=2;
            string txt = "sachin";

            Word.Application wordApp = new Word.Application();

            // Open the existing Word document
            

            WordDocument doc = wordApp.Documents.Open(inputFilePath);

            AddImageToWordDocument(doc, imagePath);
            AddTextToDocument(doc, txt);
            doc.SaveAs2(outputFilePath);
            Console.WriteLine("Image added to Word document.");
            Console.ReadLine();
        }

        public void AddImageToWordDocument(Word.Document doc, string imagePath)
        {
            // Create an instance of the Word application
            //  Word.Application wordApp = new Word.Application();

            // Open the existing Word document
            //WordDocument doc = wordApp.Documents.Open(inputFilePath);

            // Get the first paragraph in the document
            Paragraph firstParagraph = doc.Paragraphs[159];
            firstParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

            // Set the image width and height
            float imageWidth = 100; // Specify the desired width of the image
            float imageHeight = 100; // Specify the desired height of the image
            InlineShape imageShape = firstParagraph.Range.InlineShapes.AddPicture(imagePath, LinkToFile: false, SaveWithDocument: true);
            imageShape.Width = imageWidth;
            imageShape.Height = imageHeight;
            // Add the image to the first paragraph

            //     doc.SaveAs2(outputFilePath);
            // Close the document and the Word application
            //doc.Close();
            //wordApp.Quit();
        }

        public void AddTextToDocument(Microsoft.Office.Interop.Word.Document doc, string txt)
        {

            Microsoft.Office.Interop.Word.Paragraph name = doc.Paragraphs[161];
            // Word.Page targetpage = doc.Pages(2);

            Microsoft.Office.Interop.Word.Range textRange = name.Range;

            textRange.InsertAfter(txt);
            textRange.Font.Size = 12;
            textRange.Font.Name = "Arial";

        }
    }
}
