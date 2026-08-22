using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    public class DynamicObjectCreation
    {
        public static void Run()
        {
            Type type = typeof(Student);

            object studentObject = Activator.CreateInstance(type);

            if (studentObject == null)
            {
                Console.WriteLine("Object creation failed.");
                return;
            }

            Student student = (Student)studentObject;

            student.Name = "Saurav";
            student.Age = 21;

            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Age: {student.Age}");
        }
    }

    public class Student
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
    }
}
