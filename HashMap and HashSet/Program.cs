using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap_and_HashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n HASH MAP ");

            ZeroSumSubarrays.Run();
            PairWithGivenSum.Run();
            CustomHashMap.Run();
            TwoSum.Run();

            Console.WriteLine("\n HASH SET ");

            LongestConsecutiveSequence.Run();
        }
    }
}
