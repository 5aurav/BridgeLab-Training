using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilder_and_StringReader
{
    internal class ReadFileLineByLine
    {
        public static void Run()
        {
            File.WriteAllText(
                "sample.txt",
                "Hello C#\nStreams are useful\nStreamReader reads line by line");

            using (StreamReader reader = new StreamReader("sample.txt"))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                    Console.WriteLine(line);
            }
        }
    }
}
