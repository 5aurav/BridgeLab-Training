using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    internal class WordCounter
    {
        public static void Run()
        {
            try
            {
                Dictionary<string, int> words = new Dictionary<string, int>();

                using (StreamReader reader = new StreamReader("words.txt"))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        foreach (string word in line
                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            string w = word.ToLower();

                            words[w] = words.TryGetValue(w, out int c) ? c + 1 : 1;
                        }
                    }
                }

                foreach (var word in words
                    .OrderByDescending(x => x.Value)
                    .Take(5))
                {
                    Console.WriteLine($"{word.Key} : {word.Value}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
