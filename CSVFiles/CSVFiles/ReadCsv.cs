using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFiles
{
    public static class ReadCsv
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
                "Student Records");

            Console.WriteLine(
                "--------------------------------");

            foreach (var record in records)
            {
                Console.WriteLine(
                    $"ID: {record[0]}, " +
                    $"Name: {record[1]}, " +
                    $"Age: {record[2]}, " +
                    $"Marks: {record[3]}");
            }
        }
    }
}
