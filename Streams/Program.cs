using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileHandling.Run();
            BufferedFileCopy.Run();
            ConsoleInputFile.Run();
            EmployeeSerialization.Run();
            ImageByteArray.Run();
            LowercaseFilter.Run();
            StudentBinaryData.Run();
            PipeCommunication.Run();
            LargeFileSearch.Run();
            WordCounter.Run();
            Console.ReadLine();
        }
    }
}
