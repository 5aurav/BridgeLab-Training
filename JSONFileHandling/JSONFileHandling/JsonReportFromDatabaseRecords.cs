using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    public class JsonReportFromDatabaseRecords
    {
        public class EmployeeRecord
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public string Department { get; set; } = "";
            public double Salary { get; set; }
        }

        public void Run()
        {

            List<EmployeeRecord> records =
                new List<EmployeeRecord>
                {
                new EmployeeRecord
                {
                    Id = 1,
                    Name = "Rahul",
                    Department = "IT",
                    Salary = 65000
                },

                new EmployeeRecord
                {
                    Id = 2,
                    Name = "Priya",
                    Department = "HR",
                    Salary = 58000
                },

                new EmployeeRecord
                {
                    Id = 3,
                    Name = "Aman",
                    Department = "IT",
                    Salary = 72000
                }
                };

            var report = new
            {
                GeneratedAt = DateTime.Now,

                TotalRecords = records.Count,

                AverageSalary =
                    records.Average(x => x.Salary),

                Records = records
            };

            string json =
                JsonConvert.SerializeObject(
                    report,
                    Formatting.Indented
                );

            File.WriteAllText(
                "database_report.json",
                json
            );

            Console.WriteLine(
                "Report generated successfully."
            );

            Console.WriteLine();
            Console.WriteLine(json);
        }
    }
}
