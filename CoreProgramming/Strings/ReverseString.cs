using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class ReverseString
    {
        public static void display()
        {
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            string reversed = Reverse(text);

            Console.WriteLine("Reversed String: " + reversed);
        }
        static string Reverse(string text)
        {
            string reversed = "";

            for (int i = text.Length - 1; i >= 0; i--)
            {
                reversed += text[i];
            }

            return reversed;
        }
    }
}
