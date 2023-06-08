using fiScanTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.FiScanner
{
    public sealed class FiScanHelper : FormScan
    {

        private static FiScanHelper fiScanHelper = null;

        public static FiScanHelper GetFormInstance
        {
            get
            {
                if (fiScanHelper == null)
                {
                    return new FiScanHelper();
                }
                return fiScanHelper;

            }
        }
        private FiScanHelper()
        {

        }

    }
}
