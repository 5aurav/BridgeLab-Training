using System;
using System.Collections.Generic;
using System.Text;

namespace Review6.Models
{
    public class Posts
    {
        public string PostId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public int Likes { get; set; }
        public int Shares { get; set; }
        public List<string> Hashtags { get; set; } = new List<string>();


        public double BaseScore { get; set; }
        public double FinalScore { get; set; }
    }
}
