using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class GradeCalculator
    {
        public static void Run()
        {
            Console.Write("Enter the number of students: ");
            int totalStudents = int.Parse(Console.ReadLine());

            double[][] studentMarks = new double[totalStudents][];
            for (int i = 0; i < totalStudents; i++)
            {
                studentMarks[i] = new double[3];
            }
            double[] percentages = new double[totalStudents];
            string[] grades = new string[totalStudents];

            for (int i = 0; i < totalStudents; i++)
            {
                Console.WriteLine("\nStudent " + (i + 1));

                Console.Write("Enter Physics Marks: ");
                studentMarks[i][0] = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Chemistry Marks: ");
                studentMarks[i][1] = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Maths Marks: ");
                studentMarks[i][2] = Convert.ToDouble(Console.ReadLine());

                if (studentMarks[i][0] < 0 || studentMarks[i][1] < 0 || studentMarks[i][2] < 0)
                {
                    Console.WriteLine("Marks cannot be negative. Please enter positive values.");
                    i--;
                }
            }

            for (int i = 0; i < totalStudents; i++)
            {
                percentages[i] = (studentMarks[i][0] + studentMarks[i][1] + studentMarks[i][2]) / 3;

                if (percentages[i] >= 80)
                {
                    grades[i] = "A";
                }
                else if (percentages[i] >= 70)
                {
                    grades[i] = "B";
                }
                else if (percentages[i] >= 60)
                {
                    grades[i] = "C";
                }
                else if (percentages[i] >= 50)
                {
                    grades[i] = "D";
                }
                else if (percentages[i] >= 40)
                {
                    grades[i] = "E";
                }
                else
                {
                    grades[i] = "R";
                }
            }

            for (int i = 0; i < totalStudents; i++)
            {
                Console.WriteLine("\nStudent " + (i + 1) + "\n" +
                    "Physics: " + studentMarks[i][0] + "\n" +
                    "Chemistry: " + studentMarks[i][1] + "\n" +
                    "Maths: " + studentMarks[i][2] + "\n" +
                    "Percentage = " + percentages[i] + "\n" +
                    "Grade = " + grades[i]);
            }
        }
    }
}
