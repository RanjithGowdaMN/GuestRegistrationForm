using GuestRegistrationDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.TextProcessing
{
    public class ProcessTextData
    {
        public VisitorDataModel ProcessTextFromBlob(string InputText)
        {
            VisitorDataModel visitorData = new VisitorDataModel();

            bool isQatarId = InputText.Contains("State Of Qatar") || InputText.Contains("Residency Permit");

            if (isQatarId)
            {
                return ProcessQatarIdImage(InputText);
            }

            return visitorData;
        }

        private VisitorDataModel ProcessQatarIdImage(string inputText)
        {
            //throw new NotImplementedException();
            List<string> data = new List<string>();
            VisitorDataModel visitorDataModel = new VisitorDataModel();
            using (StringReader reader = new StringReader(inputText))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string text = line.TrimStart().TrimEnd();
                    if (text != null && text != string.Empty && text != "")
                    {
                        data.Add(text);
                    }
                    
                }
            }

            foreach(string line in data)
            {
                if (line.Contains("ID"))
                {
                    visitorDataModel.IDno = line.Substring(line.IndexOf(":") + 1, 12);
                } 
                else if(line.Contains("D.O.B") || line.Contains("D.0.B"))
                {
                    visitorDataModel.DateOfBirth = line.Substring(line.IndexOf(":") + 1, 11);
                }
                else if (line.Contains("Expiry"))
                {
                    visitorDataModel.Expiry = line.Substring(line.IndexOf(":") + 1, 11);
                }
                else if (line.Contains("Nationality"))
                {
                    visitorDataModel.Nationality = RemoveLowerCase(line.Substring(line.IndexOf(":") + 1));
                }
                else if (line.Contains("Name") || line.Contains("Sam") || line.Contains("|"))
                {
                    visitorDataModel.Name = RemoveLowerCase(line.Substring(line.IndexOf(":") + 1));
                }
                if(visitorDataModel.Name is null)
                {
                    visitorDataModel.Name = SelectUpperCase(data[data.Count - 1]);
                }    

            }
            return visitorDataModel;
        }

        public string RemoveLowerCase(string InputText)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in InputText)
            {
                if (!char.IsLower(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        public string SelectUpperCase(string input)
        {
            string pattern = "[A-Z]";
            string upperCaseLetters = string.Concat(Regex.Matches(input, pattern));
            return upperCaseLetters;


            //string upperCaseLetters = new string(input.Where(char.IsUpper).ToArray());
            //return upperCaseLetters;
        }
    }
}
