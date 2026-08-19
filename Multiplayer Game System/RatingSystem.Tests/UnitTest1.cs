using Multiplayer_Game_System;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace GameSystem.Tests
{
    public class RatingSystemTests
    {
        [Test]
        public void PrseMatch_ShouldParseSuccessfully()
        {
            RatingSystem<Player> system =
                new RatingSystem<Player>();

            string match = "MATCH:M9231|" +
                "P1:knight_99(1450)|" +
                "P2:shadow_fox(1502)|" +
                "WINNER:P2|" +
                "DURATION:734s";

            MatchRecord result = system.ParseMatch(match);

            Assert.That(result.MatchId, Is.EqualTo("M9231"));
            Assert.That(
                result.P1Username,
                Is.EqualTo("knight_99"));
            Assert.That(
                result.P1Rating,
                Is.EqualTo(1450));
            Assert.That(
                result.P2Username,
                Is.EqualTo("shadow_fox"));
            Assert.That(
                result.P2Rating,
                Is.EqualTo(1502));
            Assert.That(
                result.Winner,
                Is.EqualTo(WinnerType.P2));
            Assert.That(
                result.Duration,
                Is.EqualTo(734));
        }

        [Test]
        public void ParseMatch_ShouldRejectMissingDuration()
        {
            RatingSystem<Player> system =
                new RatingSystem<Player>();

            string match =
                "MATCH:M9231|" +
                "P1:knight_99(1450)|" +
                "P2:shadow_fox(1502)|" +
                "WINNER:P2";

            Assert.Throws<FormatException>(
                () => system.ParseMatch(match));
        }


        [Test]
        public void ParseMatch_ShouldAcceptP1Winner()
        {
            RatingSystem<Player> system =
                new RatingSystem<Player>();

            string match =
                "MATCH:M9231|" +
                "P1:knight_99(1450)|" +
                "P2:shadow_fox(1502)|" +
                "WINNER:P1|" +
                "DURATION:734s";

            MatchRecord result =
                system.ParseMatch(match);

            Assert.That(
                result.Winner,
                Is.EqualTo(WinnerType.P1));
        }


        [Test]
        public void ParseMatch_ShouldAcceptP2Winner()
        {
            RatingSystem<Player> system =
                new RatingSystem<Player>();

            string match =
                "MATCH:M9231|" +
                "P1:knight_99(1450)|" +
                "P2:shadow_fox(1502)|" +
                "WINNER:P2|" +
                "DURATION:734s";

            MatchRecord result =
                system.ParseMatch(match);

            Assert.That(
                result.Winner,
                Is.EqualTo(WinnerType.P2));
        }

        [Test]
        public void ParseMatch_ShouldAcceptDraw()
        {
            RatingSystem<Player> system =
                new RatingSystem<Player>();

            string match =
                "MATCH:M9231|" +
                "P1:knight_99(1450)|" +
                "P2:shadow_fox(1502)|" +
                "WINNER:DRAW|" +
                "DURATION:734s";

            MatchRecord result =
                system.ParseMatch(match);

            Assert.That(
                result.Winner,
                Is.EqualTo(WinnerType.Draw));
        }

        [Test]
        public void ParseMatch_ShouldRejectInvalidWinner()
        {
            RatingSystem<Player> system =
                new RatingSystem<Player>();

            string match =
                "MATCH:M9231|" +
                "P1:knight_99(1450)|" +
                "P2:shadow_fox(1502)|" +
                "WINNER:P3|" +
                "DURATION:734s";

            Assert.Throws<FormatException>(
                () => system.ParseMatch(match));
        }






        [Test]
        public void Elo_ShouldCalculateCorrectRating_WhenP1Wins()
        {
            var result =
                EloCalculator.CalculateNewRating(
                    1500,
                    1500,
                    WinnerType.P1,
                    32);

            Assert.That(result.newA, Is.EqualTo(1516));
            Assert.That(result.newB, Is.EqualTo(1484));
        }

        [Test]
        public void Elo_ShouldCalculateCorrectRating_WhenP2Wins()
        {
            var result =
                EloCalculator.CalculateNewRating(
                    1500,
                    1500,
                    WinnerType.P2,
                    32);

            Assert.That(result.newA, Is.EqualTo(1484));
            Assert.That(result.newB, Is.EqualTo(1516));
        }

        [Test]
        public void Elo_ShouldCalculateCorrectRating_WhenDraw()
        {
            var result =
                EloCalculator.CalculateNewRating(
                    1500,
                    1500,
                    WinnerType.Draw,
                    32);

            Assert.That(result.newA, Is.EqualTo(1500));
            Assert.That(result.newB, Is.EqualTo(1500));
        }








        [Test]
        public void Leaderboard_ShouldOrderByRatingDescending()
        {
            RatingSystem<Player> system =
                new RatingSystem<Player>();

            Player p1 = new Player
            {
                Username = "player1",
                Rating = 1400,
                MatchesPlayed = 10
            };

            Player p2 = new Player
            {
                Username = "player2",
                Rating = 1600,
                MatchesPlayed = 5
            };

            Player p3 = new Player
            {
                Username = "player3",
                Rating = 1500,
                MatchesPlayed = 20
            };

            system.AddPlayer(p1);
            system.AddPlayer(p2);
            system.AddPlayer(p3);

            var leaderboard =
                system.GenerateLeaderboard();

            Assert.That(
                leaderboard[0].Value.Username,
                Is.EqualTo("player2"));

            Assert.That(
                leaderboard[1].Value.Username,
                Is.EqualTo("player3"));

            Assert.That(
                leaderboard[2].Value.Username,
                Is.EqualTo("player1"));
        }

        [Test]
        public void Leaderboard_ShouldUseMatchesPlayedAsTieBreaker()
        {
            RatingSystem<Player> system =
                new RatingSystem<Player>();

            Player p1 = new Player
            {
                Username = "player1",
                Rating = 1500,
                MatchesPlayed = 10
            };

            Player p2 = new Player
            {
                Username = "player2",
                Rating = 1500,
                MatchesPlayed = 20
            };

            system.AddPlayer(p1);
            system.AddPlayer(p2);

            var leaderboard =
                system.GenerateLeaderboard();

            Assert.That(
                leaderboard[0].Value.Username,
                Is.EqualTo("player2"));

            Assert.That(
                leaderboard[1].Value.Username,
                Is.EqualTo("player1"));
        }







        [Test]
        public void FindOpponents_ShouldReturnOnlyPlayersWithinRange()
        {
            RatingSystem<Player> system =
                new RatingSystem<Player>();

            Player currentPlayer = new Player
            {
                Username = "current",
                Rating = 1500,
                MatchesPlayed = 10
            };

            Player p1 = new Player
            {
                Username = "player1",
                Rating = 1450,
                MatchesPlayed = 5
            };

            Player p2 = new Player
            {
                Username = "player2",
                Rating = 1550,
                MatchesPlayed = 5
            };

            Player p3 = new Player
            {
                Username = "player3",
                Rating = 1700,
                MatchesPlayed = 5
            };

            system.AddPlayer(currentPlayer);
            system.AddPlayer(p1);
            system.AddPlayer(p2);
            system.AddPlayer(p3);

            List<Player> opponents =
                system.FindOpponents(
                    1500,
                    100,
                    currentPlayer);

            Assert.That(
                opponents,
                Has.Count.EqualTo(2));

            Assert.That(
    opponents.All(p => p.Rating >= 1400 && p.Rating <= 1600),
    Is.True);
        }







        [Test]
        public void FindOpponents_ShouldExcludeCurrentPlayer()
        {
            RatingSystem<Player> system =
                new RatingSystem<Player>();

            Player currentPlayer = new Player
            {
                Username = "current",
                Rating = 1500,
                MatchesPlayed = 10
            };

            Player opponent = new Player
            {
                Username = "opponent",
                Rating = 1505,
                MatchesPlayed = 5
            };

            system.AddPlayer(currentPlayer);
            system.AddPlayer(opponent);

            List<Player> opponents =
                system.FindOpponents(
                    1500,
                    100,
                    currentPlayer);

            Assert.That(
                opponents.Any(
                    p => p.Username == "current"),
                Is.False);

            Assert.That(
                opponents.Any(
                    p => p.Username == "opponent"),
                Is.True);
        }









        [Test]
        public void FindOpponents_ShouldOrderByClosestRating()
        {
            RatingSystem<Player> system =
                new RatingSystem<Player>();

            Player currentPlayer = new Player
            {
                Username = "current",
                Rating = 1500,
                MatchesPlayed = 10
            };

            Player p1 = new Player
            {
                Username = "player1",
                Rating = 1550,
                MatchesPlayed = 5
            };

            Player p2 = new Player
            {
                Username = "player2",
                Rating = 1490,
                MatchesPlayed = 5
            };

            Player p3 = new Player
            {
                Username = "player3",
                Rating = 1420,
                MatchesPlayed = 5
            };

            Player p4 = new Player
            {
                Username = "player4",
                Rating = 1510,
                MatchesPlayed = 5
            };

            system.AddPlayer(currentPlayer);
            system.AddPlayer(p1);
            system.AddPlayer(p2);
            system.AddPlayer(p3);
            system.AddPlayer(p4);

            List<Player> opponents =
                system.FindOpponents(
                    1500,
                    100,
                    currentPlayer);

            Assert.That(
                opponents[0].Username,
                Is.EqualTo("player2"));

            Assert.That(
                opponents[1].Username,
                Is.EqualTo("player4"));

            Assert.That(
                opponents[2].Username,
                Is.EqualTo("player1"));

            Assert.That(
                opponents[3].Username,
                Is.EqualTo("player3"));
        }
    }
}
