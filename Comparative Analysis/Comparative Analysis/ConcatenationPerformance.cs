using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparative_Analysis
{
    internal class ConcatenationPerformance
    {
        static double StringConcatenation(int count)
        {
            string result = "";

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < count; i++)
            {
                result += "Hello";
            }

            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        static double StringBuilderConcatenation(int count)
        {
            StringBuilder builder = new StringBuilder();

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < count; i++)
            {
                builder.Append("Hello");
            }

            string result = builder.ToString();

            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public static void TestConcatenation(int count)
        {
            double stringTime = StringConcatenation(count);
            double stringBuilderTime = StringBuilderConcatenation(count);

            Console.WriteLine($"Operations: {count}");
            Console.WriteLine($"string: {stringTime:F3} ms");
            Console.WriteLine($"StringBuilder: {stringBuilderTime:F3} ms");
        }
    }
}
