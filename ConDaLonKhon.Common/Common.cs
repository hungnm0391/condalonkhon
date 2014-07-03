using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace ConDaLonKhon.Common
{
    public class Common
    {
        private const string _regxTelephoneNumber = "[0-9]";
        private const string _regxEmailAddress = @"^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$";
        private const string _regxDomain = @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$";

        /// <summary>
        /// Validate telephone number
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        public static bool ValidateTelephoneNumber(string value)
        {
            Regex regxTelephoneNumber = new Regex(_regxTelephoneNumber);
            return regxTelephoneNumber.IsMatch(value);
        }

        /// <summary>
        /// Validate email address
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        public static bool ValidateEmailAddress(string value)
        {
            Regex regxEmailAddress = new Regex(_regxEmailAddress);
            return regxEmailAddress.IsMatch(value);
        }

        /// <summary>
        /// Validate domain
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        public static bool ValidateDomain(string value)
        {
            Regex regxDomain = new Regex(_regxDomain);
            return regxDomain.IsMatch(value);
        }

        /// <summary>
        /// Write exception logs
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          01/07/2014      Add
        /// </modified>
        public static void WriteException(Exception exc)
        {
            string exLogPath = string.Format("{0}/ErrorLog_{1}.txt",
                AppDomain.CurrentDomain.BaseDirectory,
                DateTime.Now.ToString("yyyyMMdd"));

            using (StreamWriter sw = new StreamWriter(exLogPath, true))
            {
                sw.WriteLine("********** {0} **********", DateTime.Now);
                if (exc.InnerException != null)
                {
                    sw.Write("Inner Exception Type: ");
                    sw.WriteLine(exc.InnerException.GetType().ToString());
                    sw.Write("Inner Exception: ");
                    sw.WriteLine(exc.InnerException.Message);
                    sw.Write("Inner Source: ");
                    sw.WriteLine(exc.InnerException.Source);
                    if (exc.InnerException.StackTrace != null)
                    {
                        sw.WriteLine("Inner Stack Trace: ");
                        sw.WriteLine(exc.InnerException.StackTrace);
                    }
                }
                sw.Write("Exception Type: ");
                sw.WriteLine(exc.GetType().ToString());
                sw.WriteLine("Exception: " + exc.Message);
                sw.WriteLine("Stack Trace: ");
                if (exc.StackTrace != null)
                {
                    sw.WriteLine(exc.StackTrace);
                    sw.WriteLine();
                }
            }
        }
    }
}
