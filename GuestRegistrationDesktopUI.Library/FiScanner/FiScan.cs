using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.FiScanner
{
    public class FiScan : IFiScan
    {
        public FiScanHelper _fiScanHelper;
        public FiScan()
        {
            _fiScanHelper = new FiScanHelper();
            _fiScanHelper.FormScan_Load();
            _fiScanHelper.OpenScanner();
            _fiScanHelper.InitialFileRead();
            _fiScanHelper.cboFileType_SelectedIndexChanged();
        }

        ~FiScan()
        {
            _fiScanHelper.FormScan_Closed();
            _fiScanHelper.Dispose();
        }

        public void LoadScanner()
        {
            _fiScanHelper.StartScan();
        }

    }
}
