using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class ReplaceWordInSentence
    {
        public static void display()
        {
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();

            Console.Write("Enter the word to replace: ");
            string oldWord = Console.ReadLine();

            Console.Write("Enter the new word: ");
            string newWord = Console.ReadLine();

            string result = ReplaceWord(sentence, oldWord, newWord);

            Console.WriteLine("Modified Sentence: " + result);
        }
        static string ReplaceWord(string sentence, string oldWord, string newWord)
        {
            string[] words = sentence.Split(' ');
            string result = "";

            foreach (string word in words)
            {
                if (word == oldWord)
                {
                    result += newWord + " ";
                }
                else
                {
                    result += word + " ";
                }
            }

            return result.Trim();
        }
    }
}
