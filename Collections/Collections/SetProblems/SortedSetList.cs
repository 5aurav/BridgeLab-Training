using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.SetProblems
{
    internal class SortedSetList
    {
        public static void Run()
        {
            HashSet<int> numbers = new HashSet<int>() { 5, 3, 9, 1 };

            List<int> sortedList = new List<int>(numbers);
            sortedList.Sort();

            Console.WriteLine(string.Join(", ", sortedList));
        }
    }
}
