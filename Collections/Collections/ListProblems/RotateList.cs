using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.ListProblems
{
    internal class RotateList
    {
        public static void Run()
        {
            List<int> numbers = new List<int> () { 10, 20, 30, 40, 50 };
            int rotate = 2;

            rotate %= numbers.Count;

            List<int> result = new List<int> ();

            for (int i = rotate; i < numbers.Count; i++)
                result.Add(numbers[i]);

            for (int i = 0; i < rotate; i++)
                result.Add(numbers[i]);

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
