using GuestRegistrationDeskUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuestRegistrationDeskUI.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainScreenView : UserControl
    {
        public MainScreenView()
        {
            InitializeComponent();
            //LoadImage();

        }
        public void LoadImage()
        {
            // Create a BitmapImage from the image path
            var image = new System.Windows.Media.Imaging.BitmapImage();
            image.BeginInit();
            image.UriSource = new System.Uri("D:\\Images\\Photos\\photo00001.jpg");
            image.EndInit();

            VisitorPhoto.Source = image;
        }
    }
}
