using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    internal class LowercaseFilter
    {
        public static void Run()
        {
            try
            {
                using (FileStream input = new FileStream("uppercase.txt", FileMode.Open))
                using (FileStream output = new FileStream("lowercase.txt", FileMode.Create))
                using (BufferedStream bufferedInput = new BufferedStream(input))
                using (BufferedStream bufferedOutput = new BufferedStream(output))
                using (StreamReader reader = new StreamReader(bufferedInput))
                using (StreamWriter writer = new StreamWriter(bufferedOutput))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                        writer.WriteLine(line.ToLower());

                    Console.WriteLine("Converted successfully.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
