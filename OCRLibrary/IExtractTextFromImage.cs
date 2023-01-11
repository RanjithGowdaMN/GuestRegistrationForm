namespace OCRLibrary
{
    public interface IExtractTextFromImage
    {
        bool ReadImageBasic(string path);
        bool ReadImageForArabic(string path);
        bool ReadImageHighQualityScan(string path);
        bool ReadImageLowQualityScan(string path);
        bool SaveToText(string path, string text);
    }
}