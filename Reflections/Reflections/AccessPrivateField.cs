using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    public class AccessPrivateField
    {
        public static void Run()
        {
            Person person = new Person();

            Type type = typeof(Person);

            FieldInfo field = type.GetField(
                "age",
                BindingFlags.NonPublic | BindingFlags.Instance);

            if (field == null)
            {
                Console.WriteLine("Field not found.");
                return;
            }

            field.SetValue(person, 25);

            object value = field.GetValue(person);

            Console.WriteLine($"Age: {value}");
        }
    }

    public class Person
    {
        private int age;
    }
}
