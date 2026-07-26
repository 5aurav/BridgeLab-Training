using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class VotingEligibilty
    {
        public static void Run()
        {
            Console.WriteLine("Enter the number of students: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] students = new int[n];
            for (int i = 0; i < n; i++)
            {
                students[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                if (students[i] >= 18)
                {
                    Console.WriteLine("Student " + (i + 1) + " is eligible to vote.");
                }
                else
                {
                    Console.WriteLine("Student " + (i + 1) + " is not eligible to vote.");
                }
            }
        }
    }
}
