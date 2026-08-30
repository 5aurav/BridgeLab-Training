using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFileHandling
{
    public class IplCensorshipAnalyzer
    {
        public class IplMatch
        {
            public int MatchId { get; set; }

            public string Team1 { get; set; } = "";

            public string Team2 { get; set; } = "";

            public Dictionary<string, int> Score { get; set; }
                = new Dictionary<string, int>();

            public string Winner { get; set; } = "";

            public string PlayerOfMatch { get; set; } = "";
        }

        public void Run()
        {
            string jsonInput =
                "ipl_matches.json";

            string csvInput =
                "ipl_matches.csv";

            string jsonOutput =
                "censored_ipl_matches.json";

            string csvOutput =
                "censored_ipl_matches.csv";


            if (!File.Exists(jsonInput))
            {
                CreateSampleJsonFile(jsonInput);
            }

            if (!File.Exists(csvInput))
            {
                CreateSampleCsvFile(csvInput);
            }


            List<IplMatch> jsonMatches =
                ReadJson(jsonInput);


            List<IplMatch> csvMatches =
                ReadCsv(csvInput);


            CensorMatches(jsonMatches);

            CensorMatches(csvMatches);


            WriteJson(
                jsonOutput,
                jsonMatches
            );

            WriteCsv(
                csvOutput,
                csvMatches
            );


            Console.WriteLine(
                "IPL censorship completed."
            );

            Console.WriteLine();

            Console.WriteLine(
                "JSON Output: " + jsonOutput
            );

            Console.WriteLine(
                "CSV Output: " + csvOutput
            );
        }


        

        private static string MaskTeamName(
            string teamName)
        {
            string[] parts =
                teamName.Split(
                    ' ',
                    (char)StringSplitOptions.RemoveEmptyEntries
                );


            

            if (parts.Length == 2)
            {
                return parts[0] + " ***";
            }


            

            if (parts.Length >= 3)
            {
                return
                    parts[0]
                    + " *** "
                    + string.Join(
                        " ",
                        parts.Skip(2)
                    );
            }



            return "***";
        }




        private static void CensorMatches(
            List<IplMatch> matches)
        {
            foreach (IplMatch match in matches)
            {

                string originalTeam1 =
                    match.Team1;

                string originalTeam2 =
                    match.Team2;


                string maskedTeam1 =
                    MaskTeamName(originalTeam1);

                string maskedTeam2 =
                    MaskTeamName(originalTeam2);


                    match.Team1 =
                    maskedTeam1;

                match.Team2 =
                    maskedTeam2;


                if (match.Winner == originalTeam1)
                {
                    match.Winner =
                        maskedTeam1;
                }
                else if (match.Winner == originalTeam2)
                {
                    match.Winner =
                        maskedTeam2;
                }


                Dictionary<string, int>
                    newScore =
                        new Dictionary<string, int>();


                foreach (var score in match.Score)
                {
                    string newTeamName;


                    if (score.Key == originalTeam1)
                    {
                        newTeamName =
                            maskedTeam1;
                    }
                    else if (score.Key == originalTeam2)
                    {
                        newTeamName =
                            maskedTeam2;
                    }
                    else
                    {
                        newTeamName =
                            MaskTeamName(score.Key);
                    }


                    newScore[newTeamName] =
                        score.Value;
                }


                match.Score =
                    newScore;


                match.PlayerOfMatch =
                    "REDACTED";
            }
        }

        private static List<IplMatch> ReadJson(
            string fileName)
        {
            string json =
                File.ReadAllText(fileName);

            List<IplMatch> matches =
                JsonConvert.DeserializeObject<
                    List<IplMatch>
                >(json);

            return matches
                ?? new List<IplMatch>();
        }


        private static List<IplMatch> ReadCsv(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            List<IplMatch> matches =
                new List<IplMatch>();

            if (lines.Length < 2)
            {
                return matches;
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] values = line.Split(',');

                if (values.Length < 7)
                {
                    Console.WriteLine(
                        $"Invalid CSV row at line {i + 1}: {line}"
                    );

                    continue;
                }

                for (int j = 0; j < values.Length; j++)
                {
                    values[j] = values[j].Trim();
                }

                if (!int.TryParse(values[0], out int matchId))
                {
                    Console.WriteLine(
                        $"Invalid Match ID at line {i + 1}: {values[0]}"
                    );

                    continue;
                }
                if (!int.TryParse(values[3], out int scoreTeam1))
                {
                    Console.WriteLine(
                        $"Invalid Team 1 score at line {i + 1}: {values[3]}"
                    );

                    continue;
                }
                if (!int.TryParse(values[4], out int scoreTeam2))
                {
                    Console.WriteLine(
                        $"Invalid Team 2 score at line {i + 1}: {values[4]}"
                    );

                    continue;
                }

                string team1 = values[1];
                string team2 = values[2];

                IplMatch match =
                    new IplMatch
                    {
                        MatchId = matchId,

                        Team1 = team1,

                        Team2 = team2,

                        Score =
                            new Dictionary<string, int>
                            {
                                [team1] = scoreTeam1,

                                [team2] = scoreTeam2
                            },

                        Winner = values[5],

                        PlayerOfMatch = values[6]
                    };

                matches.Add(match);
            }

            return matches;
        }



        private static void WriteJson(
            string fileName,
            List<IplMatch> matches)
        {
            string json =
                JsonConvert.SerializeObject(
                    matches,
                    Formatting.Indented
                );


            File.WriteAllText(
                fileName,
                json
            );
        }



        private static void WriteCsv(
            string fileName,
            List<IplMatch> matches)
        {
            using (StreamWriter writer =
                new StreamWriter(fileName))
            {

                writer.WriteLine(
                    "match_id,team1,team2," +
                    "score_team1,score_team2," +
                    "winner,player_of_match"
                );


                foreach (IplMatch match in matches)
                {
                    List<int> scores =
                        match.Score.Values.ToList();


                    int score1 =
                        scores.Count > 0
                            ? scores[0]
                            : 0;


                    int score2 =
                        scores.Count > 1
                            ? scores[1]
                            : 0;


                    writer.WriteLine(
                        match.MatchId
                        + ","
                        + match.Team1
                        + ","
                        + match.Team2
                        + ","
                        + score1
                        + ","
                        + score2
                        + ","
                        + match.Winner
                        + ","
                        + match.PlayerOfMatch
                    );
                }
            }
        }


        private static void CreateSampleJsonFile(
            string fileName)
        {
            string json = @"[
  {
    ""MatchId"": 101,
    ""Team1"": ""Mumbai Indians"",
    ""Team2"": ""Chennai Super Kings"",
    ""Score"": {
      ""Mumbai Indians"": 178,
      ""Chennai Super Kings"": 182
    },
    ""Winner"": ""Chennai Super Kings"",
    ""PlayerOfMatch"": ""MS Dhoni""
  },
  {
    ""MatchId"": 102,
    ""Team1"": ""Royal Challengers Bangalore"",
    ""Team2"": ""Delhi Capitals"",
    ""Score"": {
      ""Royal Challengers Bangalore"": 200,
      ""Delhi Capitals"": 190
    },
    ""Winner"": ""Royal Challengers Bangalore"",
    ""PlayerOfMatch"": ""Virat Kohli""
  }
]";


            File.WriteAllText(
                fileName,
                json
            );
        }

        private static void CreateSampleCsvFile(
            string fileName)
        {
            string csv = @"
        match_id,team1,team2,score_team1,score_team2,winner,player_of_match
        101,Mumbai Indians,Chennai Super Kings,178,182,Chennai Super Kings,MS Dhoni
        102,Royal Challengers Bangalore,Delhi Capitals,200,190,Royal Challengers Bangalore,Virat Kohli
        ";


            File.WriteAllText(
                fileName,
                csv
            );
        }
    }
}
