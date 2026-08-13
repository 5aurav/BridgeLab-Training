using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_and_Queue
{
    class QueueUsingStacks
    {
        static Stack<int> stack1 = new Stack<int>();
        static Stack<int> stack2 = new Stack<int>();

        public static void Run()
        {
            stack1.Clear();
            stack2.Clear();

            Enqueue(10);
            Enqueue(20);
            Enqueue(30);

            Console.WriteLine("Dequeue: " + Dequeue());

            Enqueue(40);

            Console.WriteLine("Dequeue: " + Dequeue());
            Console.WriteLine("Dequeue: " + Dequeue());

            Enqueue(50);

            Console.WriteLine("Dequeue: " + Dequeue());
            Console.WriteLine("Dequeue: " + Dequeue());
        }

        static void Enqueue(int value)
        {
            stack1.Push(value);
        }

        static int Dequeue()
        {
            if (stack1.Count == 0 && stack2.Count == 0)
            {
                Console.WriteLine("Queue is empty");
                return -1;
            }

            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }

            return stack2.Pop();
        }
    }
}
