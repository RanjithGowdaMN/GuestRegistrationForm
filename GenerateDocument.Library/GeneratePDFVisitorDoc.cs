using GuestRegistrationDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateDocument.Library
{
    public class GeneratePDFVisitorDoc
    {
        public string GenerateVisitorDocument(GuestDataModel guestDataModel, gScannedFileModel gScannedFileModel, gConcatenatedDataBinding gConcatenatedDataBinding, string inputFilePath,
                                            string outputFilePath, string imagePath)
        {
            inputFilePath = @"D:\VisitorData\BaseDocument\Visitor.pdf";
            DateTime currentDate = DateTime.Now;

            // confidentiality Agreement for visitors
            List<Tuple<float, float, string>> textsToAdd1 = new List<Tuple<float, float, string>>
             {

             new Tuple<float, float, string>(105, 638, guestDataModel.Name),
             new Tuple<float, float, string>(100,603,gConcatenatedDataBinding.visitorDataSheet.Title),
             new Tuple<float, float, string>(355,603,gConcatenatedDataBinding.visitorDataSheet.Company),
             new Tuple<float, float, string>(400,430,DateTime.Now.ToString("dd-MM-yyyy")),

             };



            //Visitors Data Sheet
            List<Tuple<float, float, string>> textsToAdd = new List<Tuple<float, float, string>>
            {
                new Tuple<float, float, string>(182, 645, guestDataModel.Name),
                new Tuple<float, float, string>(470,645,DateTime.Now.ToString("dd-MM-yyyy")),
                new Tuple<float, float, string>(470, 597, guestDataModel.IDno),
                new Tuple<float, float, string>(470,550,guestDataModel.DateOfBirth),
                new Tuple<float, float, string>(470, 500,guestDataModel.Expiry),
                new Tuple<float, float, string>(470,453,guestDataModel.Nationality),
                new Tuple<float, float, string>(182,597,gConcatenatedDataBinding.visitorDataSheet.Company),
                new Tuple<float, float, string>(182,550,gConcatenatedDataBinding.visitorDataSheet.ReasonForVisit),
                new Tuple<float, float, string>(182,503,gConcatenatedDataBinding.visitorDataSheet.PersontobeVisited),
                new Tuple<float, float, string>(182,455,gConcatenatedDataBinding.visitorDataSheet.AreaVisited),
                new Tuple<float, float, string>(470,410,gConcatenatedDataBinding.visitorDataSheet.VisitDuration),
                new Tuple<float, float, string>(182,410,gConcatenatedDataBinding.visitorDataSheet.VisitDateTime),
                new Tuple<float, float, string>(182,370,gConcatenatedDataBinding.visitorDataSheet.DepartmentManager),
                new Tuple<float, float, string>(182,326,gConcatenatedDataBinding.visitorDataSheet.ProductionManager),
                new Tuple<float, float, string>(182,280,gConcatenatedDataBinding.visitorDataSheet.SecurityController)
                

                // To be add other data

            };


            outputFilePath = $"D:\\VisitorData\\GeneratedDocument\\V_{guestDataModel.IDno}_{DateTime.Now.ToString("ddMMyyyyHHmm")}.pdf";

            // Modify the PDF with the image and texts
            GeneratePDFdocument.ModifyPdf(inputFilePath, textsToAdd1, textsToAdd, outputFilePath, imagePath, "visitor",gScannedFileModel,guestDataModel);

            return outputFilePath;
        }
    }
}
