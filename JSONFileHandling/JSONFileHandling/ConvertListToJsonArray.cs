using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    public class ConvertListToJsonArray
    {
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public string Department { get; set; } = "";
        }

        public void Run()
        {
            List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Aman",
                Department = "IT"
            },

            new Employee
            {
                Id = 2,
                Name = "Priya",
                Department = "HR"
            },

            new Employee
            {
                Id = 3,
                Name = "Rohan",
                Department = "Finance"
            }
        };

            string json = JsonConvert.SerializeObject(
                employees,
                Formatting.Indented
            );

            Console.WriteLine(json);
        }
    }
}
