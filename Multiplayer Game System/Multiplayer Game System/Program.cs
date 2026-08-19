using System;
using System.Collections.Generic;

namespace Multiplayer_Game_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RatingSystem<Player> system =
                new RatingSystem<Player>(32);

            Player p1 = new Player
            {
                Username = "knight_99",
                Rating = 1450,
                MatchesPlayed = 10
            };

            Player p2 = new Player
            {
                Username = "shadow_fox",
                Rating = 1480,
                MatchesPlayed = 15
            };

            Player p3 = new Player
            {
                Username = "dragon_x",
                Rating = 1480,
                MatchesPlayed = 12
            };

            Player p4 = new Player
            {
                Username = "warrior_7",
                Rating = 1600,
                MatchesPlayed = 20
            };

            Player p5 = new Player
            {
                Username = "ninja_21",
                Rating = 1520,
                MatchesPlayed = 8
            };

            system.AddPlayer(p1);
            system.AddPlayer(p2);
            system.AddPlayer(p3);
            system.AddPlayer(p4);
            system.AddPlayer(p5);

            Console.WriteLine("LEADERBOARD");

            DisplayLeaderboard(system);

            Console.WriteLine();
            Console.WriteLine("FIND OPPONENTS");

            int rating = 1500;
            int range = 100;

            List<Player> opponents =
                system.FindOpponents(
                    rating,
                    range,
                    p1
                );

            if (opponents.Count > 0)
            {
                foreach (Player opponent in opponents)
                {
                    Console.WriteLine(
                        $"Opponent found: {opponent.Username} | " +
                        $"Rating: {opponent.Rating}"
                    );
                }
            }
            else
            {
                Console.WriteLine(
                    "No suitable opponent found."
                );
            }

            Console.WriteLine();
            Console.WriteLine("PLAY MATCH");

            Console.WriteLine(
                $"Before Match: {p1.Username} = {p1.Rating}"
            );

            Console.WriteLine(
                $"Before Match: {p2.Username} = {p2.Rating}"
            );

            system.PlayAMatch(p1);

            Console.WriteLine(
                $"After Match: {p1.Username} = {p1.Rating}"
            );

            Console.WriteLine(
                $"After Match: {p2.Username} = {p2.Rating}"
            );

            Console.WriteLine();
            Console.WriteLine("UPDATED LEADERBOARD");

            DisplayLeaderboard(system);

            Console.WriteLine();
            Console.WriteLine("FIND PLAYER");

            Player foundPlayer =
                system.FindPlayer("dragon_x");

            if (foundPlayer != null)
            {
                Console.WriteLine(
                    $"Player: {foundPlayer.Username}"
                );

                Console.WriteLine(
                    $"Rating: {foundPlayer.Rating}"
                );

                Console.WriteLine(
                    $"Matches Played: {foundPlayer.MatchesPlayed}"
                );
            }
            else
            {
                Console.WriteLine(
                    "Player not found."
                );
            }

            Console.WriteLine();
            Console.WriteLine("REGEX MATCH RECORD");

            MatchRecord record = new MatchRecord(
                "M9231",
                p1.Username,
                p1.Rating,
                p2.Username,
                p2.Rating,
                WinnerType.P2,
                734
            );

            bool valid =
                system.ValidateMatch(record);

            Console.WriteLine(
                $"Match is valid: {valid}"
            );

            Console.WriteLine();
            Console.WriteLine("PARSE MATCH RECORD");

            string matchText =
                "MATCH:M9231|" +
                "P1:knight_99(1450)|" +
                "P2:shadow_fox(1502)|" +
                "WINNER:P2|" +
                "DURATION:734s";

            MatchRecord parsedRecord =
                system.ParseMatch(matchText);

            Console.WriteLine(
                $"Match ID: {parsedRecord.MatchId}"
            );

            Console.WriteLine(
                $"P1: {parsedRecord.P1Username} | " +
                $"Rating: {parsedRecord.P1Rating}"
            );

            Console.WriteLine(
                $"P2: {parsedRecord.P2Username} | " +
                $"Rating: {parsedRecord.P2Rating}"
            );

            Console.WriteLine(
                $"Winner: {parsedRecord.Winner}"
            );

            Console.WriteLine(
                $"Duration: {parsedRecord.Duration} seconds"
            );

            Console.WriteLine();
            Console.WriteLine("ELO CALCULATION");

            var result =
                EloCalculator.CalculateNewRating(
                    1450,
                    1502,
                    WinnerType.P2,
                    32
                );

            Console.WriteLine(
                $"Player A New Rating: {result.newA}"
            );

            Console.WriteLine(
                $"Player B New Rating: {result.newB}"
            );
        }

        static void DisplayLeaderboard(
            RatingSystem<Player> system)
        {
            var leaderboard =
                system.GenerateLeaderboard();

            int position = 1;

            foreach (var player in leaderboard)
            {
                Console.WriteLine(
                    $"{position}. " +
                    $"{player.Value.Username} | " +
                    $"Rating: {player.Key} | " +
                    $"Matches: {player.Value.MatchesPlayed}"
                );

                position++;
            }
        }
    }
}