// OOP Assignment 5: Animal Sound Simulation
using System;
using System.Collections.Generic;

namespace AnimalSoundSimulation
{
    abstract class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }

        public abstract void MakeSound();
    }

    class Dog : Animal
    {
        public Dog(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Woof!");
        }
    }

    class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Meow!");
        }
    }

    class Cow : Animal
    {
        public Cow(string name) : base(name)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Moo!");
        }
    }

    class Program
    {
        static void MakeAnimalsSounds(List<Animal> animals)
        {
            Console.WriteLine("\nAnimals making sounds:");
            foreach (Animal animal in animals)
            {
                animal.MakeSound();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Animal Sound Simulation");
            Console.WriteLine("----------------------");

            Dog dog = new Dog("Rex");
            Cat cat = new Cat("Whiskers");
            Cow cow = new Cow("Daisy");

            List<Animal> animals = new List<Animal>
            {
                dog,
                cat,
                cow
            };

            MakeAnimalsSounds(animals);

            Console.WriteLine("\nPress any key to exit:");
            Console.ReadKey();
        }
    }
}
