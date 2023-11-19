﻿//using GuestRegistrationDeskUI.ViewModels;
using GenerateDocument.Library;
using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationDesktopUI.Library.OCR;
using GuestRegistrationWinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesseractOCR.Library;

namespace gui
{
    public partial class FormScan : Form
    {
        public static ICentralHub _centralHub;
       

        public FormScan(ICentralHub centralHub)
        {
            _centralHub = centralHub;
            _centralHub.CanonImageDownload += UpdatePhotoImage;
            InitializeComponent();
        }

    
        private void btnfront_Click(object sender, EventArgs e)
        {
            //MainScreenViewModel mainscreenVM = new MainScreenViewModel();
            if (rbid.Checked)
            {

                (var result, string fileName) = _centralHub.StartScanning(1);
                pbfront.SizeMode = PictureBoxSizeMode.Zoom;
                pbfront.Image = Image.FromFile(fileName);
    
            }
            else if (rbpass.Checked)

            {
                (var result, string fileName) = _centralHub.StartScanning(2);
                pbfront.SizeMode = PictureBoxSizeMode.Zoom;
                pbfront.Image = Image.FromFile(fileName);
            }

            else
            {
                MessageBox.Show("Please select the ID Type");

            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            if (rbid.Checked)
            {
                string fileName = _centralHub.ScanBackSide(1); // (var result, string fileName) =
                pbback.SizeMode = PictureBoxSizeMode.Zoom;
                pbback.Image = Image.FromFile(fileName);
            }
            else if (rbpass.Checked)
            {
                string fileName = _centralHub.ScanBackSide(2);

                pbback.SizeMode = PictureBoxSizeMode.Zoom;
                pbback.Image = Image.FromFile(fileName);
            }
        }
     
        private void btnphoto_Click(object sender, EventArgs e)
        {
            try
            {
                _centralHub.TakePhoto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, Please check the camera");
            }
        }

        public void UpdatePhotoImage(string path)
        {
            pbphoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbphoto.Image = Image.FromFile(path);
        }
    }
}

