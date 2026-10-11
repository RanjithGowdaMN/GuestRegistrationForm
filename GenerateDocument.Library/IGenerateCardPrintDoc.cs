using GuestRegistrationDesktopUI.Library.Models;

namespace GenerateDocument.Library

{
    public interface IGenerateCardPrintDoc
    {
        string printCard(string outputPath, string sppLogo, string imagePath, string visitorName, string visitorNumber, string visitorType,gConcatenatedDataBinding concatenatedDataBinding );
    }
}