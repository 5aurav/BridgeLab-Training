using BirdSanctuary;
using BirdSanctuary.Models;
using static BirdSanctuary.Models.Bird;

namespace BirdSanctuaryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BirdSanctuaryManager sanctuary = new BirdSanctuaryManager();

            sanctuary.AddBird(new Duck("B001", "Donald",Gender.Male));
            sanctuary.AddBird(new Ostrich("B002", "Olly",Gender.Female));
            sanctuary.AddBird(new Eagle("B003", "Freedom", Gender.Male));
            sanctuary.AddBird(new Eagle("B003", "Freedom", Gender.Male));

            sanctuary.RemoveBird("B002","bird is shifted to the other sancturay.");
            Console.WriteLine("\n");

            sanctuary.DisplayList();
        }
    }
}