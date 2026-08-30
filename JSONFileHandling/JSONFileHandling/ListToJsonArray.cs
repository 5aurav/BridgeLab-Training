using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    public class ListToJsonArray
    {
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public int Marks { get; set; }
        }

        public void Run()
        {
            List<Student> students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "Rahul",
                Marks = 85
            },

            new Student
            {
                Id = 2,
                Name = "Priya",
                Marks = 92
            },

            new Student
            {
                Id = 3,
                Name = "Aman",
                Marks = 78
            }
        };

            string json = JsonConvert.SerializeObject(
                students,
                Formatting.Indented
            );

            Console.WriteLine(json);
        }
    }
}
