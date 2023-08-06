using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.TextProcessing
{
    public static class CountryCode
    {

    }

    public static class CountryAbbr
    {
        public static string getCountryFullName(string abbr)
        {
            Dictionary<string, string> countryAbbr = new Dictionary<string, string>();
            countryAbbr.Add("QAR", "QATAR");
            countryAbbr.Add("IND", "INDIA");

            return countryAbbr[abbr];
        }

    }
}
