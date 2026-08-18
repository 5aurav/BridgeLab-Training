using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    internal class ImageByteArray
    {
        public static void Run()
        {
            try
            {
                byte[] data = File.ReadAllBytes("input.jpg");

                using (MemoryStream memory = new MemoryStream(data))
                {
                    File.WriteAllBytes("output.jpg", memory.ToArray());
                }

                Console.WriteLine(
                    data.SequenceEqual(File.ReadAllBytes("output.jpg"))
                    ? "Images are identical."
                    : "Images are different.");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
