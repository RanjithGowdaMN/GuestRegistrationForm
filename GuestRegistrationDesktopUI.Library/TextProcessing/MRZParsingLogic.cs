using GuestRegistrationDesktopUI.Library.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.TextProcessing
{
    public static class MRZParsingLogic
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static VisitorDataModel parseMRZLogicOne(string InputText)
        {
            VisitorDataModel visitorDataModel = VisitorDataModel.Instance;
            InputText = InputText.Replace("\n", "").Replace(" ", "").Trim();
            while(InputText.Contains("<<"))
            {
                InputText = InputText.Replace("<<", "<");
            }
            List<string> Mrz = InputText.Split('<').ToList();
            Mrz = RemoveEmptyItems(Mrz);
            Mrz = RemovItemsWithSingleVal(Mrz);
            Mrz.RemoveAt(Mrz.Count - 1);

            visitorDataModel.IDno = Mrz[Mrz.Count - 2];
            string DOBandExpiry = Mrz[Mrz.Count - 1];
            //Expiry
            (visitorDataModel.DateOfBirth, visitorDataModel.Expiry) = ExtractExpiryandDob(DOBandExpiry);

            visitorDataModel.Nationality = "IND";

            return visitorDataModel;

        }

        private static List<string> RemovItemsWithSingleVal(List<string> mrz)
        {
            List<string> result = new List<string>();
            foreach (var item in mrz)
            {
                if (item.Length > 1 && item.Length < 22)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private static (string DOB, string Expiry) ExtractExpiryandDob(string inputText)
        {
            string Dob = string.Empty;
            string Expiry = string.Empty;

            inputText = inputText.Substring(4);
            char[] Arr = inputText.ToCharArray();
            int count = 0;
            foreach (char item in Arr)
            {
                if (char.IsDigit(item) && count < 7)
                {
                    Dob += item;
                    count++;
                } else if (char.IsDigit(item))
                {
                    Expiry += item;
                }
            }

            return (Dob, Expiry);
        }

        public static VisitorDataModel parseMRZLogicTwo(string inputText)
        {
            VisitorDataModel visitorDataModel = VisitorDataModel.Instance;

            inputText = inputText.Replace(" ", "");
            inputText = inputText.Replace("\n", "");
            //inputText = inputText.Replace("", "");
            string mrz = inputText.Substring(inputText.IndexOf("<")).Replace("\n", "");
            List<string> mrzCode2Part = mrz.Split(new[] { "<<" }, StringSplitOptions.None).ToList();
            mrzCode2Part = RemoveEmptyItems(mrzCode2Part);

            string countryCode = mrzCode2Part[0].Substring(1, 3);
            visitorDataModel.Nationality = countryCode;

            string secondName = mrzCode2Part[0].Substring(4).Replace("<", " ");

            List<string> SecondPartParsed = mrzCode2Part[1].Split('<').ToList();
            string FirstName = ExtractFirstName(SecondPartParsed);
            visitorDataModel.Name = FirstName + " " + secondName;

            (string Idnumber, int startIndexOfDOB) = ExtractIDnumber(SecondPartParsed);
            Idnumber = string.Join("", string.Join("", Idnumber.Reverse()).Substring(0, 8).Reverse());

            visitorDataModel.IDno = Idnumber;

            string remaingData = SecondPartParsed[startIndexOfDOB];
            remaingData = remaingData.Substring(3).Replace(" ", "");
            (string DateOfBirth, int dobIndex) = ExtractNumberGroup(remaingData, 0);
            visitorDataModel.DateOfBirth = DateOfBirth;

            (string ExpiryDate, int expIndex) = ExtractNumberGroup(remaingData, dobIndex + 1);
            visitorDataModel.Expiry = ExpiryDate;
            visitorDataModel.IsPassport = true;
            return visitorDataModel;
        }

        public static VisitorDataModel parseMRZLogicThree(string inputText)
        {
            VisitorDataModel visitorDataModel = VisitorDataModel.Instance;

            inputText = inputText.Replace(" ", "");
            List<string> mrz = inputText.Split(inputText[inputText.IndexOf('\n')]).ToList();

            string countryCode = mrz[0].Substring(2, 3);

            countryCode = CountryAbbr.getCountryFullName(countryCode);

            visitorDataModel.Nationality = countryCode;

            List<string> mrzFirstPart = mrz[0].Substring(5).Split('<').ToList();
            mrzFirstPart = RemoveEmptyItems(mrzFirstPart);



            //string FullName = mrzFirstPart[mrzFirstPart.Count - 1];//mrzFirstPart.Count-1];

            //for (int i = 0; i < mrzFirstPart.Count -1; i++)
            //{
            //    FullName += " " + mrzFirstPart[i];
            //}

            string FullName = BuildFullName(mrzFirstPart);

            List<string> mrzSecondPart = mrz[1].Split('<').ToList();
            visitorDataModel.Name = ExtractCharatersOnly(FullName);
            visitorDataModel.IDno = mrzSecondPart[0];
            (visitorDataModel.DateOfBirth, visitorDataModel.Expiry) = ExtractExpiryandDob(mrzSecondPart[1]);
            visitorDataModel.DateOfBirth = DateInterpolation(visitorDataModel.DateOfBirth);
            visitorDataModel.Expiry = DateInterpolation(visitorDataModel.Expiry);
            visitorDataModel.IsPassport = true;
            return visitorDataModel;
        }
        private static (string, int) ExtractIDnumber(List<string> items)
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

        private static List<string> RemoveEmptyItems(List<string> items)
        {
            items.RemoveAll(x => x == "");
            items.RemoveAll(x => x == "kkk");
            items.RemoveAll(x => x == "ccc");
            items.RemoveAll(x => x == " ");
            return items;
        }

        private static (string result, int curIndex) ExtractNumberGroup(string currentItem, int startIdx)
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
        private static string DateInterpolation(string item)
        {
            if (item.Length < 5)
            {
                return string.Empty;
            }
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
        private static string ExtractFirstName(List<string> items)
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
        private static void LogError(Exception ex, string v)
        {
            logger.Error($"Error in {v} \n {ex.Message}");
            logger.Error($"{ex.StackTrace}");
            logger.Error($"{ex.InnerException}");
        }

        private static string ExtractCharatersOnly(string text)
        {
            string result = string.Empty;
            foreach (var chars in text)
            {
                if (Char.IsLetter(chars) || Char.IsWhiteSpace(chars))
                {
                    result += chars;
                }
            }
            return result;
        }

        private static string BuildFullName(List<string> names)
        {
            StringBuilder fullName = new StringBuilder();
            if (names.Count == 6)
            {
                return names[3] + " " + names[4] + " " + names[5] + " " + names[0] + " " + names[1] + " " + names[2];

            }
            else if (names.Count == 5) { 
                return names[3] + " " + names[4] + " " + names[0] + " " + names[1] + " " + names[2];
            }
            else if (names.Count == 4)
            {
                return names[2] + " " + names[3] + " " + names[1] + " " + names[0];
            }
            else if(names.Count == 3)
            {
                return names[2] + " " + names[0] + " " + names[1];// + " " + names[0];
            } else if (names.Count == 2)
            {
                return names[1] + " " + names[0];
            } else
            {
                return String.Join(" ",names);
            }
        }
    }
}
