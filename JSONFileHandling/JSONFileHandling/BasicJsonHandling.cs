using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JSONFileHandling
{
    public class BasicJsonHandling
    {
        public class Student
        {
            public string Name { get; set; } = "";
            public int Age { get; set; }
            public string[] Subjects { get; set; }
        }

        public void Run()
        {
            Student student = new Student
            {
                Name = "Rahul",
                Age = 16,
                Subjects = new[]
                {
                "Mathematics",
                "Science",
                "English"
            }
            };

            string json = JsonConvert.SerializeObject(
                student,
                (Newtonsoft.Json.Formatting)System.Xml.Formatting.Indented
            );

            Console.WriteLine("Student JSON:");
            Console.WriteLine(json);
        }
    }
}
