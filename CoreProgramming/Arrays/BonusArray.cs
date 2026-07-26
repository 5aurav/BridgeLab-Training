using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class BonusArray
    {
        public static void Run()
        {
            double[,] emp = new double[10, 2];
            double[,] result = new double[10, 2];
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Enter salary: ");
                double salary = double.Parse(Console.ReadLine());
                Console.Write("Enter years of service: ");
                double years = double.Parse(Console.ReadLine());
                if (salary < 0 || years < 0)
                {
                    Console.WriteLine("Invalid input, Enter again: ");
                    i--;
                    continue;
                }
                emp[i, 0] = salary;
                emp[i, 1] = years;
            }
            double totalBonus = 0.0;
            double totalOldSalary = 0.0;
            double totalNewSalary = 0.0;
            for (int i = 0; i < 10; i++)
            {
                double salary = emp[i, 0];
                double years = emp[i, 1];
                double bonus;
                if (years > 5)
                {
                    bonus = salary * 0.05;
                }
                else
                {
                    bonus = salary * 0.02;
                }
                double newSalary = salary + bonus;
                result[i, 0] = bonus;
                result[i, 1] = newSalary;

                totalBonus += bonus;
                totalOldSalary += salary;
                totalNewSalary += newSalary;
            }
            Console.WriteLine("Total Bonus Paid: " + totalBonus);
            Console.WriteLine("Total Old Salary: " + totalOldSalary);
            Console.WriteLine("Total New Salary: " + totalNewSalary);
        }
    }
}
