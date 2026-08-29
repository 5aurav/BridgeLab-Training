using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSVFiles
{
    public class JsonStudent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Marks { get; set; }
    }

    public static class JsonCsvConversion
    {
        public static void Run()
        {
            string jsonFile =
                Path.Combine(
                    "Data",
                    "students.json");

            string csvFile =
                Path.Combine(
                    "Output",
                    "students_from_json.csv");

            string outputJsonFile =
                Path.Combine(
                    "Output",
                    "students_from_csv.json");

            ConvertJsonToCsv(
                jsonFile,
                csvFile);

            ConvertCsvToJson(
                csvFile,
                outputJsonFile);
        }

        private static void ConvertJsonToCsv(
            string jsonFile,
            string csvFile)
        {
            string json =
                File.ReadAllText(jsonFile);

            List<JsonStudent> students =
                JsonSerializer.Deserialize<List<JsonStudent>>(
                    json);

            List<string[]> records =
                new List<string[]>();

            foreach (JsonStudent student in students)
            {
                records.Add(
                    new string[]
                    {
                    student.Id.ToString(),

                    student.Name,

                    student.Age.ToString(),

                    student.Marks.ToString()
                    });
            }

            string[] headers =
            {
            "ID",
            "Name",
            "Age",
            "Marks"
        };

            CsvHelper.WriteCsv(
                csvFile,
                headers,
                records);

            Console.WriteLine(
                $"JSON converted to CSV: {csvFile}");
        }

        private static void ConvertCsvToJson(
            string csvFile,
            string jsonFile)
        {
            var records =
                CsvHelper.ReadCsv(csvFile);

            List<JsonStudent> students =
                new List<JsonStudent>();

            foreach (var record in records)
            {
                JsonStudent student =
                    new JsonStudent
                    {
                        Id =
                            int.Parse(record[0]),

                        Name =
                            record[1],

                        Age =
                            int.Parse(record[2]),

                        Marks =
                            double.Parse(record[3])
                    };

                students.Add(student);
            }

            JsonSerializerOptions options =
                new JsonSerializerOptions
                {
                    WriteIndented = true
                };

            string json =
                JsonSerializer.Serialize(
                    students,
                    options);

            File.WriteAllText(
                jsonFile,
                json);

            Console.WriteLine(
                $"CSV converted to JSON: {jsonFile}");
        }
    }
}
