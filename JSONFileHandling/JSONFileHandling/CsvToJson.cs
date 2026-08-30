using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    public class CsvToJson
    {
        public void Run()
        {
            string csvFile = "students.csv";
            string jsonFile = "students.json";

            if (!File.Exists(csvFile))
            {
                Console.WriteLine(
                    "students.csv not found."
                );

                return;
            }

            string[] lines =
                File.ReadAllLines(csvFile);

            if (lines.Length < 2)
            {
                Console.WriteLine(
                    "CSV does not contain any data."
                );

                return;
            }

            string[] headers =
                lines[0].Split(',');

            List<Dictionary<string, string>> records =
                new List<Dictionary<string, string>>();

            foreach (string line in lines.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] values =
                    line.Split(',');

                Dictionary<string, string> record =
                    new Dictionary<string, string>();

                for (int i = 0;
                     i < headers.Length &&
                     i < values.Length;
                     i++)
                {
                    record[headers[i]] = values[i];
                }

                records.Add(record);
            }

            string json =
                JsonConvert.SerializeObject(
                    records,
                    Formatting.Indented
                );

            File.WriteAllText(
                jsonFile,
                json
            );

            Console.WriteLine(
                $"JSON saved to {jsonFile}"
            );

            Console.WriteLine();
            Console.WriteLine(json);
        }
    }
}
