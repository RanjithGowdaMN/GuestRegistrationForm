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
        public void GenerateVisitorDocument(GuestDataModel guestDataModel, gScannedFileModel gScannedFileModel, gConcatenatedDataBinding gConcatenatedDataBinding, string inputFilePath,
                                            string outputFilePath, string imagePath)
        {
            inputFilePath = @"D:\VisitorData\BaseDocument\Visitor.pdf";
            DateTime currentDate = DateTime.Now;
          
            // confidentiality Agreement for visitors
            List<Tuple<float, float, string>> textsToAdd1 = new List<Tuple<float, float, string>>
            { 

            new Tuple<float, float, string>(110, 638, guestDataModel.Name),
            new Tuple<float, float, string>(110,608,gConcatenatedDataBinding.CAforVisitor.Title),
            new Tuple<float, float, string>(355,608,gConcatenatedDataBinding.CAforVisitor.Company),
            new Tuple<float, float, string>(400,440,gConcatenatedDataBinding.CAforVisitor.Date )
                           
            };

            //Visitors Data Sheet
            List<Tuple<float, float, string>> textsToAdd = new List<Tuple<float, float, string>>
            {
                new Tuple<float, float, string>(180, 645, guestDataModel.Name),
                new Tuple<float, float, string>(480,645,gConcatenatedDataBinding.visitorDataSheet.Date),
                new Tuple<float, float, string>(480, 600, guestDataModel.IDno),
                new Tuple<float, float, string>(480,550,guestDataModel.DateOfBirth),
                new Tuple<float, float, string>(480, 500,guestDataModel.Expiry),
                new Tuple<float, float, string>(480,453,guestDataModel.Nationality),
                new Tuple<float, float, string>(180,600,gConcatenatedDataBinding.visitorDataSheet.Company),
                new Tuple<float, float, string>(180,550,gConcatenatedDataBinding.visitorDataSheet.ReasonForVisit),
                new Tuple<float, float, string>(180,500,gConcatenatedDataBinding.visitorDataSheet.PersontobeVisited),
                new Tuple<float, float, string>(180,453,gConcatenatedDataBinding.visitorDataSheet.AreaVisited),
                new Tuple<float, float, string>(480,410,gConcatenatedDataBinding.visitorDataSheet.VisitDuration),
                new Tuple<float, float, string>(180,410,gConcatenatedDataBinding.visitorDataSheet.VisitDateTime),
                new Tuple<float, float, string>(180,373,gConcatenatedDataBinding.visitorDataSheet.DepartmentManager),
                new Tuple<float, float, string>(180,330,gConcatenatedDataBinding.visitorDataSheet.ProductionManager),
                new Tuple<float, float, string>(180,283,gConcatenatedDataBinding.visitorDataSheet.SecurityController)
                

                // To be add other data

            };


            outputFilePath = $"D:\\VisitorData\\GeneratedDocument\\V_{guestDataModel.IDno}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.pdf";

            // Modify the PDF with the image and texts
            GeneratePDFdocument.ModifyPdf(inputFilePath, textsToAdd1, textsToAdd, outputFilePath, imagePath, "visitor",gScannedFileModel,guestDataModel);
        }
    }
}
