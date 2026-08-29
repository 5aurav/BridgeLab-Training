using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFiles
{
    public static class SearchRecord
    {
        public static void Run()
        {
            string filePath =
                Path.Combine(
                    "Data",
                    "employees.csv");

            Console.Write(
                "Enter employee name to search: ");

            string searchName =
                Console.ReadLine();

            var records =
                CsvHelper.ReadCsv(filePath);

            bool found = false;

            foreach (var record in records)
            {
                string name = record[1];

                if (name.Equals(
                    searchName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(
                        "\nEmployee Found");

                    Console.WriteLine(
                        $"Name: {record[1]}");

                    Console.WriteLine(
                        $"Department: {record[2]}");

                    Console.WriteLine(
                        $"Salary: {record[3]}");

                    found = true;

                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine(
                    $"Employee '{searchName}' not found.");
            }
        }
    }
}
