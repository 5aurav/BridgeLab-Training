using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    public class RetrieveAttributes
    {
        public static void Run()
        {
            Type type = typeof(AuthorExample);

            AuthorAttribute attribute =
                type.GetCustomAttribute<AuthorAttribute>();

            if (attribute == null)
            {
                Console.WriteLine("Author attribute not found.");
                return;
            }

            Console.WriteLine($"Author: {attribute.Name}");
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class AuthorAttribute : Attribute
    {
        public string Name { get; }

        public AuthorAttribute(string name)
        {
            Name = name;
        }
    }

    [Author("Saurav")]
    public class AuthorExample
    {
    }
}
