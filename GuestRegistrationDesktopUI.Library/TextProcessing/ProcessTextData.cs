using GuestRegistrationDesktopUI.Library.Models;
using NLog;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public VisitorDataModel ProcessTextFromBlob(string InputText)
        {
            VisitorDataModel visitorData = new VisitorDataModel();

          if (InputText.Length < 25)
            {
                return FillErrorMessage();
            }

            try
            {
                bool isQatarId = InputText.Contains("State Of Qatar") || InputText.Contains("Residency Permit") || InputText.Contains("Permit");

                if (isQatarId)
                {
                    return ProcessQatarIdImage(InputText);
                }
                else
                {
                    return ProcessPassPortImage(InputText);
                }

            }
            catch (Exception ex)
            {
                LogError(ex, "ProcessTextFromBlob");
                //throw;
            }
            return visitorData;
        }
        private List<string> RemoveEmptyItems(List<string> items)
        {
            items.RemoveAll(x => x == "");
            items.RemoveAll(x => x == "kkk");
            items.RemoveAll(x => x == "ccc");
            items.RemoveAll(x => x == " ");
            return items;
        }
        private VisitorDataModel ProcessPassPortImage(string inputText)
        {
            VisitorDataModel visitorDataModel = new VisitorDataModel();
            try
            {
                //return MRZParsingLogic.parseMRZLogicTwo(inputText);
                return MRZParsingLogic.parseMRZLogicOne(inputText);

            }
            catch (Exception ex)
            {
                LogError(ex, "ProcessPassPortImage");
                //throw;
            }
            return visitorDataModel;
        }
       
        private (string, int) ExtractIDnumber(List<string> items)
        {
            try
            {
                string IdNumber = string.Empty;
                int count = 0;
                foreach (var item in items)
                {
                    count++;
                    foreach (var chars in item)
                    {
                        if (Char.IsNumber(chars))
                        {
                            IdNumber = item;
                            break;
                        }
                    }
                    if (IdNumber != "")
                    {
                        break;
                    }
                }
                return (IdNumber, count);
            }
            catch (Exception ex)
            {
                LogError(ex, "ExtractIDnumber");
                throw;
            }
        }
        
        private VisitorDataModel ProcessQatarIdImage(string inputText)
        {
            try
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
                foreach (string line in data)
                {
                    if (line.Contains("ID"))
                    {
                        //visitorDataModel.IDno = line.Substring(line.IndexOf(":") + 1, 12);
                        visitorDataModel.IDno = SelectNumberOnly(line);
                    }
                    else if (line.Contains("D.O.B") || line.Contains("D.0.B") || line.Contains("D.O") || line.Contains(".O."))
                    {
                        //visitorDataModel.DateOfBirth = line.Substring(line.IndexOf(":") + 1, 11);
                        visitorDataModel.DateOfBirth = ExtractDate(line);
                    }
                    else if (line.Contains("Expiry"))
                    {
                        visitorDataModel.Expiry = ExtractDate(line);
                    }
                    else if (line.Contains("Nationality"))
                    {
                        visitorDataModel.Nationality = RemoveLowerCase(line.Substring(line.IndexOf(":") + 1)).Trim();
                    }
                    else if (line.Contains("Name") || line.Contains("Sam") || line.Contains("|") || line.Contains("ame"))
                    {
                        visitorDataModel.Name = RemoveLowerCase(line.Substring(line.IndexOf(":") + 1)).Trim();
                    }
                    if (visitorDataModel.Name is null)
                    {
                        visitorDataModel.Name = SelectUpperCase(data[data.Count - 1]);
                    }

                }

                return visitorDataModel;
            }
            catch (Exception ex)
            {
                LogError(ex, "ProcessQatarIdImage");
                throw;
            }
        }

        private string ExtractDate(string InputText)
        {
            try
            {
                string ddmmyyyy = string.Empty;
                bool foundFWslash = InputText.Contains("/");
                if (foundFWslash)
                {
                    int firstIdx = InputText.IndexOf("/");
                    int secondIdx = InputText.IndexOf("/", firstIdx + 1);
                    if (secondIdx - firstIdx == 3)
                    {
                        ddmmyyyy = InputText.Substring(firstIdx - 2, secondIdx - 2);
                        return ddmmyyyy;
                    }
                }
                return "Error/ Please rescan or enter manually";
            }
            catch (Exception ex)
            {
                LogError(ex, "ExtractDate");
                throw;
            }
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
            try
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
            catch (Exception ex)
            {
                LogError(ex, "SelectNumberOnly");
                throw;
            };
        }
        
        private VisitorDataModel FillErrorMessage()
        {
            VisitorDataModel visitorDataModel = new VisitorDataModel();
            visitorDataModel.DateOfBirth = "Error Please Re-Scan";
            visitorDataModel.Expiry = "Error Please Re-Scan";
            visitorDataModel.IDno = "Error Please Re-Scan";
            visitorDataModel.Name = "Error Please Re-Scan";
            visitorDataModel.Nationality = "Error Please Re-Scan";
            return visitorDataModel;
        }
        private void LogError(Exception ex, string v)
        {
            logger.Error($"Error in {v} \n {ex.Message}");
            logger.Error($"{ex.StackTrace}");
            logger.Error($"{ex.InnerException}");
        }
    }
}
