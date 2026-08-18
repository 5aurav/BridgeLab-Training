using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilder_and_StringReader
{
    internal class ConcatenateStrings
    {
        public static void Run()
        {
            string[] words = { "Hello", " ", "World", " ", "C#" };

            StringBuilder result = new StringBuilder();

            foreach (string word in words)
                result.Append(word);

            Console.WriteLine(result);
        }
    }
}
