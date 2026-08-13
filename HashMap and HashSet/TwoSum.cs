using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap_and_HashSet
{
    class TwoSum
    {
        public static void Run()
        {
            int[] arr =
            {
            2, 7, 11, 15
        };

            int target = 9;

            int[] result =
                FindTwoSum(arr, target);

            if (result[0] != -1)
            {
                Console.WriteLine(
                    "Index " +
                    result[0] +
                    " and Index " +
                    result[1]);
            }
            else
            {
                Console.WriteLine(
                    "No pair found");
            }
        }

        static int[] FindTwoSum(
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
                    return new int[]
                    {
                    map[needed],
                    i
                    };
                }

                if (!map.ContainsKey(arr[i]))
                {
                    map.Add(arr[i], i);
                }
            }

            return new int[]
            {
            -1,
            -1
            };
        }
    }
}
