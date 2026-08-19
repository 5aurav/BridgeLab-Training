using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Multiplayer_Game_System
{
    public class RatingSystem<T> where T : Player
    {
        private Dictionary<string, T> playersByID = new Dictionary<string, T>();

        private SortedList<int, List<T>> ratingOrder =
            new SortedList<int, List<T>>();

        private Queue<MatchRecord> matches =
            new Queue<MatchRecord>();

        private int kFactor;

        public Regex MatchRegex = new Regex(
            @"^MATCH:(?<MatchId>[^|]+)\|P1:(?<P1Name>[^()|]+)\((?<P1Rating>\d+)\)\|P2:(?<P2Name>[^()|]+)\((?<P2Rating>\d+)\)\|WINNER:(?<Winner>P1|P2|DRAW)\|DURATION:(?<Duration>\d+)s$"
        );

        public RatingSystem(int kFactor = 32)
        {
            if (kFactor <= 0)
            {
                throw new ArgumentException("K factor must be greater than zero.");
            }

            this.kFactor = kFactor;
        }

        public T AddPlayer(T player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            playersByID[player.Username] = player;

            if (!ratingOrder.ContainsKey(player.Rating))
            {
                ratingOrder.Add(player.Rating, new List<T>());
            }

            ratingOrder[player.Rating].Add(player);

            return player;
        }

        public void UpdatePlayer(T player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            if (!playersByID.TryGetValue(player.Username, out T existing))
            {
                AddPlayer(player);
                return;
            }

            int oldRating = existing.Rating;

            if (ratingOrder.TryGetValue(oldRating, out List<T> oldPlayers))
            {
                oldPlayers.RemoveAll(
                    p => p.Username == existing.Username
                );

                if (oldPlayers.Count == 0)
                {
                    ratingOrder.Remove(oldRating);
                }
            }

            existing.Rating = player.Rating;
            existing.MatchesPlayed = player.MatchesPlayed;

            if (!ratingOrder.ContainsKey(existing.Rating))
            {
                ratingOrder.Add(
                    existing.Rating,
                    new List<T>()
                );
            }

            ratingOrder[existing.Rating].Add(existing);
        }

        public List<KeyValuePair<int, T>> GenerateLeaderboard()
        {
            return playersByID.Values
                .OrderByDescending(p => p.Rating)
                .ThenByDescending(p => p.MatchesPlayed)
                .Select(p =>
                    new KeyValuePair<int, T>(
                        p.Rating,
                        p
                    ))
                .ToList();
        }

        public List<T> FindOpponents(
            int playerRating,
            int range,
            T P1)
        {
            if (range < 0)
            {
                throw new ArgumentException(
                    "Rating range cannot be negative."
                );
            }

            int minimumRating = playerRating - range;
            int maximumRating = playerRating + range;

            return ratingOrder
                .Where(p =>
                    p.Key >= minimumRating &&
                    p.Key <= maximumRating)
                .SelectMany(p => p.Value)
                .Where(p =>
                    P1 == null ||
                    p.Username != P1.Username)
                .OrderBy(p =>
                    Math.Abs(p.Rating - playerRating))
                .ThenByDescending(p =>
                    p.MatchesPlayed)
                .ToList();
        }

        public T PlayAMatch(T player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            T P1 = FindPlayer(player.Username);

            if (P1 == null)
            {
                throw new ArgumentException(
                    "Player does not exist."
                );
            }

            List<T> opponents =
                FindOpponents(P1.Rating, 100, P1);

            T P2 = opponents.FirstOrDefault();

            if (P2 == null)
            {
                throw new InvalidOperationException(
                    "No suitable opponent found."
                );
            }

            WinnerType win;

            if (P1.Rating >= P2.Rating)
            {
                win = WinnerType.P1;
            }
            else
            {
                win = WinnerType.P2;
            }

            (int newA, int newB) =
                EloCalculator.CalculateNewRating(
                    P1.Rating,
                    P2.Rating,
                    win,
                    kFactor
                );

            P1.Rating = newA;
            P2.Rating = newB;

            MatchRecord match = new MatchRecord(
                "IDBF34",
                P1.Username,
                P1.Rating,
                P2.Username,
                P2.Rating,
                win,
                800
            );

            matches.Enqueue(match);

            UpdateStats(matches.Dequeue());

            return P2;
        }

        public T FindPlayer(string id)
        {
            playersByID.TryGetValue(
                id,
                out T player
            );

            return player;
        }

        public void UpdateStats(MatchRecord match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            if (!ValidateMatch(match))
            {
                throw new ArgumentException(
                    "Invalid match record."
                );
            }

            T P1 = FindPlayer(match.P1Username);
            T P2 = FindPlayer(match.P2Username);

            if (P1 == null || P2 == null)
            {
                throw new InvalidOperationException(
                    "Both players must exist."
                );
            }

            P1.MatchesPlayed++;
            P2.MatchesPlayed++;

            UpdatePlayer(P1);
            UpdatePlayer(P2);
        }

        public MatchRecord ParseMatch(string matchText)
        {
            Match match = MatchRegex.Match(matchText);

            if (!match.Success)
            {
                throw new FormatException("Invalid match record.");
            }

            WinnerType winner;

            if (match.Groups["Winner"].Value == "P1")
            {
                winner = WinnerType.P1;
            }
            else if (match.Groups["Winner"].Value == "P2")
            {
                winner = WinnerType.P2;
            }
            else
            {
                winner = WinnerType.Draw;
            }

            return new MatchRecord(
                match.Groups["MatchId"].Value,
                match.Groups["P1Name"].Value,
                int.Parse(match.Groups["P1Rating"].Value),
                match.Groups["P2Name"].Value,
                int.Parse(match.Groups["P2Rating"].Value),
                winner,
                int.Parse(match.Groups["Duration"].Value)
            );
        }

        public bool ValidateMatch(MatchRecord matchPlayed)
        {
            if (matchPlayed == null)
            {
                return false;
            }

            string winner =
                matchPlayed.Winner == WinnerType.Draw
                    ? "DRAW"
                    : matchPlayed.Winner.ToString();

            string match =
                $"MATCH:{matchPlayed.MatchId}" +
                $"|P1:{matchPlayed.P1Username}({matchPlayed.P1Rating})" +
                $"|P2:{matchPlayed.P2Username}({matchPlayed.P2Rating})" +
                $"|WINNER:{winner}" +
                $"|DURATION:{matchPlayed.Duration}s";

            return MatchRegex.IsMatch(match);
        }
    }
}