namespace Tesseract.Library
{
    public interface ITesseractLib
    {
        string ProcessImageAndExtractText(string imagePath, int idType);
    }
}