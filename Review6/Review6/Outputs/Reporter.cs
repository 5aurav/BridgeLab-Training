using Review6.Models;
using Review6.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Review6.Outputs
{
    public static class Reporter
    {
        public static void SaveScoredPostsJson(string path, List<Posts> posts)
        {
            var writerOptions = new JsonWriterOptions { Indented = true };

            using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            using Utf8JsonWriter jsonWriter = new Utf8JsonWriter(fs, writerOptions);

            jsonWriter.WriteStartArray();
            foreach (var p in posts)
            {
                jsonWriter.WriteStartObject();

                jsonWriter.WriteString("PostId", p.PostId ?? string.Empty);
                jsonWriter.WriteString("Author", p.Username ?? string.Empty);
                jsonWriter.WriteNumber("Likes", p.Likes);
                jsonWriter.WriteNumber("Shares", p.Shares);

                jsonWriter.WriteStartArray("Hashtags");
                if (p.Hashtags != null)
                {
                    foreach (var h in p.Hashtags)
                        jsonWriter.WriteStringValue(h);
                }
                jsonWriter.WriteEndArray();

                jsonWriter.WriteNumber("BaseScore", p.BaseScore);
                jsonWriter.WriteNumber("FinalScore", p.FinalScore);

                jsonWriter.WriteEndObject();
            }
            jsonWriter.WriteEndArray();
            jsonWriter.Flush();
        }

        public static void GenerateTrendingReportBuffered(string path, List<Posts> posts, TrendingOperation trending)
        {
            var dict = trending?.AsDictionary() ?? new Dictionary<string, double>();
            var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var tag in dict.Keys) counts[tag] = 0;

            foreach (var p in posts ?? Enumerable.Empty<Posts>())
            {
                foreach (var h in p.Hashtags ?? Enumerable.Empty<string>())
                {
                    if (counts.ContainsKey(h))
                        counts[h]++;
                }
            }

            using var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            using var buf = new BufferedStream(fs);
            using var sw = new StreamWriter(buf, Encoding.UTF8);
            sw.WriteLine("Trending Report");
            sw.WriteLine($"Generated: {DateTime.UtcNow:O}");
            sw.WriteLine();
            sw.WriteLine("Tag\tMultiplier\tCount");
            foreach (var kv in counts.OrderByDescending(kv => kv.Value).ThenBy(kv => kv.Key))
            {
                sw.WriteLine($"{kv.Key}\t{dict[kv.Key]}\t{kv.Value}");
            }
            sw.Flush();
        }

        public static MemoryStream CreateLeaderboardSnapshotMemoryStream(List<Posts> topPosts)
        {
            var ms = new MemoryStream();
            using (var bw = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
            {
                bw.Write(topPosts.Count);
                foreach (var p in topPosts)
                {
                    bw.Write(p.PostId);
                    bw.Write(p.FinalScore);
                }
                bw.Flush();
            }
            ms.Position = 0;
            return ms;
        }

        public static bool VerifyLeaderboardSnapshotRoundTrip(Stream snapshotStream, List<Posts> expected)
        {
            var read = new List<(string PostId, double Score)>();
            snapshotStream.Position = 0;
            using (var br = new BinaryReader(snapshotStream, Encoding.UTF8, leaveOpen: true))
            {
                var count = br.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    var id = br.ReadString();
                    var sc = br.ReadDouble();
                    read.Add((id, sc));
                }
            }

            if (read.Count != expected.Count) return false;
            for (int i = 0; i < expected.Count; i++)
            {
                if (!string.Equals(read[i].PostId, expected[i].PostId, StringComparison.OrdinalIgnoreCase)) return false;
                if (Math.Abs(read[i].Score - expected[i].FinalScore) > 0.0001) return false;
            }
            return true;
        }
    }
}
