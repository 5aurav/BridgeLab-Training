using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    public class SuppressWarnings
    {
        public static void Run()
        {
#pragma warning disable CS0618

            ArrayList numbers = new ArrayList();

            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);

            foreach (object number in numbers)
            {
                Console.WriteLine(number);
            }

#pragma warning restore CS0618
        }
    }
}
