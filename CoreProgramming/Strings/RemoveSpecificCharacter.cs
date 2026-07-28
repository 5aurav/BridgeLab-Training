using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class RemoveSpecificCharacter
    {
        public static void display()
        {
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            Console.Write("Enter the character to remove: ");
            char ch = Convert.ToChar(Console.ReadLine());

            string result = RemoveCharacter(text, ch);

            Console.WriteLine("Modified String: " + result);
        }
        static string RemoveCharacter(string text, char ch)
        {
            string result = "";

            foreach (char c in text)
            {
                if (c != ch)
                {
                    result += c;
                }
            }

            return result;
        }
    }
}
