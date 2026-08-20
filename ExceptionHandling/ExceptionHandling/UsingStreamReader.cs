using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class UsingStreamReader
    {
        public static void Run()
        {
            try
            {
                using (StreamReader reader = new StreamReader("info.txt"))
                {
                    string firstLine = reader.ReadLine();

                    Console.WriteLine(firstLine);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Error reading file");
            }
        }
    }
}
