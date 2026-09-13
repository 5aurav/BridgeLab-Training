using BirdSanctuary.Interfaces;

namespace BirdSanctuary.Models
{
    public class Duck : Bird, IFlyable, ISwimmable
    {
        public Duck(string id, string name,Gender Gender) : base(id, name, Gender) { }

        public override void Eat() => Console.WriteLine($"{Name} the Duck is eating pond weed.");
        public void Fly() => Console.WriteLine($"{Name} is flying over the lake.");
        public void Swim() => Console.WriteLine($"{Name} is paddling in the water.");
    }
}
