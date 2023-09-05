namespace GenerateDocument.Library
{
    public interface IGenerateCardPrintDoc
    {
        void printCard(string outputPath, string sppLogo, string imagePath, string visitorName, string visitorNumber, string visitorType);
    }
}