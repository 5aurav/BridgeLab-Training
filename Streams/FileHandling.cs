using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    internal class FileHandling
    {
        public static void Run()
        {
            try
            {
                using (FileStream input = new FileStream("input.txt", FileMode.Open))
                using (FileStream output = new FileStream("output.txt", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    int bytes;

                    while ((bytes = input.Read(buffer, 0, buffer.Length)) > 0)
                        output.Write(buffer, 0, bytes);
                }

                Console.WriteLine("File copied successfully.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Source file does not exist.");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
