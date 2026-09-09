using Review6.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Review6.Services
{
    public class Analyzer
    {
        public static List<Posts> CalculateFinalScores(List<Posts> posts, TrendingOperation trending)
        {
            var dict = trending.AsDictionary();
            foreach (var p in posts)
            {
                p.BaseScore = p.Likes + (p.Shares * 2);
                double multiplier = 1.0;

                var matches = p.Hashtags.Where(h => dict.ContainsKey(h)).Select(h => dict[h]).ToList();
                if (matches.Any())
                {
                    multiplier = matches.Max();
                }
                p.FinalScore = Math.Round(p.BaseScore * multiplier, 2);
            }

            return posts.OrderByDescending(p => p.FinalScore).ThenByDescending(p => p.BaseScore).ToList();
        }

        public static List<Posts> GetTop10(List<Posts> posts)
        {
            return posts.OrderByDescending(p => p.FinalScore).ThenByDescending(p => p.BaseScore).Take(10).ToList();
        }
    }
}
