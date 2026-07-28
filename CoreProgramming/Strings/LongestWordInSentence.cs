using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class LongestWordInSentence
    {
        public static void display()
        {
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();

            string longestWord = FindLongestWord(sentence);

            Console.WriteLine("Longest Word: " + longestWord);
        }
        static string FindLongestWord(string sentence)
        {
            string[] words = sentence.Split(' ');

            string longestWord = "";

            foreach (string word in words)
            {
                if (word.Length > longestWord.Length)
                {
                    longestWord = word;
                }
            }

            return longestWord;
        }
    }
}
