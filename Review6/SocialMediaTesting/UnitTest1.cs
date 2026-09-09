using NUnit.Framework;
using Review6.Exceptions;
using Review6.IO;
using Review6.Models;
using Review6.Outputs;
using Review6.Services;

namespace SocialMediaTesting
{
    public class Tests
    {
        private TrendingOperation trending;
        [SetUp]
        public void Setup()
        {
            trending = new TrendingOperation
            {
                Trending = new List<TrendingEntry>
                {
                    new TrendingEntry { Tag = "#tech", Multiplier = 1.5 },
                    new TrendingEntry { Tag = "#coding", Multiplier = 1.3 },
                    new TrendingEntry { Tag = "#ai", Multiplier = 2.0 }
                }
            };
        }

        [Test]
        public void BasicScoreCalculation()
        {
            var p = new Posts { PostId = "A", Likes = 10, Shares = 5, Hashtags = new List<string>() };
            var list = Analyzer.CalculateFinalScores(new List<Posts> { p }, trending);
            Assert.That(p.BaseScore, Is.EqualTo(20));
            Assert.That(p.FinalScore, Is.EqualTo(20));
        }

        [Test]
        public void TrendingHashtagMultiplier_Applied()
        {
            var p = new Posts { PostId = "B", Likes = 10, Shares = 5, Hashtags = new List<string> { "#ai" } };
            Analyzer.CalculateFinalScores(new List<Posts> { p }, trending);
            Assert.That(p.FinalScore,Is.EqualTo(20*2.0));
        }

        [Test]
        public void MultipleHashtagRule_MaxMultiplierUsed()
        {
            var p = new Posts { PostId = "B", Likes = 10, Shares = 5, Hashtags = new List<string> { "#ai","#tech","#coding" } };
            Analyzer.CalculateFinalScores(new List<Posts> { p }, trending);
            Assert.That(p.FinalScore, Is.EqualTo(20 * 2.0));
        }

        [Test]
        public void NegativeLikes_Throws()
        {
            var csv = "PostId,Author,Likes,Shares,Hashtags\nP1,a,-1,0,#x\n";
            var path = Path.GetTempFileName();
            File.WriteAllText(path, csv);
            Assert.Throws<NegativeEngagementException>(() => DataLoader.LoadFromCSVFile(path));
        }

        [Test]
        public void NegativeShares_Throws()
        {
            var csv = "PostId,Author,Likes,Shares,Hashtags\nP1,a,1,-2,#x\n";
            var path = Path.GetTempFileName();
            File.WriteAllText(path, csv);
            Assert.Throws<NegativeEngagementException>(() => DataLoader.LoadFromCSVFile(path));
        }

        [Test]
        public void MalformedHashtag_Throws()
        {
            var csv = "PostId,Author,Likes,Shares,Hashtags\nP1,a,10,0,news\n";
            var path = Path.GetTempFileName();
            File.WriteAllText(path, csv);
            Assert.Throws<MalformedHashtagException>(() => DataLoader.LoadFromCSVFile(path));
        }

        [Test]
        public void DuplicatePostsId_Throws()
        {
            var csv = "PostId,Author,Likes,Shares,Hashtags\nP1,a,30,4,#x\nP1,a,20,0,#x";
            var path = Path.GetTempFileName();
            File.WriteAllText(path, csv);
            Assert.Throws<DuplicatePostException>(() => DataLoader.LoadFromCSVFile(path));
        }

        [Test]
        public void RankingOfTopPosts()
        {
            var posts = new List<Posts>
            {
                new Posts { PostId = "1", Likes = 10, Shares = 0, Hashtags = new List<string> { "#tech" } }, // base 10 *1.5 =15
                new Posts { PostId = "2", Likes = 100, Shares = 0, Hashtags = new List<string>() } // 100
            };
            var scored = Analyzer.CalculateFinalScores(posts, trending);
            Assert.That(scored.First().PostId, Is.EqualTo("2"));
        }

        [Test]
        public void EmptyHeaderOnlyInput_ReturnsEmptyList()
        {
            var csv = "PostId,Author,Likes,Shares,Hashtags\n";
            var path = Path.GetTempFileName();
            File.WriteAllText(path, csv);
            var posts = DataLoader.LoadFromCSVFile(path);
            Assert.That(posts, Is.Empty);
        }
    }
}
