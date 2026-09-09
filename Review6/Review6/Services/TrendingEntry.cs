using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Review6.Services
{
    public class TrendingEntry
    {
        public string Tag { get; set; } = string.Empty;
        public double Multiplier { get; set; } = 1.0;
    }

    public class TrendingOperation
    {
        public List<TrendingEntry> Trending { get; set; } = new List<TrendingEntry>();
        public static TrendingOperation LoadFromFile(string filePath)
        {
            using FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var obj = JsonSerializer.Deserialize<TrendingOperation>(fs) ?? new TrendingOperation();
            return obj;

        }

        public Dictionary<string, double> AsDictionary()
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            foreach(TrendingEntry entry in Trending)
            {
                dict[entry.Tag] = entry.Multiplier;
            }
            return dict;
        }
    }
}
