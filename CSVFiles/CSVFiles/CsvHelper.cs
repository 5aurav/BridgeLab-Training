using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFiles
{
    public static class CsvHelper
    {
        public static List<string[]> ReadCsv(
            string filePath,
            bool hasHeader = true)
        {
            List<string[]> records = new List<string[]>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine(
                    $"File not found: {filePath}");

                return records;
            }

            string[] lines = File.ReadAllLines(filePath);

            int startIndex = hasHeader ? 1 : 0;

            for (int i = startIndex; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;

                records.Add(ParseCsvLine(lines[i]));
            }

            return records;
        }

        public static string[] ReadHeader(string filePath)
        {
            if (!File.Exists(filePath))
                return Array.Empty<string>();

            string firstLine =
                File.ReadLines(filePath).FirstOrDefault();

            if (string.IsNullOrEmpty(firstLine))
                return Array.Empty<string>();

            return ParseCsvLine(firstLine);
        }

        public static string[] ParseCsvLine(string line)
        {
            List<string> fields =
                new List<string>();

            bool insideQuotes = false;

            string currentField = "";

            for (int i = 0; i < line.Length; i++)
            {
                char current = line[i];

                if (current == '"')
                {
                    if (insideQuotes &&
                        i + 1 < line.Length &&
                        line[i + 1] == '"')
                    {
                        currentField += '"';
                        i++;
                    }
                    else
                    {
                        insideQuotes = !insideQuotes;
                    }
                }
                else if (current == ',' &&
                         !insideQuotes)
                {
                    fields.Add(currentField);
                    currentField = "";
                }
                else
                {
                    currentField += current;
                }
            }

            fields.Add(currentField);

            return fields.ToArray();
        }

        public static string EscapeCsvField(
            string value)
        {
            if (value == null)
                return "";

            if (value.Contains(",") ||
                value.Contains("\"") ||
                value.Contains("\n"))
            {
                value = value.Replace(
                    "\"",
                    "\"\"");

                return $"\"{value}\"";
            }

            return value;
        }

        public static void WriteCsv(
            string filePath,
            string[] headers,
            List<string[]> records)
        {
            string directory =
                Path.GetDirectoryName(filePath);

            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (StreamWriter writer =
                new StreamWriter(filePath))
            {

                writer.WriteLine(
                    string.Join(
                        ",",
                        headers.Select(EscapeCsvField)));


                foreach (string[] record in records)
                {
                    writer.WriteLine(
                        string.Join(
                            ",",
                            record.Select(EscapeCsvField)));
                }
            }
        }
    }
}
