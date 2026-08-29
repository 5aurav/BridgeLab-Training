using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFiles
{
    public static class UpdateSalary
    {
        public static void Run()
        {
            string inputFile =
                Path.Combine(
                    "Data",
                    "employees.csv");

            string outputFile =
                Path.Combine(
                    "Output",
                    "employees_updated.csv");

            string[] headers =
            {
            "ID",
            "Name",
            "Department",
            "Salary"
        };

            var records =
                CsvHelper.ReadCsv(inputFile);

            List<string[]> updatedRecords =
                new List<string[]>();

            foreach (var record in records)
            {
                string id = record[0];

                string name = record[1];

                string department = record[2];

                double salary =
                    double.Parse(record[3]);

                if (department.Equals(
                    "IT",
                    StringComparison.OrdinalIgnoreCase))
                {
                    salary = salary * 1.10;
                }

                updatedRecords.Add(
                    new string[]
                    {
                    id,
                    name,
                    department,
                    salary.ToString("F2")
                    });
            }

            CsvHelper.WriteCsv(
                outputFile,
                headers,
                updatedRecords);

            Console.WriteLine(
                $"Updated CSV created: {outputFile}");
        }
    }
}
