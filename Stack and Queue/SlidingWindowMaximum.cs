using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_and_Queue
{
    class SlidingWindowMaximum
    {
        public static void Run()
        {
            int[] arr = { 1, 3, -1, -3, 5, 3, 6, 7 };
            int k = 3;

            int[] result = FindMaximum(arr, k);

            Console.WriteLine("Maximum values:");

            foreach (int x in result)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();
        }

        static int[] FindMaximum(int[] arr, int k)
        {
            int[] result = new int[arr.Length - k + 1];

            LinkedList<int> deque = new LinkedList<int>();

            int index = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                while (deque.Count > 0 &&
                       deque.First.Value <= i - k)
                {
                    deque.RemoveFirst();
                }

                while (deque.Count > 0 &&
                       arr[deque.Last.Value] <= arr[i])
                {
                    deque.RemoveLast();
                }

                deque.AddLast(i);

                if (i >= k - 1)
                {
                    result[index] = arr[deque.First.Value];
                    index++;
                }
            }

            return result;
        }
    }
}
