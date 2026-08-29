using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFiles
{
    public static class CountRows
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
                $"Number of records: {records.Count}");
        }

    }
}
