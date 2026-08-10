using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.SetProblems
{
    internal class SetEquality
    {
        public static void Run()
        {
            HashSet<int> set1 = new HashSet<int>() { 1, 2, 3 };
            HashSet<int> set2 = new HashSet<int>() { 3, 2, 1 };

            Console.WriteLine(set1.SetEquals(set2));
        }
    }
}
