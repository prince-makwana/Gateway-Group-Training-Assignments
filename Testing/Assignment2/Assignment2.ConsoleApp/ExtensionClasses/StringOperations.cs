using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.ConsoleApp.ExtensionClasses
{
    public static class StringOperations
    {
        public static string ChangeCase(this string inputString)
        {
            return Char.IsLower(inputString[0]) ? inputString.ToUpper() : inputString.ToLower();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string ChangeToTitleCase(this string inputString)
        {
            StringBuilder updatedString = new StringBuilder();
            string[] inputStringArray = inputString.Split(' ');
            foreach (var item in inputStringArray)
            {
                bool isAcronyms = true;
                for (int index = 0; index < item.Length; index++)
                {
                    if (Char.IsLower(item[index]))
                    {
                        isAcronyms = false;
                        break;
                    }

                }
                if (!isAcronyms)
                    updatedString.Append(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(item) + " ");
                else
                    updatedString.Append(item + " ");
            }
            return updatedString.ToString().Remove(updatedString.Length - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static bool IsLowerCaseString(this string inputString)
        {
            bool isLower = true;
            for (int index = 0; index < inputString.Length; index++)
            {
                if (Char.IsUpper(inputString[index]))
                {
                    isLower = false;
                    break;
                }
            }
            return isLower ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string DoCapitalize(this string inputString)
        {
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(inputString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static bool IsUpperCaseString(this string inputString)
        {
            bool isUpper = true;
            for (int index = 0; index < inputString.Length; index++)
            {
                if (Char.IsLower(inputString[index]))
                {
                    isUpper = false;
                    break;
                }
            }
            return isUpper ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static bool IsValidNumericValue(this string inputString)
        {
            return int.TryParse(inputString, out int n);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string RemoveLastCharacter(this string inputString)
        {
            return inputString.Remove(inputString.Length - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static int WordCount(this string inputString)
        {
            return inputString.Split(' ').Length;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static int StringToInteger(this string inputString)
        {
            int.TryParse(inputString, out int n);
            return n;
        }
    }
}
