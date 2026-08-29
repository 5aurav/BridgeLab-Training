using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFiles
{
    public static class FilterRecords
    {
        public static void Run()
        {
            string filePath =
                Path.Combine(
                    "Data",
                    "students.csv");

            var records =
                CsvHelper.ReadCsv(filePath);

            Console.WriteLine(
                "Students who scored more than 80:");

            Console.WriteLine(
                "--------------------------------");

            foreach (var record in records)
            {
                int marks =
                    int.Parse(record[3]);

                if (marks > 80)
                {
                    Console.WriteLine(
                        $"ID: {record[0]}, " +
                        $"Name: {record[1]}, " +
                        $"Marks: {marks}");
                }
            }
        }
    }
}
