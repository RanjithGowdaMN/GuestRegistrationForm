﻿using GuestRegistrationDesktopUI.Library.Models;
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
            try
            {
                bool isQatarId = InputText.Contains("State Of Qatar") || InputText.Contains("Residency Permit") || InputText.Contains("Permit");
                if (isQatarId)
                {
                    visitorData = ProcessQatarIdImage(InputText);
                }
                else
                {
                    visitorData = ProcessPassPortImage(InputText);
                }
            }
            catch (Exception e)
            {
                logger.Error($"Error: {e.Message}");
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
                //VisitorDataModel visitorDataModel = new VisitorDataModel();
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
                return visitorDataModel;
            }
            catch (Exception e)
            {
                logger.Error($"Error: {e.Source} /n {e.Message} /n {e.InnerException} /n {e.StackTrace}");
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
            catch (Exception e)
            {
                logger.Error($"Error: ExtractNumberGroup {e.Message}--- {currentItem}");
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
            catch (Exception e)
            {
                logger.Error($"Error in ExtractIDnumber {items[0]} /n {items[1]} /n {items[2]}");
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
            catch (Exception e)
            {
                logger.Error($"Error in  ExtractFirstName {items[0]} \n {items[1]} \n {items[2]}");
                throw;
            }
        }
        private VisitorDataModel ProcessQatarIdImage(string inputText)
        {
            //throw new NotImplementedException();
            try
            {
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
                return visitorDataModel = ExtractIdDataByImageFields(data);
            }
            catch (Exception e)
            {
                logger.Error($" Error in ProcessQatarIdImage!!");
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
            }
            catch (Exception)
            {
                logger.Error($" Error in ExtractDate {InputText}");
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
            catch (Exception e)
            {
                logger.Error($"Error in DateInterpolation {item}");
                throw;
            }
            
        }

        private VisitorDataModel ExtractIdDataByImageFields(List<string> data)
        {
            try
            {
                VisitorDataModel visitorDataModel = new VisitorDataModel();
                foreach (string line in data)
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
                    else if (line.Contains("D.O.B") || line.Contains("D.0.B") || line.Contains("D.O") || line.Contains(".O."))
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
            catch (Exception)
            {
                logger.Error($"Error in ExtractIdDataByImageFields {data[0]} /n  {data[1]} /n {data[2]} ");
                throw;
            }
            
        }
    }
    

}
