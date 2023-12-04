using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.Models
{
    public class ScannedData
    {
        public ScannedData()
        {
            isDataFromDb = new List<bool>() { false, false, false, false };
        }
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Expiry { get; set; }
        public string Nationality { get; set; }
        public List<bool> isDataFromDb { get; set; }
        public int IdType { get; set; }
    }
}
