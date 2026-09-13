using BirdSanctuary.Interfaces;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace BirdSanctuary.Models
{
    public class Ostrich : Bird, IRunnable
    {
        public Ostrich(string id, string name,Gender Gender) : base(id, name,Gender) { }

        public override void Eat() => Console.WriteLine($"{Name} the Ostrich is pecking at seeds.");
        public void Run() => Console.WriteLine($"{Name} is sprinting across the ground!");
    }
}
