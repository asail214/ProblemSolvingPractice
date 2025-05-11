/*
    Create a base class Animal with method MakeSound(). 
    Create two derived classes: Dog and Cat,
    each overriding MakeSound() with a different message.
    In the Main method, create objects and demonstrate polymorphism.
 */
namespace C_Sharp_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# Exam Part2:\n______________\n");

            Console.WriteLine("The Animal.MakeSound() output is:");
            Animal animal = new Animal();
            animal.MakeSound();

            Console.WriteLine("\n\nThe Dog.MakeSound() output is:");
            Dog dog = new Dog();
            dog.MakeSound();

            Console.WriteLine("\nThe Cat.MakeSound() output is:");
            Cat cat = new Cat();
            cat.MakeSound();
        }
    }

    class Animal
    {
        public virtual void MakeSound()
        { 
            Console.Write("The animal is: ");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            base.MakeSound();
            Console.WriteLine("Dog");
        }
    }

    class Cat : Animal
    {
        public override void MakeSound()
        {
            base.MakeSound();
            Console.WriteLine("Cat");
        }
    }
}
