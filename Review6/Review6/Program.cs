using Review6.IO;
using Review6.Outputs;
using Review6.Services;
using System;

class SocialMediaAnalyzer
{
    public static void Main(string[] args)
    {
        try
        {
            string postsPath = @"C:\Users\saura\source\repos\Review6\Review6\posts.csv";
            string hashtagsPath = @"C:\Users\saura\source\repos\Review6\Review6\hashtags.json";

            var trending = TrendingOperation.LoadFromFile(hashtagsPath);

            var posts = DataLoader.LoadFromCSVFile(postsPath);

            var scored = Analyzer.CalculateFinalScores(posts, trending);

            string ScoredPostJson = @"C:\Users\saura\source\repos\Review6\Review6\scored_posts.json";
            Reporter.SaveScoredPostsJson(ScoredPostJson, scored);

            string reportPath = @"C:\Users\saura\source\repos\Review6\Review6\trending_report.txt";
            Reporter.GenerateTrendingReportBuffered(reportPath, scored, trending);

            var top10 = Analyzer.GetTop10(scored);
            using var mem = Reporter.CreateLeaderboardSnapshotMemoryStream(top10);
            mem.Position = 0;
            var ok = Reporter.VerifyLeaderboardSnapshotRoundTrip(mem, top10);
            Console.WriteLine($"Binary leaderboard round-trip verification: {ok}");

            Console.WriteLine($"Scored posts saved to: {ScoredPostJson}");
            Console.WriteLine($"Trending report saved to: {reportPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.GetType().Name}: {ex.Message}");
        }
    }
}