﻿using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationWinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public partial class FormDoc : Form
    {
        public static ICentralHub _centralHub;
        public FormDoc(ICentralHub centralHub)
        {
            _centralHub = centralHub;
            InitializeComponent();
        }

        public void testMethod() {
            _centralHub.StartScanning(2);
        }
    }
}
