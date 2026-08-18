using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilder_and_StringReader
{
    internal class RemoveDuplicates
    {
        public static void Run()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                if (result.ToString().IndexOf(c) == -1)
                    result.Append(c);
            }

            Console.WriteLine($"Result: {result}");
        }
    }
}
