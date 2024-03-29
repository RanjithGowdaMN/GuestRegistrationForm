﻿using GuestRegistrationDesktopUI.Library.Models;

namespace GenerateDocument.Library
{
    public interface IGeneratePDFdocument
    {
        string GeneratePdfDoc(GuestDataModel guestDataModel, gScannedFileModel gScannedFileModel, gConcatenatedDataBinding gConcatenatedDataBinding, string inputFilePath, string outputFilePath, string imagePath, string docType);
    }
}