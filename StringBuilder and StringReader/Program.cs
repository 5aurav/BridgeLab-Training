using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilder_and_StringReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReverseString.Run();
            RemoveDuplicates.Run();
            ConcatenateStrings.Run();
            StringBuilderPerformance.Run();
            ReadFileLineByLine.Run();
            CountWordInFile.Run();
            ByteToCharacterStream.Run();
            ConsoleInputToFile.Run();
        }
    }
}
