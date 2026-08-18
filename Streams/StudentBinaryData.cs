using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    internal class StudentBinaryData
    {
        public static void Run()
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open("student.dat", FileMode.Create)))
                {
                    writer.Write(101);
                    writer.Write("Saurav");
                    writer.Write(8.7);
                }

                using (BinaryReader reader = new BinaryReader(File.Open("student.dat", FileMode.Open)))
                {
                    Console.WriteLine($"Roll: {reader.ReadInt32()}");
                    Console.WriteLine($"Name: {reader.ReadString()}");
                    Console.WriteLine($"GPA: {reader.ReadDouble()}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
