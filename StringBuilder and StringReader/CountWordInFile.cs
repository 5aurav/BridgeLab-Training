using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilder_and_StringReader
{
    internal class CountWordInFile
    {
        public static void Run()
        {
            File.WriteAllText(
                "words.txt",
                "C# is easy. C# is powerful. C# is popular.");

            Console.Write("Enter word: ");
            string word = Console.ReadLine();

            int count = 0;

            using (StreamReader reader = new StreamReader("words.txt"))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    foreach (string w in line.Split(' '))
                    {
                        string cleanWord = w.Trim('.', ',', '!', '?');

                        if (cleanWord.Equals(
                            word,
                            StringComparison.OrdinalIgnoreCase))
                        {
                            count++;
                        }
                    }
                }
            }

            Console.WriteLine("Count: " + count);
        }
    }
}
