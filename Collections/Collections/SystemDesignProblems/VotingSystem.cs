using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.SystemDesignProblems
{
    public class VotingSystem
    {
        public static void Run()
        {
            Dictionary<string, int> votes = new Dictionary<string, int>();

            List<string> votingOrder = new List<string>();

            CastVote("Alice", votes, votingOrder);
            CastVote("Bob", votes, votingOrder);
            CastVote("Alice", votes, votingOrder);
            CastVote("Charlie", votes, votingOrder);
            CastVote("Bob", votes, votingOrder);
            CastVote("Alice", votes, votingOrder);

            Console.WriteLine("Vote Results:");

            foreach (var item in votes)
                Console.WriteLine($"{item.Key}: {item.Value}");

            SortedDictionary<string, int> sortedVotes =
                new SortedDictionary<string, int>(votes);

            Console.WriteLine("\nSorted Results:");

            foreach (var item in sortedVotes)
                Console.WriteLine($"{item.Key}: {item.Value}");

            Console.WriteLine("\nVoting Order:");

            foreach (string candidate in votingOrder)
                Console.WriteLine(candidate);
        }

        private static void CastVote(
            string candidate,
            Dictionary<string, int> votes,
            List<string> votingOrder)
        {
            if (votes.ContainsKey(candidate))
                votes[candidate]++;
            else
                votes[candidate] = 1;

            votingOrder.Add(candidate);
        }
    }
}
