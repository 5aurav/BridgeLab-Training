using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    internal class LargeFileSearch
    {
        public static void Run()
        {
            try
            {
                using (StreamReader reader = new StreamReader("large-log.txt"))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
