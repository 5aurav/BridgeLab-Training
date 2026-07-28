using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class ToggleCase
    {
        public static void display()
        {
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            string result = Toggle(text);

            Console.WriteLine("Modified String: " + result);
        }
        static string Toggle(string text)
        {
            string result = "";

            foreach (char ch in text)
            {
                if (ch >= 'A' && ch <= 'Z')
                {
                    result += (char)(ch + 32);
                }
                else if (ch >= 'a' && ch <= 'z')
                {
                    result += (char)(ch - 32);
                }
                else
                {
                    result += ch;
                }
            }

            return result;
        }
    }
}
