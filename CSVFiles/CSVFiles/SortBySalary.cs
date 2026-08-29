using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFiles
{
    public static class SortBySalary
    {
        public static void Run()
        {
            string filePath =
                Path.Combine(
                    "Data",
                    "employees.csv");

            var records =
                CsvHelper.ReadCsv(filePath);

            var sortedRecords =
                records
                    .OrderByDescending(
                        record =>
                            double.Parse(record[3]))
                    .Take(5);

            Console.WriteLine(
                "Top 5 Highest-Paid Employees");

            Console.WriteLine(
                "--------------------------------");

            foreach (var record in sortedRecords)
            {
                Console.WriteLine(
                    $"Name: {record[1]}, " +
                    $"Department: {record[2]}, " +
                    $"Salary: {record[3]}");
            }
        }
    }
}
