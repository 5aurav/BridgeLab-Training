using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    public static class ImportantMethodAttributeScanner
    {
        public static void Run()
        {
            MethodInfo[] methods =
                typeof(Application).GetMethods(
                    BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.DeclaredOnly);

            foreach (MethodInfo method in methods)
            {
                ImportantMethodAttribute attribute =
                    method.GetCustomAttribute<ImportantMethodAttribute>();

                if (attribute != null)
                {
                    Console.WriteLine(
                        method.Name + " -> Level: " + attribute.Level);
                }
            }
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class ImportantMethodAttribute : Attribute
    {
        public string Level { get; }

        public ImportantMethodAttribute(string level = "HIGH")
        {
            Level = level;
        }
    }

    public class Application
    {
        [ImportantMethod]
        public void StartApplication()
        {
            Console.WriteLine("Application started.");
        }

        [ImportantMethod("LOW")]
        public void ShowHelp()
        {
            Console.WriteLine("Help displayed.");
        }

        public void NormalMethod()
        {
            Console.WriteLine("Normal method.");
        }
    }
}
