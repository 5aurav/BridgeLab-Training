using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class CountVowelsAndConsonants
    {
        public static void display()
        {
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            int vowels = CountVowels(text);
            int consonants = CountConsonants(text);

            Console.WriteLine("Vowels = " + vowels);
            Console.WriteLine("Consonants = " + consonants);
        }
        static int CountVowels(string text)
        {
            int count = 0;

            foreach (char ch in text.ToLower())
            {
                if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                {
                    count++;
                }
            }

            return count;
        }

        static int CountConsonants(string text)
        {
            int count = 0;

            foreach (char ch in text.ToLower())
            {
                if (ch >= 'a' && ch <= 'z')
                {
                    if (!(ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u'))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
