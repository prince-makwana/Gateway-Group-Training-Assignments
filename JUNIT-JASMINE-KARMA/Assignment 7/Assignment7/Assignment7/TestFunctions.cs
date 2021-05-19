using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    public class TestFunctions
    {
        /// <summary>
        /// Sum Of First N Numbers
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SumOfFirstNNumbers(int n)
        {
            int i, sum = 0;
            for(i=1; i<=n; i++)
            {
                sum = sum + i;
            }
            return sum;

        }

        /// <summary>
        /// Day Selection
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string DaySelection(int number)
        {
            string day = "";
            switch (number)
            {
                case 1:
                    day = "Monday";
                    break;
                case 2:
                    day = "Tuesday";
                    break;
                case 3:
                    day = "Wednesday";
                    break;
                case 4:
                    day = "Thursday";
                    break;
                case 5:
                    day = "Friday";
                    break;
                case 6:
                    day = "Saturday";
                    break;
                case 7:
                    day = "Sunday";
                    break;
                default:
                    day = "Invalid Day";
                    break;
            }
            return day;
        }

        /// <summary>
        /// Find Small Number
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int SmallNumber(int a, int b)
        {
            if (a < b)
                return a;
            else
            {
                return b;
            }
        }

        /// <summary>
        /// Size of List
        /// </summary>
        /// <returns></returns>
        public int SizeOfList()
        {
            List<int> numList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            int len = 0;
            foreach (int num in numList)
            {
                len = len + 1;
            }
            return len;
        }

        /// <summary>
        /// Count Consonants from string
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int CountConsonants(string name)
        {
            int count = 0;
            int strLen = name.Length;
            for (int i = 1; i < strLen; i++)
            {
                if (name[i] == 'A' || name[i] == 'E' || name[i] == 'I' || name[i] == 'O' || name[i] == 'U' ||
                    name[i] == 'a' || name[i] == 'e' || name[i] == 'i' || name[i] == 'o' || name[i] == 'u')
                    count += 1;
            }
            return (strLen - count);
        }

        /// <summary>
        /// Null Reference Exception
        /// </summary>
        /// <param name="str"></param>
        public void NullReferenceException(string str)
        {
            if (str == null)
                throw new NullReferenceException("Null Reference Exception");
        }

        /// <summary>
        /// Divide By Zero Exception
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        public void DivideByZero(int num1, int num2)
        {
            int result;
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException("Divide By Zero Exception");
            }
        }

        /// <summary>
        /// Array Index Out of Bound Exception
        /// </summary>
        public void ArrayIndexOutOfBound()
        {
            try
            {
                int[] arr = new int[5] { 1, 2, 3, 4, 5 };
                Console.WriteLine(arr[6]);
            }
            catch (Exception)
            {

                throw new IndexOutOfRangeException("Array Index out of Bound");
            }
        }

        /// <summary>
        /// Async Method Example
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<string> PassMessage(string message)
        {
            return message;
        }
    }
}
