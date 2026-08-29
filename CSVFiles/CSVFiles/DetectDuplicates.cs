using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFiles
{
    public static class DetectDuplicates
    {
        public static void Run()
        {
            string filePath =
                Path.Combine(
                    "Data",
                    "students.csv");

            var records =
                CsvHelper.ReadCsv(filePath);

            HashSet<string> seenIds =
                new HashSet<string>();

            HashSet<string> duplicateIds =
                new HashSet<string>();

            foreach (var record in records)
            {
                string id = record[0];

                if (!seenIds.Add(id))
                {
                    duplicateIds.Add(id);
                }
            }

            if (duplicateIds.Count == 0)
            {
                Console.WriteLine(
                    "No duplicate IDs found.");

                return;
            }

            Console.WriteLine(
                "Duplicate Records");

            Console.WriteLine(
                "--------------------------------");

            foreach (var record in records)
            {
                if (duplicateIds.Contains(record[0]))
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
}
