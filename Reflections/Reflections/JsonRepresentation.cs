using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    public class JsonRepresentation
    {
        public static void Run()
        {
            Product product = new Product
            {
                Id = 101,
                Name = "Laptop",
                Price = 75000
            };

            string json = ToJson(product);

            Console.WriteLine(json);
        }

        public static string ToJson(object obj)
        {
            Type type = obj.GetType();

            StringBuilder json = new StringBuilder();

            json.Append("{");

            PropertyInfo[] properties = type.GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo property = properties[i];

                object value = property.GetValue(obj);

                json.Append($"\"{property.Name}\":");

                if (value is string)
                    json.Append($"\"{value}\"");
                else
                    json.Append(value);

                if (i < properties.Length - 1)
                    json.Append(",");
            }

            json.Append("}");

            return json.ToString();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public double Price { get; set; }
    }
}
