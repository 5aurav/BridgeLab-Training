using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class EmployeeBonus
    {
        public static void display()
        {
            double[,] employees = GenerateEmployeeData(10);
            double[,] salaryData = CalculateBonus(employees);

            Console.WriteLine("Emp\tOld Salary\tYears\tBonus\t\tNew Salary");

            for (int i = 0; i < salaryData.GetLength(0); i++)
            {
                Console.WriteLine(
                    (i + 1) + "\t" +
                    salaryData[i, 0] + "\t\t" +
                    employees[i, 1] + "\t" +
                    Math.Round(salaryData[i, 2], 2) + "\t\t" +
                    Math.Round(salaryData[i, 1], 2));
            }

            double[] totals = CalculateTotals(salaryData);

            Console.WriteLine();
            Console.WriteLine("Total Old Salary : " + Math.Round(totals[0], 2));
            Console.WriteLine("Total New Salary : " + Math.Round(totals[1], 2));
            Console.WriteLine("Total Bonus      : " + Math.Round(totals[2], 2));
        }

        public static double[,] GenerateEmployeeData(int size)
        {
            Random random = new Random();

            double[,] employees = new double[size, 2];

            for (int i = 0; i < size; i++)
            {
                employees[i, 0] = random.Next(10000, 100000);
                employees[i, 1] = random.Next(1, 11);
            }

            return employees;
        }

        public static double[,] CalculateBonus(double[,] employees)
        {
            int size = employees.GetLength(0);

            double[,] salaryData = new double[size, 3];

            for (int i = 0; i < size; i++)
            {
                double oldSalary = employees[i, 0];
                double years = employees[i, 1];

                double bonus;

                if (years > 5)
                {
                    bonus = oldSalary * 0.05;
                }
                else
                {
                    bonus = oldSalary * 0.02;
                }

                salaryData[i, 0] = oldSalary;
                salaryData[i, 1] = oldSalary + bonus;
                salaryData[i, 2] = bonus;
            }

            return salaryData;
        }

        public static double[] CalculateTotals(double[,] salaryData)
        {
            double oldSalaryTotal = 0;
            double newSalaryTotal = 0;
            double bonusTotal = 0;

            for (int i = 0; i < salaryData.GetLength(0); i++)
            {
                oldSalaryTotal += salaryData[i, 0];
                newSalaryTotal += salaryData[i, 1];
                bonusTotal += salaryData[i, 2];
            }

            return new double[]
            {
            oldSalaryTotal,
            newSalaryTotal,
            bonusTotal
            };
        }
    }
}
