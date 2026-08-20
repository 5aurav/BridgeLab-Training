using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class FileNotFound
    {
        public static void Run()
        {
            try
            {
                string content = File.ReadAllText("data.txt");

                Console.WriteLine(content);
            }
            catch (IOException)
            {
                Console.WriteLine("File not found");
            }
        }
    }
}
