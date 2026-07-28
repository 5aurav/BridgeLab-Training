using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class SubstringOccurrences
    {
        public static void display()
        {
            Console.Write("Enter the main string: ");
            string text = Console.ReadLine();

            Console.Write("Enter the substring: ");
            string sub = Console.ReadLine();

            int count = CountOccurrences(text, sub);

            Console.WriteLine("Occurrences: " + count);
        }
        static int CountOccurrences(string text, string sub)
        {
            int count = 0;

            for (int i = 0; i <= text.Length - sub.Length; i++)
            {
                bool found = true;

                for (int j = 0; j < sub.Length; j++)
                {
                    if (text[i + j] != sub[j])
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    count++;
                }
            }

            return count;
        }

    }
}
