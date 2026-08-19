using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Multiplayer_Game_System
{
    public enum WinnerType
    {
        P1,
        P2,
        Draw
    }

    public class MatchRecord
    {
        public string MatchId { get; set; }
        public string P1Username { get; set; }
        public int P1Rating { get; set; }
        public string P2Username { get; set; }
        public int P2Rating { get; set; }
        public WinnerType Winner { get; set; }
        public int Duration { get; set; }

        public MatchRecord(
            string matchId,
            string p1Username,
            int p1Rating,
            string p2Username,
            int p2Rating,
            WinnerType winner,
            int duration)
        {
            MatchId = matchId;
            P1Username = p1Username;
            P1Rating = p1Rating;
            P2Username = p2Username;
            P2Rating = p2Rating;
            Winner = winner;
            Duration = duration;
        }
    }
}
