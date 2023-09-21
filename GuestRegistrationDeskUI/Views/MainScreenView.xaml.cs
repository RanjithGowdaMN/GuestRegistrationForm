using Ghostscript.NET.Rasterizer;
using GuestRegistrationDeskUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GuestRegistrationDeskUI.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainScreenView : UserControl
    {
        PrinterSettings printerSettings = new PrinterSettings();

        public MainScreenView() 
        {
            InitializeComponent();
            ScanIDBackSide.IsEnabled = false;
        }

        public void LoadImage()
        {
            // Create a BitmapImage from the image path
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(CONSTANTS.DEFAULT_PHOTO);
            image.EndInit();

            VisitorPhoto.Source = image;
        }
        private void FormName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SendDocumentToUI(DocumentNameDummy.Text);
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
                //txtReasonforVisit.Text = string.Empty;
                //txtPersontobeVisited.Text = string.Empty; replaced with cmb
                //txtAreaVisited.Text = string.Empty;
                txtVisitDateTime.Text = string.Empty;
                txtVisitDuration.Text = string.Empty;
                //txtDepartmentManager.Text = string.Empty;
                //txtProductionManager.Text = string.Empty;
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
            if (string.IsNullOrEmpty(printerSettings.PrinterName))
            {
                // Handle the case where no printer is selected
                MessageBox.Show("Please select a printer before printing.");
                return;
            }

            if (string.IsNullOrEmpty(DocumentNameDummy.Text))
            {
                // Handle the case where no printer is selected
                MessageBox.Show("Please generate document before printing.");
                return;
            }

            ProcessStartInfo psi = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                Verb = "printto",
                FileName = DocumentNameDummy.Text,
                Arguments = "\"" + printerSettings.PrinterName + "\""
            };

            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
            if (p.HasExited)
            {
                p.Kill();
            }

        }
        private void DepartmentNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //EmpToBeVisited.ItemsSource = ""

            string jsonFilePath = CONSTANTS.CONFIGURATION_FILE;
            string jsonData = File.ReadAllText(jsonFilePath);

            var cmdData = JsonConvert.DeserializeObject<UIbindingModel>(jsonData);

            PropertyInfo pinfo = typeof(UIbindingModel).GetProperty(DepartmentNames.SelectedItem.ToString());
            EmpToBeVisited.ItemsSource = (List<string>)pinfo.GetValue(cmdData, null);
        }

        public void SendDocumentToUI(string inputPdfPath)
        {
            GhostscriptRasterizer rasterizer = new GhostscriptRasterizer();
            try
            {
                // Open the PDF file
                rasterizer.Open(inputPdfPath);
                Bitmap[] bitmaps = new Bitmap[rasterizer.PageCount];
                // Loop through each page in the PDF
                for (int pageNumber = 1; pageNumber <= rasterizer.PageCount; pageNumber++)
                {
                    bitmaps[pageNumber - 1] = (Bitmap)rasterizer.GetPage(300, pageNumber);
                }

                foreach (Bitmap bitmap in bitmaps)
                {
                    // Convert System.Drawing.Bitmap to System.Windows.Media.Imaging.BitmapImage
                    BitmapImage bitmapImage = new BitmapImage();

                    using (MemoryStream memory = new MemoryStream())
                    {
                        bitmap.Save(memory, ImageFormat.Png);
                        memory.Position = 0;

                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = memory;
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();
                    }

                    // Create an Image control and set its source to the BitmapImage
                    System.Windows.Controls.Image imageControl = new System.Windows.Controls.Image();
                    imageControl.Source = bitmapImage;
                    imageContainer.Children.Add(imageControl);
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("Error Occured while showing preview, please check D:/VisitorData/GeneratedDocument/ folder");
            }
            finally
            {
                // Clean up resources
                rasterizer.Close();
            }
        }
    }
}