using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class RemoveDuplicateCharacters
    {
        public static void display()
        {
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            string result = RemoveDuplicates(text);

            Console.WriteLine("Modified String: " + result);
        }
        static string RemoveDuplicates(string text)
        {
            string result = "";

            foreach (char ch in text)
            {
                bool found = false;

                foreach (char c in result)
                {
                    if (c == ch)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    result += ch;
                }
            }

            return result;
        }
    }
}
