using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;

namespace EPublico.Core.Extensions {
  public static class StringExtension
    {
       public static string ToExtract(this string String, int length)
        {
            if (length == 0)
                return String;


            return String.Substring(0,length);
        }

        public static string ToBin(this string String)
        {
            return ToExtract(String,6);
        }

        /// <summary>

        /// Check for Positive Integers with zero inclusive

        /// </summary>

        /// <param name="strNumber"></param>

        /// <returns></returns>

        public static string HtmlEncode(this string String)
        {
            if (String == "")

                return "";

            return HttpUtility.HtmlEncode(String);
        }

        /// <summary>

        /// Check for Positive Integers with zero inclusive

        /// </summary>

        /// <param name="strNumber"></param>

        /// <returns></returns>

        public static string HtmlDecode(this string String)
        {
            if (String == "")

                return "";

            return HttpUtility.HtmlDecode(String);
        }

        /// <summary>

        /// Check for Positive Integers with zero inclusive

        /// </summary>

        /// <param name="strNumber"></param>

        /// <returns></returns>

        public static bool IsWholeNumber(this string strNumber)
        {
            if (strNumber == "")

                return false;

            Regex objNotWholePattern = new Regex("[^0-9]");

            return !objNotWholePattern.IsMatch(strNumber);
        }

        /// <summary>

        /// Check if the string is Double

        /// </summary>

        /// <param name="strNumber"></param>

        /// <returns></returns>

        public static bool IsDouble(this string strNumber)
        {
            if (strNumber == "")

                return false;

            try
            {
                Convert.ToDouble(strNumber);
            }

            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>

        ///Function to Check for AlphaNumeric.

        /// </summary>

        /// <param name="strToCheck"> String to check for alphanumeric</param>

        /// <returns>True if it is Alphanumeric</returns>

        public static bool IsAlphaNumeric(this string strToCheck)
        {
            bool valid = true;

            if (strToCheck == "")

                return false;

            Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");

            valid = !objAlphaNumericPattern.IsMatch(strToCheck);

            return valid;
        }

        /// <summary>

        ///Function to Check for valid alphanumeric input with space chars also

        /// </summary>

        /// <param name="strToCheck"> String to check for alphanumeric</param>

        /// <returns>True if it is Alphanumeric</returns>

        public static bool IsValidAlphaNumericWithSpace(this string strToCheck)
        {
            bool valid = true;

            if (strToCheck == "")

                return false;

            Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9\\s]");

            valid = !objAlphaNumericPattern.IsMatch(strToCheck);

            return valid;
        }

        /// <summary>

        /// Check for valid alphabet input with space chars also

        /// </summary>

        /// <param name="strToCheck"> String to check for alphanumeric</param>

        /// <returns>True if it is Alphanumeric</returns>

        public static bool IsValidAlphabetWithSpace(this string strToCheck)
        {
            bool valid = true;

            if (strToCheck == "")

                return false;

            Regex objAlphaNumericPattern = new Regex("[^a-zA-Z\\s]");

            valid = !objAlphaNumericPattern.IsMatch(strToCheck);

            return valid;
        }

        /// <summary>

        /// Check for valid alphabet input with space chars also

        /// </summary>

        /// <param name="strToCheck"> String to check for alphanumeric</param>

        /// <returns>True if it is Alphanumeric</returns>

        public static bool IsValidAlphabetWithHyphen(this string strToCheck)
        {
            bool valid = true;

            if (strToCheck == "")

                return false;

            Regex objAlphaNumericPattern = new Regex("[^a-zA-Z\\-]");

            valid = !objAlphaNumericPattern.IsMatch(strToCheck);

            return valid;
        }

        /// <summary>

        ///  Check for Alphabets.

        /// </summary>

        /// <param name="strToCheck">Input string to check for validity</param>

        /// <returns>True if valid alphabetic string, False otherwise</returns>

        public static bool IsAlpha(this string strToCheck)
        {
            bool valid = true;

            if (strToCheck == "")

                return false;

            Regex objAlphaPattern = new Regex("[^a-zñÑA-Z ]");

            valid = !objAlphaPattern.IsMatch(strToCheck);

            return valid;
        }

        /// <summary>

        /// Check whether the string is valid number or not

        /// </summary>

        /// <param name="strNumber">Number to check for </param>

        /// <returns>True if valid number, False otherwise</returns>

        public static bool IsNumber(this string strNumber)
        {
            try
            {
                Convert.ToDouble(strNumber);

                return true;
            }

            catch
            {
                return false;
            }
        }

        /// <summary>

        ///

        /// </summary>

        /// <param name="strInteger"></param>

        /// <returns></returns>

        public static bool IsInteger(this string strInteger)
        {
            try
            {
                if (string.IsNullOrEmpty(strInteger))

                    return false;

                Convert.ToInt32(strInteger);

                return true;
            }

            catch
            {
                return false;
            }
        }

        /// <summary>

        ///

        /// </summary>

        /// <param name="strDateTime"></param>

        /// <returns></returns>

        public static bool IsDateTime(this string strDateTime)
        {
            try
            {
                Convert.ToDateTime(strDateTime);

                return true;
            }

            catch
            {
                return false;
            }
        }

        /// <summary>

        /// Function to validate given string for HTML Injection

        /// </summary>

        /// <param name="strBuff">String to be validated</param>

        /// <returns>Boolean value indicating if given input string passes HTML Injection validation</returns>

        public static bool IsValidHTMLInjection(this string strBuff)
        {
            return (!Regex.IsMatch(HttpUtility.HtmlDecode(strBuff), "<(.|\n)+?>"));
        }

        /// <summary>

        /// Checks whether a valid Email address was input

        /// </summary>

        /// <param name="inputEmail">Email address to validate</param>

        /// <returns>True if valid, False otherwise</returns>

        public static bool isEmail(this string inputEmail)
        {
            if (inputEmail != null && inputEmail != "")
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +

                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +

                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

                Regex re = new Regex(strRegex);

                if (re.IsMatch(inputEmail))

                    return (true);

                else

                    return (false);
            }

            else

                return (false);
        }

        public static bool IsUrl(this string inputUrl)
        {
            if (inputUrl != null && inputUrl != "")
            {
                string strRegex = @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";

                Regex re = new Regex(strRegex);

                if (re.IsMatch(inputUrl))

                    return (true);

                else

                    return (false);
            }

            else

                return (false);

        }

        /// <summary>

        /// Converts a valid string to integer

        /// </summary>

        /// <param name="StringToConvert"></param>

        /// <returns></returns>

        public static int ToInteger(this string StringToConvert)
        {
            try
            {
                return Convert.ToInt32(StringToConvert.ToString());
            }

            catch
            {
                throw new Exception("String could not be converted to Integer");
            }
        }

        /// <summary>

        /// Converts an Object to it's integer value

        /// </summary>

        /// <param name="ObjectToConvert"></param>

        /// <returns></returns>

        public static int ToInteger(this object ObjectToConvert)
        {
            try
            {
                return Convert.ToInt32(ObjectToConvert.ToString());
            }

            catch
            {
                throw new Exception("Object cannot be converted to Integer");
            }
        }

        /// <summary>

        /// Converts an Object to it's integer value

        /// </summary>

        /// <param name="ObjectToConvert"></param>

        /// <returns></returns>

        public static long ToLong(this object ObjectToConvert)
        {
            try
            {
                return Convert.ToInt64(ObjectToConvert.ToString());
            }

            catch
            {
                throw new Exception("Object cannot be converted to Long");
            }
        }

        /// <summary>

        /// Converts a valid string to double

        /// </summary>

        /// <param name="StringToConvert"></param>

        /// <returns></returns>

        public static double ToDouble(this string StringToConvert)
        {
            return Convert.ToDouble(StringToConvert);
        }

        /// <summary>

        /// Converts an Object to it's double value

        /// </summary>

        /// <param name="ObjectToConvert"></param>

        /// <returns></returns>

        public static double ToDouble(this object ObjectToConvert)
        {
            try
            {
                return Convert.ToDouble(ObjectToConvert.ToString());
            }

            catch
            {
                throw new Exception("Object cannot be converted to double");
            }
        }

        /// <summary>

        /// Converts an Object to it's decimal value

        /// </summary>

        /// <param name="ObjectToConvert"></param>

        /// <returns></returns>

        public static decimal ToDecimal(this object ObjectToConvert)
        {
            try
            {
                return Convert.ToDecimal(ObjectToConvert.ToString());
            }

            catch
            {
                throw new Exception("Object cannot be converted to decimal");
            }
        }

        /// <summary>

        /// Converts an String to it's decimal value

        /// </summary>

        /// <param name="ObjectToConvert"></param>

        /// <returns></returns>

        public static decimal ToDecimal(this string StringToConvert)
        {
            try
            {
                return Convert.ToDecimal(StringToConvert.ToString());
            }

            catch
            {
                throw new Exception("String cannot be converted to decimal");
            }
        }

        /// <summary>

        /// Converts a string to a Sentence case

        /// </summary>

        /// <param name="String"></param>

        /// <returns></returns>

        public static string ToSentence(this string String)
        {
            if (String.Length > 0)

                return String.Substring(0, 1).ToUpper() + String.Substring(1, String.Length - 1);

            return "";
        }

        public static bool ToBool(this object Object)
        {
            try
            {
                return Convert.ToBoolean(Object.ToString());
            }

            catch
            {
                throw new Exception("Object cannot be converted to Boolean");
            }
        }

        public static DateTime ToDateTime(this string String)
        {
            try
            {
                return Convert.ToDateTime(String);
            }

            catch (Exception)
            {
                throw new Exception("Object cannot be converted to DateTime. Object: " + String);
            }
        }

        public static DateTime ToDateTime(this object Object)
        {
            try
            {
                return Convert.ToDateTime(Convert.ToString(Object));
            }

            catch (Exception)
            {
                throw new Exception("Object cannot be converted to DateTime. Object: " + Object);
            }
        }

        /// <summary>

        /// Selects specific number of rows from a datatable

        /// </summary>

        /// <param name="dataTable"></param>

        /// <param name="rowCount"></param>

        /// <returns></returns>

        public static DataTable SelectRows(this DataTable dataTable, int rowCount)
        {
            try
            {
                DataTable myTable = dataTable.Clone();

                DataRow[] myRows = dataTable.Select();

                for (int i = 0; i < rowCount; i++)
                {
                    if (i < myRows.Length)
                    {
                        myTable.ImportRow(myRows[i]);

                        myTable.AcceptChanges();
                    }
                }

                return myTable;
            }

            catch (Exception)
            {
                return new DataTable();
            }
        }

        public static string ParseString(this Guid? g)
        {
          if(g == null)
            return null;

          return g.HasValue ? g.ToString() : null;
        }

        public static string ParseString(this Guid g)
        {
          if(g == null)
            return null;

          return !string.IsNullOrEmpty(g.ToString()) ? g.ToString() : null;
        }

        public static bool IsNull(this string s)
        {
            if( s == null || string.IsNullOrEmpty(s) || s.Trim() == string.Empty)
              return true;

            return false;
        }



        /// <summary>

        /// Accepts a date time value, calculates number of days, minutes or seconds and shows 'pretty dates'

        /// like '2 days ago', '1 week ago' or '10 minutes ago'

        /// </summary>

        /// <param name="d"></param>

        /// <returns></returns>

        public static string GetPrettyDate(this DateTime d)
        {
            // 1.

            // Get time span elapsed since the date.

            TimeSpan s = DateTime.Now.Subtract(d);

            // 2.

            // Get total number of days elapsed.

            int dayDiff = (int)s.TotalDays;

            // 3.

            // Get total number of seconds elapsed.

            int secDiff = (int)s.TotalSeconds;

            // 4.

            // Don't allow out of range values.

            if (dayDiff < 0 || dayDiff >= 31)
            {
                return d.ToString();
            }

            // 5.

            // Handle same-day times.

            if (dayDiff == 0)
            {
                // A.

                // Less than one minute ago.

                if (secDiff < 60)
                {
                    return "just now";
                }

                // B.

                // Less than 2 minutes ago.

                if (secDiff < 120)
                {
                    return "1 minute ago";
                }

                // C.

                // Less than one hour ago.

                if (secDiff < 3600)
                {
                    return string.Format("{0} minutes ago",

                        Math.Floor((double)secDiff / 60));
                }

                // D.

                // Less than 2 hours ago.

                if (secDiff < 7200)
                {
                    return "1 hour ago";
                }

                // E.

                // Less than one day ago.

                if (secDiff < 86400)
                {
                    return string.Format("{0} hours ago",

                        Math.Floor((double)secDiff / 3600));
                }
            }

            // 6.

            // Handle previous days.

            if (dayDiff == 1)
            {
                return "yesterday";
            }

            if (dayDiff < 7)
            {
                return string.Format("{0} days ago",

                    dayDiff);
            }

            if (dayDiff < 31)
            {
                return string.Format("{0} weeks ago",

                    Math.Ceiling((double)dayDiff / 7));
            }

            return null;
        }

        /// <summary>

        /// This mehtod will extend the response mehtod and open the page in a new window

        /// </summary>

        /// <param name="response"></param>

        /// <param name="url"></param>

        /// <param name="target"></param>

        /// <param name="windowFeatures"></param>

        //public static void Redirect(this HttpResponse response, string url, string target, string windowFeatures)
        //{
        //    if ((String.IsNullOrEmpty(target) ||

        //        target.Equals("_self", StringComparison.OrdinalIgnoreCase)) &&

        //        String.IsNullOrEmpty(windowFeatures))
        //    {
        //        response.Redirect(url);
        //    }

        //    else
        //    {
        //        Page page = (Page)HttpContext.Current.Handler;

        //        if (page == null)
        //        {
        //            throw new InvalidOperationException(

        //                "Cannot redirect to new window outside Page context.");
        //        }

        //        url = page.ResolveClientUrl(url);

        //        string script;

        //        if (!String.IsNullOrEmpty(windowFeatures))
        //        {
        //            script = @"window.open(""{0}"", ""{1}"", ""{2}"");";
        //        }

        //        else
        //        {
        //            script = @"window.open(""{0}"", ""{1}"");";
        //        }

        //        script = String.Format(script, url, target, windowFeatures);

        //        ScriptManager.RegisterStartupScript(page,

        //            typeof(Page),

        //            "Redirect",

        //            script,

        //            true);
        //    }
        //}
    }
}
