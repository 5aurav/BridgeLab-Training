using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Animal
    {
        public String Name { get; set; }
        public int Age { get; set; }
        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound.");
        }

    }
    class Dog: Animal
    {
        public Dog(string name, int age) : base(name, age)
        {
        }
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks");
        }
    }

    class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age)
        {
        }
        public override void MakeSound()
        {
            Console.WriteLine("Cat meows");
        }
    }

    class Bird : Animal
    {
        public Bird(string name, int age) : base(name, age)
        {
        }
        public override void MakeSound()
        {
            Console.WriteLine("Bird chirps");
        }
    }

    internal class AnimalDisplay
    {
        public static void ShowAnimals()
        {
            Animal dog = new Dog("Tommy", 3);
            Animal cat = new Cat("Kitty", 2);
            Animal bird = new Bird("Tweety", 1);

            dog.MakeSound();
            cat.MakeSound();
            bird.MakeSound();
        }
    }


}
