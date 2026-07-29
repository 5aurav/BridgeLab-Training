using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBuiltFunctions
{
    internal class PalindromeChecker
    {
        public static void Palindrome()
        {
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();
            bool isPalindrome = PalindromeCheck(text);
            if (isPalindrome)
            {
                Console.WriteLine($"{text} is a Palindrome string");
            }
            else
            {
                Console.WriteLine($"{text} is not a Palindrome string");
            }
        }
        public static bool PalindromeCheck(string text)
        {
            int l = 0, r = text.Length - 1 ;
            while (l < r)
            {
                if (text[l] != text[r])
                {
                    return false;
                }
                l++;
                r--;
            }
            return true;
        }
    }
}
