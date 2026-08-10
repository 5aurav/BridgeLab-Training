using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.ListProblems
{
    internal class RemoveDuplicates
    {
        public static void Run()
        {
            List<int> numbers = new List<int>() { 3, 1, 2, 2, 3, 4 };

            HashSet<int> seen = new HashSet<int>();
            List<int> result = new List<int>();

            foreach (int number in numbers)
            {
                if (seen.Add(number))
                    result.Add(number);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
