using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    public class CustomObjectMapper
    {
        public static void Run()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>
        {
            { "Name", "Saurav" },
            { "Age", 21 },
            { "City", "Patiala" }
        };

            StudentMapper student =
                ToObject<StudentMapper>(
                    typeof(StudentMapper),
                    properties);

            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Age: {student.Age}");
            Console.WriteLine($"City: {student.City}");
        }

        public static T ToObject<T>(
            Type clazz,
            Dictionary<string, object> properties)
        {
            T obj = (T)Activator.CreateInstance(clazz);

            foreach (var property in properties)
            {
                PropertyInfo propertyInfo =
                    clazz.GetProperty(property.Key);

                if (propertyInfo != null && propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(obj, property.Value);
                }
            }

            return obj;
        }
    }

    public class StudentMapper
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string City { get; set; } = "";
    }
}
