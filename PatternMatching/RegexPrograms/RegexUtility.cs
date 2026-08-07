using System.Text.RegularExpressions;

namespace RegexPrograms
{
    public class RegexUtility
    {
        public bool ValidateUsername(string username)
        {
            string pattern = @"^[A-Za-z][A-Za-z0-9_]{4,14}$";
            return Regex.IsMatch(username, pattern);
        }
        public bool ValidateLicensePlate(string plate)
        {
            string pattern = @"^[A-Z]{2}[0-9]{4}$";
            return Regex.IsMatch(plate, pattern);
        }
        public bool ValidateHexColor(string color)
        {
            string pattern = @"^#[A-Fa-f0-9]{6}$";
            return Regex.IsMatch(color, pattern);
        }

        public List<string> ExtractEmails(string text)
        {
            string pattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";

            MatchCollection matches = Regex.Matches(text, pattern);

            List<string> emails = new List<string>();

            foreach (Match match in matches)
            {
                emails.Add(match.Value);
            }

            return emails;
        }
        public List<string> ExtractCapitalizedWords(string text)
        {
            string pattern = @"\b[A-Z][a-zA-Z]*\b";

            MatchCollection matches = Regex.Matches(text, pattern);

            List<string> words = new List<string>();

            foreach (Match match in matches)
            {
                words.Add(match.Value);
            }

            return words;
        }
        public List<string> ExtractDates(string text)
        {
            string pattern = @"\b\d{2}/\d{2}/\d{4}\b";

            MatchCollection matches = Regex.Matches(text, pattern);

            List<string> dates = new List<string>();

            foreach (Match match in matches)
            {
                dates.Add(match.Value);
            }

            return dates;
        }
        public List<string> ExtractLinks(string text)
        {
            string pattern = @"https?://[^\s]+";

            MatchCollection matches = Regex.Matches(text, pattern);

            List<string> links = new List<string>();

            foreach (Match match in matches)
            {
                links.Add(match.Value);
            }

            return links;
        }
        public string ReplaceMultipleSpaces(string text)
        {
            return Regex.Replace(text, @"\s+", " ");
        }
        public string CensorBadWords(string text)
        {
            string pattern = @"\b(damn|stupid)\b";

            return Regex.Replace(text, pattern, "****", RegexOptions.IgnoreCase);
        }
        public bool ValidateIPAddress(string ip)
        {
            string pattern = @"^((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])\.){3}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])$";

            return Regex.IsMatch(ip, pattern);
        }
        public bool ValidateCreditCard(string card)
        {
            string pattern = @"^(4\d{15}|5\d{15})$";

            return Regex.IsMatch(card, pattern);
        }
        public List<string> ExtractProgrammingLanguages(string text)
        {
            string pattern = @"\b(JavaScript|Java|Python|Go|C#|C\+\+)\b";

            MatchCollection matches = Regex.Matches(text, pattern);

            List<string> languages = new List<string>();

            foreach (Match match in matches)
            {
                languages.Add(match.Value);
            }

            return languages;
        }
        public List<string> ExtractCurrencyValues(string text)
        {
            string pattern = @"\$?\s?\d+\.\d{2}";

            MatchCollection matches = Regex.Matches(text, pattern);

            List<string> values = new List<string>();

            foreach (Match match in matches)
            {
                values.Add(match.Value.Trim());
            }

            return values;
        }
        public List<string> FindRepeatingWords(string text)
        {
            string pattern = @"\b(\w+)\s+\1\b";

            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

            List<string> repeatedWords = new List<string>();

            foreach (Match match in matches)
            {
                repeatedWords.Add(match.Groups[1].Value);
            }

            return repeatedWords;
        }
        public bool ValidateSSN(string ssn)
        {
            string pattern = @"^\d{3}-\d{2}-\d{4}$";

            return Regex.IsMatch(ssn, pattern);
        }

    }
}