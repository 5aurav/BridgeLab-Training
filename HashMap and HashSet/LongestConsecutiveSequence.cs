using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap_and_HashSet
{
    class LongestConsecutiveSequence
    {
        public static void Run()
        {
            int[] arr =
            {
            100, 4, 200, 1, 3, 2
        };

            int result = FindLongest(arr);

            Console.WriteLine(
                "Longest consecutive sequence = " +
                result);
        }

        static int FindLongest(int[] arr)
        {
            HashSet<int> set =
                new HashSet<int>();

            foreach (int x in arr)
            {
                set.Add(x);
            }

            int longest = 0;

            foreach (int x in set)
            {
                if (!set.Contains(x - 1))
                {
                    int current = x;
                    int count = 1;

                    while (set.Contains(current + 1))
                    {
                        current++;
                        count++;
                    }

                    if (count > longest)
                        longest = count;
                }
            }

            return longest;
        }
    }
}
