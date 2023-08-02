namespace GenerateDocument.Library
{
    public interface IGeneratePDFdocument
    {
        void GeneratePdfDoc(GuestDataModel guestDataModel, string inputFilePath, string outputFilePath, string imagePath);
    }
}