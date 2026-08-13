using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap_and_HashSet
{
    class PairWithGivenSum
    {
        public static void Run()
        {
            int[] arr = { 2, 7, 11, 15 };
            int target = 9;

            FindPair(arr, target);
        }

        static void FindPair(
            int[] arr,
            int target)
        {
            Dictionary<int, int> map =
                new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int needed = target - arr[i];

                if (map.ContainsKey(needed))
                {
                    Console.WriteLine(
                        "Pair found: " +
                        needed +
                        " + " +
                        arr[i] +
                        " = " +
                        target);

                    return;
                }

                if (!map.ContainsKey(arr[i]))
                {
                    map.Add(arr[i], i);
                }
            }

            Console.WriteLine("Pair not found");
        }
    }
}
