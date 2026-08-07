using RegexPrograms;

namespace RegexPrograms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RegexUtility regexUtility = new RegexUtility();

            Console.WriteLine("========= REGEX PRACTICE =========");
            Console.WriteLine("1. Validate Username");
            Console.WriteLine("2. Validate License Plate");
            Console.WriteLine("3. Validate Hex Color");
            Console.WriteLine("4. Extract Email Addresses");
            Console.WriteLine("5. Extract Capitalized Words");
            Console.WriteLine("6. Extract Dates");
            Console.WriteLine("7. Extract Links");
            Console.WriteLine("8. Replace Multiple Spaces");
            Console.WriteLine("9. Censor Bad Words");
            Console.WriteLine("10. Validate IP Address");
            Console.WriteLine("11. Validate Credit Card");
            Console.WriteLine("12. Extract Programming Languages");
            Console.WriteLine("13. Extract Currency Values");
            Console.WriteLine("14. Find Repeating Words");
            Console.WriteLine("15. Validate SSN");
            Console.WriteLine();

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Username: ");
                    string username = Console.ReadLine()!;
                    Console.WriteLine(regexUtility.ValidateUsername(username)
                        ? "Valid Username"
                        : "Invalid Username");
                    break;

                case 2:
                    Console.Write("Enter License Plate: ");
                    string plate = Console.ReadLine()!;
                    Console.WriteLine(regexUtility.ValidateLicensePlate(plate)
                        ? "Valid License Plate"
                        : "Invalid License Plate");
                    break;

                case 3:
                    Console.Write("Enter Hex Color: ");
                    string color = Console.ReadLine()!;
                    Console.WriteLine(regexUtility.ValidateHexColor(color)
                        ? "Valid Hex Color"
                        : "Invalid Hex Color");
                    break;

                case 4:
                    Console.Write("Enter Text: ");
                    string emailText = Console.ReadLine()!;

                    List<string> emails = regexUtility.ExtractEmails(emailText);

                    Console.WriteLine("Emails Found:");

                    foreach (string email in emails)
                    {
                        Console.WriteLine(email);
                    }
                    break;

                case 5:
                    Console.Write("Enter Sentence: ");
                    string sentence = Console.ReadLine()!;

                    List<string> capitalWords = regexUtility.ExtractCapitalizedWords(sentence);

                    Console.WriteLine("Capitalized Words:");

                    foreach (string word in capitalWords)
                    {
                        Console.WriteLine(word);
                    }
                    break;

                case 6:
                    Console.Write("Enter Text: ");
                    string dateText = Console.ReadLine()!;

                    List<string> dates = regexUtility.ExtractDates(dateText);

                    Console.WriteLine("Dates Found:");

                    foreach (string date in dates)
                    {
                        Console.WriteLine(date);
                    }
                    break;

                case 7:
                    Console.Write("Enter Text: ");
                    string linkText = Console.ReadLine()!;

                    List<string> links = regexUtility.ExtractLinks(linkText);

                    Console.WriteLine("Links:");

                    foreach (string link in links)
                    {
                        Console.WriteLine(link);
                    }
                    break;

                case 8:
                    Console.Write("Enter Text: ");
                    string spaceText = Console.ReadLine()!;

                    Console.WriteLine();
                    Console.WriteLine("Result:");
                    Console.WriteLine(regexUtility.ReplaceMultipleSpaces(spaceText));
                    break;

                case 9:
                    Console.Write("Enter Sentence: ");
                    string badWordText = Console.ReadLine()!;

                    Console.WriteLine();
                    Console.WriteLine(regexUtility.CensorBadWords(badWordText));
                    break;

                case 10:
                    Console.Write("Enter IP Address: ");
                    string ip = Console.ReadLine()!;

                    Console.WriteLine(regexUtility.ValidateIPAddress(ip)
                        ? "Valid IP Address"
                        : "Invalid IP Address");
                    break;

                case 11:
                    Console.Write("Enter Credit Card Number: ");
                    string card = Console.ReadLine()!;

                    Console.WriteLine(regexUtility.ValidateCreditCard(card)
                        ? "Valid Credit Card"
                        : "Invalid Credit Card");
                    break;

                case 12:
                    Console.Write("Enter Text: ");
                    string languageText = Console.ReadLine()!;

                    List<string> languages = regexUtility.ExtractProgrammingLanguages(languageText);

                    Console.WriteLine("Languages Found:");

                    foreach (string language in languages)
                    {
                        Console.WriteLine(language);
                    }
                    break;

                case 13:
                    Console.Write("Enter Text: ");
                    string currencyText = Console.ReadLine()!;

                    List<string> values = regexUtility.ExtractCurrencyValues(currencyText);

                    Console.WriteLine("Currency Values:");

                    foreach (string value in values)
                    {
                        Console.WriteLine(value);
                    }
                    break;

                case 14:
                    Console.Write("Enter Sentence: ");
                    string repeatText = Console.ReadLine()!;

                    List<string> repeatedWords = regexUtility.FindRepeatingWords(repeatText);

                    Console.WriteLine("Repeated Words:");

                    foreach (string word in repeatedWords)
                    {
                        Console.WriteLine(word);
                    }
                    break;

                case 15:
                    Console.Write("Enter SSN: ");
                    string ssn = Console.ReadLine()!;

                    Console.WriteLine(regexUtility.ValidateSSN(ssn)
                        ? "Valid SSN"
                        : "Invalid SSN");
                    break;

                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }
        }
    }
}