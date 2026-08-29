using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFiles
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Marks { get; set; }

        public override string ToString()
        {
            return
                $"ID: {Id}, " +
                $"Name: {Name}, " +
                $"Age: {Age}, " +
                $"Marks: {Marks}";
        }
    }

    public static class CsvToObjects
    {
        public static void Run()
        {
            string filePath =
                Path.Combine(
                    "Data",
                    "students.csv");

            var records =
                CsvHelper.ReadCsv(filePath);

            List<Student> students =
                new List<Student>();

            foreach (var record in records)
            {
                Student student =
                    new Student
                    {
                        Id = int.Parse(record[0]),

                        Name = record[1],

                        Age = int.Parse(record[2]),

                        Marks = double.Parse(record[3])
                    };

                students.Add(student);
            }

            Console.WriteLine(
                "Student Objects");

            Console.WriteLine(
                "--------------------------------");

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
