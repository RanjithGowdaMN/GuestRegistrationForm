
using Microsoft.Office.Interop.Word;

namespace GenerateDocument.Library
{
    public interface IGenerateWordDocument
    {
        void AddImageToWordDocument(Document doc, string imagePath);
        void AddTextToDocument(Document doc, string txt);
        void GenerateWordDoc(GuestDataModel visitorDataModel, string inputFilePath, string outputFilePath, string imagePath);
    }
}