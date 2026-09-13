using BirdSanctuary.Interfaces;

namespace BirdSanctuary.Models
{
    public class Eagle : Bird, IFlyable
    {
        public Eagle(string id, string name, Gender Gender) : base(id, name, Gender) { }

        public override void Eat() => Console.WriteLine($"{Name} the Eagle is hunting.");
        public void Fly() => Console.WriteLine($"{Name} is soaring high in the clouds.");
    }
}
