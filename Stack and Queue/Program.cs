using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_and_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" STACK ");

            QueueUsingStacks.Run();
            SortStackRecursion.Run();
            StockSpan.Run();

            Console.WriteLine("\n QUEUE ");

            SlidingWindowMaximum.Run();
            CircularTour.Run();
        }
    }
}
