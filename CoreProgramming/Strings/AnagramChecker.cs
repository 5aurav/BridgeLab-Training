using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class AnagramChecker
    {
        public static void display()
        {
            Console.Write("Enter first string: ");
            string str1 = Console.ReadLine().ToLower();

            Console.Write("Enter second string: ");
            string str2 = Console.ReadLine().ToLower();

            bool result = IsAnagram(str1, str2);

            if (result)
            {
                Console.WriteLine("The strings are anagrams.");
            }
            else
            {
                Console.WriteLine("The strings are not anagrams.");
            }
        }
        static bool IsAnagram(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            bool[] used = new bool[str2.Length];

            for (int i = 0; i < str1.Length; i++)
            {
                bool found = false;

                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] == str2[j] && !used[j])
                    {
                        used[j] = true;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
