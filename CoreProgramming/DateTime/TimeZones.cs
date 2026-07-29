using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAndTime
{
    internal class TimeZones
    {
        public static void display()
        {
            DateTime utc = DateTime.UtcNow;

            TimeZoneInfo gmt = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            TimeZoneInfo ist = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            TimeZoneInfo pst = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

            DateTime gmtTime = TimeZoneInfo.ConvertTimeFromUtc(utc, gmt);
            DateTime istTime = TimeZoneInfo.ConvertTimeFromUtc(utc, ist);
            DateTime pstTime = TimeZoneInfo.ConvertTimeFromUtc(utc, pst);

            Console.WriteLine("GMT : " + gmtTime.ToString("dd-MM-yyyy hh:mm:ss tt"));
            Console.WriteLine("IST : " + istTime.ToString("dd-MM-yyyy hh:mm:ss tt"));
            Console.WriteLine("PST : " + pstTime.ToString("dd-MM-yyyy hh:mm:ss tt"));
        }
    }
}
