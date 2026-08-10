using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.ListProblems
{
    internal class ReverseList
    {
        public static void Run()
        {
            ArrayList arrayList = new ArrayList { 1, 2, 3, 4, 5 };
            LinkedList<int> linkedList = new LinkedList<int>(new[] { 1, 2, 3, 4, 5 });

            for (int i = 0, j = arrayList.Count - 1; i < j; i++, j--)
            {
                object temp = arrayList[i];
                arrayList[i] = arrayList[j];
                arrayList[j] = temp;
            }

            LinkedList<int> reversed = new LinkedList<int>();

            foreach (int value in linkedList)
                reversed.AddFirst(value);

            Console.WriteLine("ArrayList: " + string.Join(", ", arrayList.ToArray()));
            Console.WriteLine("LinkedList: " + string.Join(", ", reversed));
        }
    }
}
