using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class StudentMarks
    {
        public static void display()
        {
            Console.Write("Enter Number of Students: ");
            int students = Convert.ToInt32(Console.ReadLine());

            int[,] marks = GenerateMarks(students);
            double[,] result = CalculateResult(marks);

            Console.WriteLine();
            Console.WriteLine("Stu\tPhy\tChem\tMath\tTotal\tAverage\tPercentage");

            for (int i = 0; i < students; i++)
            {
                Console.WriteLine(
                    (i + 1) + "\t" +
                    marks[i, 0] + "\t" +
                    marks[i, 1] + "\t" +
                    marks[i, 2] + "\t" +
                    result[i, 0] + "\t" +
                    result[i, 1] + "\t" +
                    result[i, 2]);
            }
        }

        public static int[,] GenerateMarks(int students)
        {
            Random random = new Random();

            int[,] marks = new int[students, 3];

            for (int i = 0; i < students; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    marks[i, j] = random.Next(10, 101);
                }
            }

            return marks;
        }

        public static double[,] CalculateResult(int[,] marks)
        {
            int students = marks.GetLength(0);

            double[,] result = new double[students, 3];

            for (int i = 0; i < students; i++)
            {
                int total = marks[i, 0] + marks[i, 1] + marks[i, 2];

                double average = (double)total / 3;
                double percentage = (double)total / 300 * 100;

                result[i, 0] = total;
                result[i, 1] = Math.Round(average, 2);
                result[i, 2] = Math.Round(percentage, 2);
            }

            return result;
        }
    }
}
