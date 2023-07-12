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
        private const string TextProcessingErrorMessage = "Error in text processing! Please ReScan";
        public VisitorDataModel ProcessTextFromBlob(string InputText)
        {
            VisitorDataModel visitorData = new VisitorDataModel();

            bool isQatarId = InputText.Contains("State Of Qatar") || InputText.Contains("Residency Permit") || InputText.Contains("Permit"); 

            if (isQatarId)
            {
                return ProcessQatarIdImage(InputText);
            }
            else
            {
                return ProcessPassPortImage(InputText);
            }

            //return visitorData;
        }

        private VisitorDataModel ProcessPassPortImage(string inputText)
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
            return visitorDataModel;
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
                    //visitorDataModel.IDno = line.Substring(line.IndexOf(":") + 1, 12);
                    try
                    {
                        visitorDataModel.IDno = SelectNumberOnly(line);
                    }
                    catch (Exception)
                    {

                        visitorDataModel.IDno = TextProcessingErrorMessage;
                    }
                } 
                else if(line.Contains("D.O.B") || line.Contains("D.0.B") || line.Contains("D.O") || line.Contains(".O."))
                {
                    try
                    {
                        visitorDataModel.DateOfBirth = ExtractDate(line);
                    }
                    catch (Exception)
                    {

                        visitorDataModel.DateOfBirth = TextProcessingErrorMessage;
                    }
                }
                else if (line.Contains("Expiry"))
                {
                    try
                    {
                        visitorDataModel.Expiry = ExtractDate(line);
                    }
                    catch (Exception)
                    {
                        visitorDataModel.Expiry = TextProcessingErrorMessage;
                    }
                }
                else if (line.Contains("Nationality"))
                {
                    try
                    {
                        visitorDataModel.Nationality = RemoveLowerCase(line.Substring(line.IndexOf(":") + 1));
                    }
                    catch (Exception)
                    {
                        visitorDataModel.Nationality = TextProcessingErrorMessage;
                    }
                }
                else if (line.Contains("Name") || line.Contains("Sam") || line.Contains("|") || line.Contains("ame"))
                {
                    try
                    {
                        visitorDataModel.Name = RemoveLowerCase(line.Substring(line.IndexOf(":") + 1));
                    }
                    catch (Exception)
                    {
                        visitorDataModel.Name = TextProcessingErrorMessage;
                    }
                }
            }
            return visitorDataModel;
        }

        private string ExtractDate(string InputText)
        {
            string ddmmyyyy = string.Empty;
            bool foundFWslash = InputText.Contains("/");
            if (foundFWslash)
            {
                int firstIdx = InputText.IndexOf("/");
                int secondIdx = InputText.IndexOf("/", firstIdx+1);
                if (secondIdx-firstIdx == 3)
                {
                    ddmmyyyy = InputText.Substring(firstIdx - 2, secondIdx-2);
                    return ddmmyyyy;
                }
            }
            return "Error/ Please rescan or enter manually";
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

        public string SelectUpperCase(string InputText)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in InputText)
            {
                if (char.IsUpper(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        public string SelectNumberOnly(string InputText)
        {
            string pattern = @"\d+";
            MatchCollection matches = Regex.Matches(InputText, pattern);
            string result = string.Empty;

            foreach (Match match in matches)
            {
                result += match.Value;
            }

            return result;
        }
    }
}
