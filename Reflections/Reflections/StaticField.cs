using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    public class StaticField
    {
        public static void Run()
        {
            Type type = typeof(Configuration);

            FieldInfo field = type.GetField(
                "API_KEY",
                BindingFlags.NonPublic | BindingFlags.Static);

            if (field == null)
            {
                Console.WriteLine("Field not found.");
                return;
            }

            Console.WriteLine($"Original API Key: {field.GetValue(null)}");

            field.SetValue(null, "NEW_API_KEY_123");

            Console.WriteLine($"Updated API Key: {field.GetValue(null)}");
        }
    }

    public class Configuration
    {
        private static string API_KEY = "OLD_API_KEY";
    }
}
