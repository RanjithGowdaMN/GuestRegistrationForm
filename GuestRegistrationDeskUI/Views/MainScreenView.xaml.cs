using Caliburn.Micro;
using Ghostscript.NET.Rasterizer;
using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationDeskUI.Models;
using GuestRegistrationDeskUI.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Windows.Storage;

namespace GuestRegistrationDeskUI.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainScreenView : UserControl
    {
        PrinterSettings printerSettings = new PrinterSettings();

        private SimpleContainer _container;

        public MainScreenViewModel mainScreenViewModel { get; set; }
        public MainScreenView()
        {
            InitializeComponent();
            ScanIDBackSide.IsEnabled = false;

            

            //mainScreenViewModel = new MainScreenViewModel();

            //mainScreenViewModel.DocumentGeneratedEvent += this.SendDocumentToUI;
        }
        //public MainScreenView(SimpleContainer container)
        //{
        //    InitializeComponent();
        //    ScanIDBackSide.IsEnabled = false;
        //    //
        //    _container = container;

        //    mainScreenViewModel = _container.GetInstance<MainScreenViewModel>();

        //    DataContext = mainScreenViewModel;
        //    //LoadImage();
        //}
        public void LoadImage()
        {
            // Create a BitmapImage from the image path
            var image = new System.Windows.Media.Imaging.BitmapImage();
            image.BeginInit();
            image.UriSource = new System.Uri("D:\\VisitorData\\Photos\\photo00001.jpg");
            image.EndInit();

            VisitorPhoto.Source = image;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)rbPassport.IsChecked)
            {
                ScanIDBackSide.IsEnabled = false;
            }
            else
            {
                ScanIDBackSide.IsEnabled = true;
            }
            ClearFields();
        }
        public void ClearFields()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {

                Name.Text = string.Empty;
                IDNo.Text = string.Empty;
                DOB.Text = string.Empty;

                Expiry.Text = string.Empty;
                Nationality.Text = string.Empty;

                //txtVisitorsName.Text = string.Empty;
               // txtDate.Text = string.Empty;
                //txtCompany.Text = string.Empty;
                txtVisitorsIdNo.Text = string.Empty;
                txtReasonforVisit.Text = string.Empty;
                //txtPersontobeVisited.Text = string.Empty; replaced with cmb
                txtAreaVisited.Text = string.Empty;
                txtVisitDateTime.Text = string.Empty;
                txtVisitDuration.Text = string.Empty;
                txtDepartmentManager.Text = string.Empty;
                txtProductionManager.Text = string.Empty;
                txtSecurityController.Text = string.Empty;
                //txtName.Text = string.Empty;
                txtTitle.Text = string.Empty;
                txtCompany1.Text = string.Empty;
                //txtDate1.Text = string.Empty;
                txtIdDateofIssue.Text = string.Empty;
                txtPlaceofIssue.Text = string.Empty;
                txtVisitorName.Text = string.Empty;
                txtBadgeNo.Text = string.Empty;
                txtPurposeOfvisit.Text = string.Empty;
                txtDate2.Text = string.Empty;
                txtArrivalTime.Text = string.Empty;
                txtDepartureTime.Text = string.Empty;
                txtEmployeeName.Text = string.Empty;
                txtVisitorName1.Text = string.Empty;
                txtPurposeVisit.Text = string.Empty;
                txtBadgeNo1.Text = string.Empty;
                txtDate3.Text = string.Empty;
                txtArrivalTime1.Text = string.Empty;
                txtDepartureTime1.Text = string.Empty;
                //txtFirstName.Text = string.Empty;
                //txtMiddleName.Text = string.Empty;
                //txtLastName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtCity.Text = string.Empty;
                txtState.Text = string.Empty;
                txtZip.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtCellPhone.Text = string.Empty;
                txtHomePhone.Text = string.Empty;
                txtSecurityNo.Text = string.Empty;
                txtCompanyName.Text = string.Empty;
                txtIdNo.Text = string.Empty;
                txtPassportNo.Text = string.Empty;
                txtDateandPlaceofIssue.Text = string.Empty;
                txtPassportValidty.Text = string.Empty;
                txtPurposeOfVisit1.Text = string.Empty;
                txtDuration.Text = string.Empty;
                txtEmergencyContactNo.Text = string.Empty;
            });
        }

        private void PrintVisitorIdCard_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void PrintContractIdCard_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ScanIDCard_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void VisitorCompanyName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbPrinterSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            printerSettings.PrinterName = cmbPrinterSelection.SelectedItem.ToString();
            //SendDocumentToUI();
        }

        private void GenerateTempBadge_Click(object sender, RoutedEventArgs e)
        {
           // var printDialog1 = new PrintDialog();

            PrintDocument printDialog = new PrintDocument() 
            { DocumentName = "D:/Visi.pdf" };
            printDialog.Print();

            //if (printDialog.ShowDialog() == MessageBox.Show()
            //{
            //    printDialog.PrintDocument.Print();
            //}
        }

        private void DepartmentNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //EmpToBeVisited.ItemsSource = ""

            string jsonFilePath = "D:\\VisitorData\\Data\\DataConfiguration.json"; // Provide the path to your JSON file
            string jsonData = File.ReadAllText(jsonFilePath);

            var cmdData = JsonConvert.DeserializeObject<UIbindingModel>(jsonData);

            PropertyInfo pinfo = typeof(UIbindingModel).GetProperty(DepartmentNames.SelectedItem.ToString());
            EmpToBeVisited.ItemsSource = (List<string>)pinfo.GetValue(cmdData, null);

           
        }

        public void SendDocumentToUI(object obj, string fileName)
        {
            //// imageContainer.Children.Add();
            //// Specify the path to the input PDF file
            //string inputPdfPath = "D:\\VisitorData\\GeneratedDocument\\V_ANSAR GADDAFI BADARUDEEN Kerala.pdf";

            //// Specify the output directory where the image will be saved
            ////string outputDirectory = "output/";

            //// Create the output directory if it doesn't exist
            ////Directory.CreateDirectory(outputDirectory);

            //// Initialize Ghostscript.NET rasterizer
            //GhostscriptRasterizer rasterizer = new GhostscriptRasterizer();


            //try
            //{
            //    // Open the PDF file
            //    rasterizer.Open(inputPdfPath);
            //    Bitmap[] bitmaps = new Bitmap[rasterizer.PageCount];
            //    // Loop through each page in the PDF
            //    for (int pageNumber = 1; pageNumber <= rasterizer.PageCount; pageNumber++)
            //    {
            //        bitmaps[pageNumber - 1] = (Bitmap)rasterizer.GetPage(300, pageNumber);
            //        // Render the page to a System.Drawing.Bitmap
            //        //using (Bitmap bitmap = (Bitmap)rasterizer.GetPage(300, pageNumber))
            //        //{

            //        //    // Specify the output image file path (e.g., output/page1.png)
            //        //    string outputImagePath = Path.Combine(outputDirectory, $"page{pageNumber}.png");

            //        //    // Save the bitmap as an image file
            //        //    bitmap.Save(outputImagePath, System.Drawing.Imaging.ImageFormat.Png);
            //        //}
            //    }

            //    foreach (Bitmap bitmap in bitmaps)
            //    {
            //        // Convert System.Drawing.Bitmap to System.Windows.Media.Imaging.BitmapImage
            //        BitmapImage bitmapImage = new BitmapImage();

            //        using (System.IO.MemoryStream memory = new System.IO.MemoryStream())
            //        {
            //            bitmap.Save(memory, ImageFormat.Png);
            //            memory.Position = 0;

            //            bitmapImage.BeginInit();
            //            bitmapImage.StreamSource = memory;
            //            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            //            bitmapImage.EndInit();
            //        }

            //        // Create an Image control and set its source to the BitmapImage
            //        System.Windows.Controls.Image imageControl = new System.Windows.Controls.Image();
            //        imageControl.Source = bitmapImage;
            //        imageContainer.Children.Add(imageControl);
            //        // Add the Image control to ;the StackPanel
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //Console.WriteLine("Error: " + ex.Message);
            //}
            //finally
            //{
            //    // Clean up resources
            //    rasterizer.Close();
            //}
        }
    }
}
