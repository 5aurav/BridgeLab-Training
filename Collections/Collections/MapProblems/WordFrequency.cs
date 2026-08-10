using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.QueueProblems
{
    internal class WordFrequency
    {
        public static void Run()
        {
            string text = "Hello world, hello Java!";

            string[] words = text
                .ToLower()
                .Split(new[] { ' ', ',', '.', '!', '?' },
                    StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> frequency = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (frequency.ContainsKey(word))
                    frequency[word]++;
                else
                    frequency[word] = 1;
            }

            foreach (var item in frequency)
                Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
