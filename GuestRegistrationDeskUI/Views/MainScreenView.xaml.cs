using GuestRegistrationDeskUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
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
            //LoadImage();
        }
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
                txtPersontobeVisited.Text = string.Empty;
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
    }
}
