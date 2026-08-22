using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    public class JsonFieldProcessor
    {
        public static void Run()
        {
            UserJson user = new UserJson
            {
                Username = "Saurav",
                Age = 21,
                Email = "saurav@example.com"
            };

            string json = ConvertToJson(user);

            Console.WriteLine(json);
        }

        public static string ConvertToJson(object obj)
        {
            Type type = obj.GetType();

            FieldInfo[] fields =
                type.GetFields(
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Instance);

            StringBuilder json = new StringBuilder();

            json.Append("{");

            bool first = true;

            foreach (FieldInfo field in fields)
            {
                JsonFieldAttribute attribute =
                    field.GetCustomAttribute<JsonFieldAttribute>();

                if (attribute == null)
                {
                    continue;
                }

                if (!first)
                {
                    json.Append(",");
                }

                object value = field.GetValue(obj);

                json.Append("\"");
                json.Append(attribute.Name);
                json.Append("\":\"");

                json.Append(value);

                json.Append("\"");

                first = false;
            }

            json.Append("}");

            return json.ToString();
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class JsonFieldAttribute : Attribute
    {
        public string Name { get; set; }
    }

    public class UserJson
    {
        [JsonField(Name = "user_name")]
        public string Username;

        [JsonField(Name = "user_age")]
        public int Age;

        [JsonField(Name = "email")]
        public string Email;
    }
}
