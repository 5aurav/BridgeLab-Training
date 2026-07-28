using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class CompareStringsLexicographically
    { 
        public static void display()
        {
            Console.Write("Enter first string: ");
            string str1 = Console.ReadLine();

            Console.Write("Enter second string: ");
            string str2 = Console.ReadLine();

            int result = CompareStrings(str1, str2);

            if (result == 0)
            {
                Console.WriteLine("Both strings are equal.");
            }
            else if (result < 0)
            {
                Console.WriteLine("\"" + str1 + "\" comes before \"" + str2 + "\" in lexicographical order.");
            }
            else
            {
                Console.WriteLine("\"" + str1 + "\" comes after \"" + str2 + "\" in lexicographical order.");
            }
        }

        static int CompareStrings(string str1, string str2)
        {
            int minLength;

            if (str1.Length < str2.Length)
            {
                minLength = str1.Length;
            }
            else
            {
                minLength = str2.Length;
            }

            for (int i = 0; i < minLength; i++)
            {
                if (str1[i] < str2[i])
                {
                    return -1;
                }
                else if (str1[i] > str2[i])
                {
                    return 1;
                }
            }

            if (str1.Length < str2.Length)
            {
                return -1;
            }
            else if (str1.Length > str2.Length)
            {
                return 1;
            }

            return 0;
        }
    }
}
