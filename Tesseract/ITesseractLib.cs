namespace Tesseract.Library
{
    public interface ITesseract
    {
        //string ExtractTextFromImage(string imagePath);

        string ExtractTxtFromImg(string imagePath, int id_Type);
    }
}