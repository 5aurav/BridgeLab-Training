using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.MapProblems
{
    internal class InvertMap
    {
        public static void Run()
        {
            Dictionary<string, int> original = new Dictionary<string, int>()
        {
            { "A", 1 },
            { "B", 2 },
            { "C", 1 }
        };

            Dictionary<int, List<string>> inverted = new Dictionary<int, List<string>>();

            foreach (var item in original)
            {
                if (!inverted.ContainsKey(item.Value))
                    inverted[item.Value] = new List<string>();

                inverted[item.Value].Add(item.Key);
            }

            foreach (var item in inverted)
                Console.WriteLine($"{item.Key}: {string.Join(", ", item.Value)}");
        }
    }
}
