using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_and_Queue
{
    class SortStackRecursion
    {
        static Stack<int> stack = new Stack<int>();

        public static void Run()
        {
            stack.Clear();

            stack.Push(3);
            stack.Push(1);
            stack.Push(4);
            stack.Push(2);

            Console.WriteLine("Before sorting:");
            Display();

            Sort();

            Console.WriteLine("After sorting:");
            Display();
        }

        static void Sort()
        {
            if (stack.Count == 0)
                return;

            int x = stack.Pop();

            Sort();

            Insert(x);
        }

        static void Insert(int x)
        {
            if (stack.Count == 0 ||
                stack.Peek() <= x)
            {
                stack.Push(x);
                return;
            }

            int y = stack.Pop();

            Insert(x);

            stack.Push(y);
        }

        static void Display()
        {
            foreach (int x in stack)
            {
                Console.WriteLine(x);
            }
        }
    }
}
