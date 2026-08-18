using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilder_and_StringReader
{
    internal class ReverseString
    {
        public static void Run()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            StringBuilder result = new StringBuilder(input);

            for (int i = 0, j = result.Length - 1; i < j; i++, j--)
            {
                char temp = result[i];
                result[i] = result[j];
                result[j] = temp;
            }

            Console.WriteLine($"Reversed: {result}");
        }
    }
}
