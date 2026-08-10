using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.QueueProblems
{
    internal class BinaryNumbers
    {
        public static void Run()
        {
            int n = 5;

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("1");

            for (int i = 0; i < n; i++)
            {
                string current = queue.Dequeue();

                Console.Write(current + " ");

                queue.Enqueue(current + "0");
                queue.Enqueue(current + "1");
            }

            Console.WriteLine();
        }
    }
}
