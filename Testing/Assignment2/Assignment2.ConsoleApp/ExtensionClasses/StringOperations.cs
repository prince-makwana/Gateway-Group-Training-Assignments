using System;
using System.Collections.Generic;
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
    }
}
