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
            items.RemoveAll(x => x == " ");
            return items;
        }
        private VisitorDataModel ProcessPassPortImage(string inputText)
        {
            try
            {
                VisitorDataModel visitorDataModel = new VisitorDataModel();
                string mrz = inputText.Substring(inputText.IndexOf("<")).Replace("\n", "");
                List<string> mrzCode2Part = mrz.Split(new[] { "<<" }, StringSplitOptions.None).ToList();
                mrzCode2Part = RemoveEmptyItems(mrzCode2Part);
                string countryCode = mrzCode2Part[0].Substring(1, 3);
                string secondName = mrzCode2Part[0].Substring(4).Replace("<", " ");
                List<string> SecondPartParsed = mrzCode2Part[1].Split('<').ToList();
                string FirstName = ExtractFirstName(SecondPartParsed);
                (string Idnumber, int startIndexOfDOB) = ExtractIDnumber(SecondPartParsed);
                string remaingData = SecondPartParsed[startIndexOfDOB];
                remaingData = remaingData.Substring(3).Replace(" ", "");
                (string DateOfBirth, int dobIndex) = ExtractNumberGroup(remaingData, 0);
                (string ExpiryDate, int expIndex) = ExtractNumberGroup(remaingData, dobIndex + 1);
                visitorDataModel.Name = FirstName + " " + secondName;
                visitorDataModel.IDno = Idnumber;
                visitorDataModel.Nationality = countryCode;
                visitorDataModel.DateOfBirth = DateOfBirth;
                visitorDataModel.Expiry = ExpiryDate;
                visitorDataModel.IsPassport = true;
                return visitorDataModel;
            }
            catch (Exception ex)
            {
                LogError(ex, "ProcessPassPortImage");
                throw;
            }
        }
        private (string result, int curIndex) ExtractNumberGroup(string currentItem, int startIdx)
        {
            try
            {
                string result = string.Empty;
                int count = 0;
                for (int i = startIdx; i < currentItem.Length; i++)
                {
                    if (Char.IsNumber(currentItem[i]))
                    {
                        result = currentItem.Substring(i, 6);
                        count = i + 6;
                        break;
                    }
                }
                return (DateInterpolation(result), count);
            }
            catch (Exception ex)
            {
                LogError(ex, "ExtractNumberGroup");
                throw;
            }

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
        private string ExtractFirstName(List<string> items)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                bool anyNumPresent = false;
                foreach (var item in items)
                {
                    foreach (var chars in item)
                    {
                        if (Char.IsNumber(chars))
                        {
                            anyNumPresent = true;
                            break;
                        }
                    }
                    if (!anyNumPresent)
                    {
                        sb.Append(item);
                        sb.Append(" ");
                    }
                }
                return sb.ToString().Trim();
            }
            catch (Exception ex)
            {
                LogError(ex, "ExtractFirstName");
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
        private string DateInterpolation(string item)
        {
            try
            {
                StringBuilder number = new StringBuilder();
                foreach (var chars in item)
                {
                    if (Char.IsNumber(chars))
                    {
                        number.Append(chars);
                    }
                }
                string year = number.ToString().Substring(0, 2);
                string month = number.ToString().Substring(2, 2);
                string day = number.ToString().Substring(4, 2);
                int yearinInt = Convert.ToInt32(year);
                if (yearinInt <= 50 && yearinInt >= 00)
                {
                    year = "20" + year;
                }
                else
                {
                    year = "19" + year;
                }
                number.Clear();
                number.Append(day);
                number.Append("/");
                number.Append(month);
                number.Append("/");
                number.Append(year);
                return number.ToString();
            }
            catch (Exception ex)
            {
                LogError(ex, "DateInterpolation");
                throw;
            }
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
