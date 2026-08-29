using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFiles
{
    public static class WriteCsv
    {
        public static void Run()
        {
            string filePath =
                Path.Combine(
                    "Output",
                    "employees_created.csv");

            string[] headers =
            {
            "ID",
            "Name",
            "Department",
            "Salary"
        };

            List<string[]> employees =
                new List<string[]>
                {
                new string[]
                {
                    "101",
                    "Rahul",
                    "IT",
                    "60000"
                },

                new string[]
                {
                    "102",
                    "Priya",
                    "HR",
                    "50000"
                },

                new string[]
                {
                    "103",
                    "Amit",
                    "Finance",
                    "70000"
                },

                new string[]
                {
                    "104",
                    "Neha",
                    "IT",
                    "65000"
                },

                new string[]
                {
                    "105",
                    "Rohan",
                    "Marketing",
                    "55000"
                }
                };

            CsvHelper.WriteCsv(
                filePath,
                headers,
                employees);

            Console.WriteLine(
                $"CSV created successfully: {filePath}");
        }
    }
}

