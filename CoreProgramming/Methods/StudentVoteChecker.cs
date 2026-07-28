using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class StudentVoteChecker
    {
        public static void display()
        {
            int[] ages = new int[10];

            for (int i = 0; i < ages.Length; i++)
            {
                Console.Write("Enter age of Student " + (i + 1) + ": ");
                ages[i] = Convert.ToInt32(Console.ReadLine());

                if (CanStudentVote(ages[i]))
                {
                    Console.WriteLine("Can Vote");
                }
                else
                {
                    Console.WriteLine("Cannot Vote");
                }
            }
        }

        public static bool CanStudentVote(int age)
        {
            if (age < 0)
            {
                return false;
            }

            return age >= 18;
        }
    }
}
