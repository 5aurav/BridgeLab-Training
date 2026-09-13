using BirdSanctuary.Models;

namespace BirdSanctuary
{
    public class BirdSanctuaryManager
    {
        private readonly HashSet<Bird> _birds = new();

        public void AddBird(Bird bird)
        {
            if (!_birds.Add(bird))
            {
                Console.WriteLine(
                    $"Bird with ID {bird.Id} already exists in the sanctuary!");
            }
        }

        public void RemoveBird(string id, string message)
        {
            Bird? target = _birds.FirstOrDefault(b => b.Id == id);

            if (target != null)
            {
                _birds.Remove(target);

                Console.WriteLine(
                    $"{target.Name} is removed due to the reason {message}");
            }
            else
            {
                Console.WriteLine($"Bird with ID {id} not found.");
            }
        }

        public void DisplayList()
        {
            foreach (Bird bird in _birds)
            {
                Console.WriteLine($"ID: {bird.Id}");
                Console.WriteLine($"Name: {bird.Name}");
                Console.WriteLine($"Gender: {bird.gender}");
                Console.WriteLine();
            }
        }
    }
}