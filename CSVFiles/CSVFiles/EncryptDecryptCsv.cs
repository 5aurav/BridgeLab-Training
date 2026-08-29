using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSVFiles
{
    public static class EncryptDecryptCsv
    {
        private static readonly byte[] Key =
            Encoding.UTF8.GetBytes(
                "12345678901234567890123456789012");

        private static readonly byte[] IV =
            Encoding.UTF8.GetBytes(
                "1234567890123456");

        public static void Run()
        {
            string inputFile =
                Path.Combine(
                    "Data",
                    "employees.csv");

            string encryptedFile =
                Path.Combine(
                    "Output",
                    "employees_encrypted.csv");

            EncryptCsv(
                inputFile,
                encryptedFile);

            Console.WriteLine(
                "\nEncrypted CSV created.");

            DecryptCsv(
                encryptedFile);

            Console.WriteLine(
                "\nDecryption completed.");
        }

        private static string Encrypt(
            string plainText)
        {
            using (Aes aes =
                Aes.Create())
            {

                aes.Key = Key;

                aes.IV = IV;

                using (ICryptoTransform encryptor =
                    aes.CreateEncryptor())
                {

                    byte[] plainBytes =
                        Encoding.UTF8.GetBytes(
                            plainText);

                    byte[] encryptedBytes =
                        encryptor.TransformFinalBlock(
                            plainBytes,
                            0,
                            plainBytes.Length);

                    return Convert.ToBase64String(
                        encryptedBytes);
                }
            }
        }

        private static string Decrypt(
            string encryptedText)
        {
            using (Aes aes =
                Aes.Create())
            {

                aes.Key = Key;

                aes.IV = IV;

                using (ICryptoTransform decryptor =
                    aes.CreateDecryptor())
                {

                    byte[] encryptedBytes =
                        Convert.FromBase64String(
                            encryptedText);

                    byte[] decryptedBytes =
                        decryptor.TransformFinalBlock(
                            encryptedBytes,
                            0,
                            encryptedBytes.Length);

                    return Encoding.UTF8.GetString(
                        decryptedBytes);
                }
            }
        }

        private static void EncryptCsv(
            string inputFile,
            string outputFile)
        {
            var records =
                CsvHelper.ReadCsv(inputFile);

            List<string[]> encryptedRecords =
                new List<string[]>();

            foreach (var record in records)
            {
                string id = record[0];

                string name = record[1];

                string department = record[2];

                string salary =
                    Encrypt(record[3]);

                encryptedRecords.Add(
                    new string[]
                    {
                    id,
                    name,
                    department,
                    salary
                    });
            }

            string[] headers =
            {
            "ID",
            "Name",
            "Department",
            "EncryptedSalary"
        };

            CsvHelper.WriteCsv(
                outputFile,
                headers,
                encryptedRecords);
        }

        private static void DecryptCsv(
            string encryptedFile)
        {
            var records =
                CsvHelper.ReadCsv(
                    encryptedFile);

            Console.WriteLine(
                "\nDecrypted Employee Data");

            Console.WriteLine(
                "--------------------------------");

            foreach (var record in records)
            {
                string salary =
                    Decrypt(record[3]);

                Console.WriteLine(
                    $"ID: {record[0]}, " +
                    $"Name: {record[1]}, " +
                    $"Department: {record[2]}, " +
                    $"Salary: {salary}");
            }
        }
    }
}
