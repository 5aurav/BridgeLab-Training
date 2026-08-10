using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.ListProblems
{
    internal class NthElementFromEnd
    {
        public static void Run()
        {
            LinkedList<string> list = new LinkedList<string>(
                new[] { "A", "B", "C", "D", "E" }
            );

            int n = 2;

            LinkedListNode<string> first = list.First;
            LinkedListNode<string> second = list.First;

            for (int i = 0; i < n; i++)
                second = second?.Next;

            while (second != null)
            {
                first = first?.Next;
                second = second.Next;
            }

            Console.WriteLine("Nth element from end: " + first?.Value);
        }
    }
}
