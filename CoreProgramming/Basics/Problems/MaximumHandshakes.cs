using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Problems
{
    internal class MaximumHandshakes
    {
        public static void Run()
        {
            Console.Write("Enter number of students: ");
            int numberOfStudents = Convert.ToInt32(Console.ReadLine());

            int handshakes = (numberOfStudents * (numberOfStudents - 1)) / 2;

            Console.WriteLine("The maximum number of possible handshakes is " + handshakes);
        }
    }
}
