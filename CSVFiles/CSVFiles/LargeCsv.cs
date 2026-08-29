using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFiles
{
    public static class LargeCsv
    {
        public static void Run()
        {
            string filePath =
                Path.Combine(
                    "Data",
                    "large.csv");

            if (!File.Exists(filePath))
            {
                Console.WriteLine(
                    "large.csv not found.");

                return;
            }

            int totalProcessed = 0;

            List<string> chunk =
                new List<string>(100);

            using (StreamReader reader =
                new StreamReader(filePath)) { 
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    chunk.Clear();

                    for (int i = 0; i < 100; i++)
                    {
                        string line =
                            reader.ReadLine();

                        if (line == null)
                            break;

                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            chunk.Add(line);
                        }
                    }
                }

                foreach (string line in chunk)
                {

                    totalProcessed++;
                }

                Console.WriteLine(
                    $"Processed {totalProcessed} records.");
            }

            Console.WriteLine(
                $"Finished. Total records: {totalProcessed}");
        }
    }
}
