using CanonEDSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.PhotoHandler
{
    public class CanonSDKHelper : MainForm
    {
        private static CanonSDKHelper canonSDKHelper = null;
        public static CanonSDKHelper GetFormInstance
        {
            get
            {
                if (canonSDKHelper == null)
                {
                    return new CanonSDKHelper();
                }
                return canonSDKHelper;

            }
        }
        private CanonSDKHelper()
        {

        }

    }
}
