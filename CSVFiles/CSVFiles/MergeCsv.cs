using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFiles
{
    public static class MergeCsv
    {
        public static void Run()
        {
            string file1 =
                Path.Combine(
                    "Data",
                    "students1.csv");

            string file2 =
                Path.Combine(
                    "Data",
                    "students2.csv");

            string outputFile =
                Path.Combine(
                    "Output",
                    "merged_students.csv");

            var students1 =
                CsvHelper.ReadCsv(file1);

            var students2 =
                CsvHelper.ReadCsv(file2);

            var merged =
                from student1 in students1

                join student2 in students2
                on student1[0] equals student2[0]

                select new string[]
                {
                student1[0],
                student1[1],
                student1[2],
                student2[1],
                student2[2]
                };

            List<string[]> result =
                merged.ToList();

            string[] headers =
            {
            "ID",
            "Name",
            "Age",
            "Marks",
            "Grade"
        };

            CsvHelper.WriteCsv(
                outputFile,
                headers,
                result);

            Console.WriteLine(
                $"Merged CSV created: {outputFile}");
        }
    }
}
