namespace GuestRegistrationDesktopUI.Library.OCR
{
    public interface IOCRhelper
    {
        string ExtractText(string imagePath, int IdType);
    }
}