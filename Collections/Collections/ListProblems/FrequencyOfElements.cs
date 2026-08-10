using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.ListProblems
{
    internal class FrequencyOfElements
    {
        public static void Run()
        {
            List<string> items = new List<string>()
        {
            "apple", "banana", "apple", "orange"
        };

            Dictionary<string, int> frequency = new Dictionary<string, int>();

            foreach (string item in items)
            {
                if (frequency.ContainsKey(item))
                    frequency[item]++;
                else
                    frequency[item] = 1;
            }

            foreach (var item in frequency)
                Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
