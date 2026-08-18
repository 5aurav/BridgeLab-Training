using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    internal class SearchWordInSentences
    {
        public static void Run()
        {
            string[] sentences =
            {
                "C# is powerful",
                "Java is popular",
                "C# is easy to learn",
                "Python is simple"
            };

            Console.Write("Enter word: ");
            string word = Console.ReadLine();

            for (int i = 0; i < sentences.Length; i++)
            {
                if (sentences[i].IndexOf(
                    word,
                    StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine("Found in: " + sentences[i]);
                    Console.WriteLine("Index: " + i);
                    return;
                }
            }

            Console.WriteLine("Word not found.");
        }
    }
}
