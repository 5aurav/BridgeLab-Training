using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Streams
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Department { get; set; } = "";
        public decimal Salary { get; set; }
    }

    public class EmployeeSerialization
    {
        public static void Run()
        {
            try
            {
                var employees = new List<Employee>
                {
                    new Employee() { Id = 1, Name = "Saurav", Department = "IT", Salary = 60000 },
                    new Employee() { Id = 2, Name = "Rahul", Department = "HR", Salary = 50000 }
                };

                File.WriteAllText(
                    "employees.json",
                    JsonSerializer.Serialize(employees));

                var data = JsonSerializer.Deserialize<List<Employee>>(
                    File.ReadAllText("employees.json"));

                foreach (var e in data)
                    Console.WriteLine($"{e.Id} {e.Name} {e.Department} {e.Salary}");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
