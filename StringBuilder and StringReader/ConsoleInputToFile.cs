using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilder_and_StringReader
{
    internal class ConsoleInputToFile
    {
        public static void Run()
        {
            using (StreamReader reader =
                new StreamReader(Console.OpenStandardInput()))
            {
                using (StreamWriter writer =
                    new StreamWriter("user.txt"))
                {
                    Console.Write("Enter name: ");
                    string name = reader.ReadLine();

                    Console.Write("Enter age: ");
                    string age = reader.ReadLine();

                    Console.Write("Enter language: ");
                    string language = reader.ReadLine();

                    writer.WriteLine("Name: " + name);
                    writer.WriteLine("Age: " + age);
                    writer.WriteLine("Language: " + language);
                }
            }

            Console.WriteLine("Data saved.");
        }
    }
}
