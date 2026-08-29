using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSVFiles
{
    public static class ValidateCsv
    {
        public static void Run()
        {
            string filePath =
                Path.Combine(
                    "Data",
                    "employees_validation.csv");

            var records =
                CsvHelper.ReadCsv(filePath);

            string emailPattern =
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            string phonePattern =
                @"^\d{10}$";

            foreach (var record in records)
            {
                string id = record[0];

                string name = record[1];

                string email = record[2];

                string phone = record[3];

                bool validEmail =
                    Regex.IsMatch(
                        email,
                        emailPattern);

                bool validPhone =
                    Regex.IsMatch(
                        phone,
                        phonePattern);

                if (!validEmail ||
                    !validPhone)
                {
                    Console.WriteLine(
                        $"\nInvalid Row: {id}, {name}");

                    if (!validEmail)
                    {
                        Console.WriteLine(
                            "Error: Invalid email.");
                    }

                    if (!validPhone)
                    {
                        Console.WriteLine(
                            "Error: Phone must contain exactly 10 digits.");
                    }
                }
            }
        }
    }
}
