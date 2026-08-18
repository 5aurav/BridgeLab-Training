using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilder_and_StringReader
{
    internal class StringBuilderPerformance
    {
        public static void Run()
        {
            int count = 100000;

            Stopwatch sw = Stopwatch.StartNew();

            string text = "";

            for (int i = 0; i < count; i++)
                text += "C#";

            sw.Stop();

            Console.WriteLine($"String: {sw.ElapsedMilliseconds} ms");

            sw.Restart();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; i++)
                result.Append("C#");

            sw.Stop();

            Console.WriteLine($"StringBuilder: {sw.ElapsedMilliseconds} ms");
        }
    }
}
