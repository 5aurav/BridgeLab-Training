using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    internal class BufferedFileCopy
    {
        public static void Run()
        {
            string source = "largefile.bin";

            if (!File.Exists(source))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            byte[] buffer = new byte[4096];

            Stopwatch sw = Stopwatch.StartNew();

            using (FileStream input = new FileStream(source, FileMode.Open))
            using (FileStream output = new FileStream("normal.bin", FileMode.Create))
            {
                int bytes;
                while ((bytes = input.Read(buffer, 0, buffer.Length)) > 0)
                    output.Write(buffer, 0, bytes);
            }

            sw.Stop();
            Console.WriteLine($"Normal: {sw.ElapsedMilliseconds} ms");

            sw.Restart();

            using (FileStream inputFile = new FileStream(source, FileMode.Open))
            using (FileStream outputFile = new FileStream("buffered.bin", FileMode.Create))
            using (BufferedStream inputBuffer = new BufferedStream(inputFile, 4096))
            using (BufferedStream outputBuffer = new BufferedStream(outputFile, 4096))
            {
                int bytes;
                while ((bytes = inputBuffer.Read(buffer, 0, buffer.Length)) > 0)
                    outputBuffer.Write(buffer, 0, bytes);
            }

            sw.Stop();
            Console.WriteLine($"Buffered: {sw.ElapsedMilliseconds} ms");
        }
    }
}
