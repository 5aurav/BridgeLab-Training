using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    internal class ConsoleInputFile
    {
        public static void Run()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
                using (StreamWriter writer = new StreamWriter("user.txt"))
                {
                    Console.Write("Name: ");
                    string name = reader.ReadLine();

                    Console.Write("Age: ");
                    string age = reader.ReadLine();

                    Console.Write("Language: ");
                    string language = reader.ReadLine();

                    writer.WriteLine($"{name}, {age}, {language}");

                    Console.WriteLine("Saved successfully.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
