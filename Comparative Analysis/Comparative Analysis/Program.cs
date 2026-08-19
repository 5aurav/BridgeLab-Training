using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparative_Analysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Linear Search vs Binary Search");
            SearchPerformance.TestSearch(1000);
            SearchPerformance.TestSearch(10000);
            SearchPerformance.TestSearch(1000000);

            Console.WriteLine("");
            Console.WriteLine("Sorting Performance Comparison");
            SortingPerformance.TestSorting(1000);
            SortingPerformance.TestSorting(10000);
            SortingPerformance.TestSorting(100000);

            Console.WriteLine("");
            ConcatenationPerformance.TestConcatenation(1000);
            ConcatenationPerformance.TestConcatenation(10000);
            ConcatenationPerformance.TestConcatenation(100000);

            Console.WriteLine("");
            Console.WriteLine("StreamReader vs FileStream Performance");
            ReadingFileEfficiency.TestFileReading(1L * 1024 * 1024);
            ReadingFileEfficiency.TestFileReading(10L * 1024 * 1024);
            ReadingFileEfficiency.TestFileReading(100L * 1024 * 1024);

            Console.WriteLine("");
            Console.WriteLine("Recursive vs Iterative Fibonacci");
            FibonacciCompare.TestFibonacci(10);
            FibonacciCompare.TestFibonacci(30);
            FibonacciCompare.TestFibonacci(40);
        }
    }
}
