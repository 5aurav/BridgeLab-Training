using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparative_Analysis
{
    internal class ReadingFileEfficiency
    {
        static void CreateTestFile(string filePath, long sizeInBytes)
        {
            string line = "This is a test line for file reading performance.\n";
            byte[] data = Encoding.UTF8.GetBytes(line);

            using (FileStream stream = new FileStream(
                filePath,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None,
                8192,
                FileOptions.SequentialScan
            ))
            {
                long bytesWritten = 0;

                while (bytesWritten < sizeInBytes)
                {
                    int bytesToWrite = (int)Math.Min(
                        data.Length,
                        sizeInBytes - bytesWritten
                    );

                    stream.Write(data, 0, bytesToWrite);

                    bytesWritten += bytesToWrite;
                }
            }
        }

        static double ReadUsingStreamReader(string filePath)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.ReadLine() != null)
                {
                }
            }

            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        static double ReadUsingFileStream(string filePath)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            using (FileStream stream = new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                8192,
                FileOptions.SequentialScan
            ))
            {
                byte[] buffer = new byte[8192];

                while (stream.Read(buffer, 0, buffer.Length) > 0)
                {
                }
            }

            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public static void TestFileReading(long sizeInBytes)
        {
            string filePath = $"test_{sizeInBytes}.txt";

            Console.WriteLine($"Creating file of size approximately {sizeInBytes / (1024 * 1024)} MB...");

            CreateTestFile(filePath, sizeInBytes);

            Console.WriteLine("File created.");

            double streamReaderTime = ReadUsingStreamReader(filePath);
            double fileStreamTime = ReadUsingFileStream(filePath);

            Console.WriteLine($"File Size: {sizeInBytes / (1024 * 1024)} MB");
            Console.WriteLine($"StreamReader: {streamReaderTime:F3} ms");
            Console.WriteLine($"FileStream:   {fileStreamTime:F3} ms");

            File.Delete(filePath);
        }
    }
}
