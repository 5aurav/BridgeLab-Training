using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.QueueProblems
{
    internal class ReverseQueue
    {
        public static void Run()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            Stack<int> stack = new Stack<int>();

            while (queue.Count > 0)
                stack.Push(queue.Dequeue());

            while (stack.Count > 0)
                queue.Enqueue(stack.Pop());

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
