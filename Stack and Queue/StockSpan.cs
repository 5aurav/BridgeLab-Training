using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_and_Queue
{
    class StockSpan
    {
        public static void Run()
        {
            int[] prices = { 100, 80, 60, 70, 60, 75, 85 };

            int[] result = FindSpan(prices);

            Console.WriteLine("Prices:");
            foreach (int x in prices)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine("\nSpan:");

            foreach (int x in result)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();
        }

        static int[] FindSpan(int[] prices)
        {
            int[] span = new int[prices.Length];

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < prices.Length; i++)
            {
                while (stack.Count > 0 &&
                       prices[stack.Peek()] <= prices[i])
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    span[i] = i + 1;
                }
                else
                {
                    span[i] = i - stack.Peek();
                }

                stack.Push(i);
            }

            return span;
        }
    }
}
