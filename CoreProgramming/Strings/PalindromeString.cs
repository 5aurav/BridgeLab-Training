using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class PalindromeString
    {
        public static void display()
        {
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            bool result = IsPalindrome(text);

            if (result)
            {
                Console.WriteLine("The string is a palindrome.");
            }
            else
            {
                Console.WriteLine("The string is not a palindrome.");
            }
        }
        static bool IsPalindrome(string text)
        {
            int start = 0;
            int end = text.Length - 1;

            while (start < end)
            {
                if (text[start] != text[end])
                {
                    return false;
                }

                start++;
                end--;
            }

            return true;
        }
    }
}
