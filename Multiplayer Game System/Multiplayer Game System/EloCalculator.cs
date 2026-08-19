using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplayer_Game_System
{
    public static class EloCalculator
    {
        public static (int newA, int newB) CalculateNewRating(
            int ratingA,
            int ratingB,
            WinnerType winner,
            int k)
        {
            double expectedA = 1.0 / (1.0 + Math.Pow(10, (ratingB - ratingA) / 400.0));
            double expectedB = 1.0 / (1.0 + Math.Pow(10, (ratingA - ratingB) / 400.0));

            double actualA;
            double actualB;

            if (winner == WinnerType.P1)
            {
                actualA = 1.0;
                actualB = 0.0;
            }
            else if (winner == WinnerType.P2)
            {
                actualA = 0.0;
                actualB = 1.0;
            }
            else
            {
                actualA = 0.5;
                actualB = 0.5;
            }

            int newA = (int)Math.Round(
                ratingA + k * (actualA - expectedA)
            );

            int newB = (int)Math.Round(
                ratingB + k * (actualB - expectedB)
            );

            return (newA, newB);
        }
    }
}
