using Review6.Exceptions;
using Review6.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Review6.IO
{
    public static class DataLoader
    {
        public static List<Posts> LoadFromCSVFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);
            using FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using StreamReader sr = new StreamReader(fs);
            List<string> lines = new List<string>();
            string? line = "";

            while ((line = sr.ReadLine()) != null){
                lines.Add(line);
            }
            if (lines.Count <= 1)
            {
                throw new Exception("Empty CSV file.");
            }
            var header = lines[0].Split(',');
            var expected = new[] { "PostId", "Author", "Likes", "Shares", "Hashtags" };
            if (header.Length < expected.Length)
                throw new Exception("CSV header invalid.");

            var posts = new List<Posts>();
            var ids = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var tagRegex = new Regex(@"^#[A-Za-z0-9_]+$");

            for (int i = 1; i < lines.Count; i++)
            {
                var sentence = lines[i];
                var parts = sentence.Split(',');
                if (parts.Length < 5)
                    throw new Exception($"Malformed CSV line {i + 1}");

                var postId = parts[0];
                var username = parts[1];
                if (!int.TryParse(parts[2], out var likes))
                    throw new Exception($"Invalid likes value at line {i + 1}");
                if (!int.TryParse(parts[3], out var shares))
                    throw new Exception($"Invalid shares value at line {i + 1}");

                if (likes < 0)
                    throw new NegativeEngagementException($"Negative likes for PostId={postId}");
                if (shares < 0)
                    throw new NegativeEngagementException($"Negative shares for PostId={postId}");

                if (!ids.Add(postId))
                    throw new DuplicatePostException($"Duplicate PostId found: {postId}");

                var tagsRaw = parts[4];
                var tags = tagsRaw.Length == 0 ? new List<string>() :
                    tagsRaw.Split(';').ToList();

                foreach (var t in tags)
                {
                    if (!tagRegex.IsMatch(t))
                        throw new MalformedHashtagException($"Malformed hashtag '{t}' in PostId={postId}");
                }

                posts.Add(new Posts
                {
                    PostId = postId,
                    Username = username,
                    Likes = likes,
                    Shares = shares,
                    Hashtags = tags
                });
            }

            return posts;

        }
    }
}
