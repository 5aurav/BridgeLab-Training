using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilder_and_StringReader
{
    internal class ByteToCharacterStream
    {
        public static void Run()
        {
            File.WriteAllBytes(
                "data.txt",
                Encoding.UTF8.GetBytes("Hello C# Streams"));

            using (FileStream file = new FileStream(
                "data.txt",
                FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
}
