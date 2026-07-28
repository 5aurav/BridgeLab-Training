using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class MostFrequentCharacter
    {
        public static void display()
        {
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();

            char result = FindMostFrequentCharacter(text);

            Console.WriteLine("Most Frequent Character: " + result);
        }
        static char FindMostFrequentCharacter(string text)
        {
            int maxCount = 0;
            char mostFrequent = text[0];

            for (int i = 0; i < text.Length; i++)
            {
                int count = 0;

                for (int j = 0; j < text.Length; j++)
                {
                    if (text[i] == text[j])
                    {
                        count++;
                    }
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    mostFrequent = text[i];
                }
            }

            return mostFrequent;
        }
    }
}
