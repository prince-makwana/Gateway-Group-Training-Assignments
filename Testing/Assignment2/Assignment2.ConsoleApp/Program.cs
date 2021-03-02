using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.ConsoleApp.ExtensionClasses;

namespace Assignment2.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prince".ChangeCase());
            Console.WriteLine("Gateway GROup oF CompaniEs".ChangeToTitleCase());
            Console.WriteLine("Prince".IsLowerCaseString() ? "All Characters are lower" : "Not all characters are lower");
            Console.WriteLine("prince".DoCapitalize());
            Console.WriteLine("PRINCE".IsUpperCaseString() ? "All Characters are upper" : "Not all characters are upper");
            Console.WriteLine("123d".IsValidNumericValue() ? "Is valid numeric string" : "Is not valid numeric string");
            Console.WriteLine("Prince Makwana".RemoveLastCharacter());
            Console.WriteLine("Prince Makwana".WordCount());
            Console.WriteLine("123".StringToInteger());
            Console.ReadLine();
        }
    }
}
