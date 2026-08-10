using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.SetProblems
{
    internal class SymmetricDifference
    {
        public static void Run()
        {
            HashSet<int> set1 = new HashSet<int>() { 1, 2, 3 };
            HashSet<int> set2 = new HashSet<int>() { 3, 4, 5 };

            HashSet<int> result = new HashSet<int>(set1);
            result.SymmetricExceptWith(set2);

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
