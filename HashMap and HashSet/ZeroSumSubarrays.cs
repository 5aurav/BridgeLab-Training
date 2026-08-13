using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap_and_HashSet
{
    class ZeroSumSubarrays
    {
        public static void Run()
        {
            int[] arr =
            {
            6, 3, -1, -3, 4,
            -2, 2, 4, 6, -12, -7
        };

            FindSubarrays(arr);
        }

        static void FindSubarrays(int[] arr)
        {
            Dictionary<int, List<int>> map =
                new Dictionary<int, List<int>>();

            int sum = 0;

            map[0] = new List<int>();
            map[0].Add(-1);

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

                if (map.ContainsKey(sum))
                {
                    foreach (int start in map[sum])
                    {
                        Console.WriteLine(
                            "From " +
                            (start + 1) +
                            " to " +
                            i);
                    }
                }

                if (!map.ContainsKey(sum))
                {
                    map[sum] = new List<int>();
                }

                map[sum].Add(i);
            }
        }
    }
}
