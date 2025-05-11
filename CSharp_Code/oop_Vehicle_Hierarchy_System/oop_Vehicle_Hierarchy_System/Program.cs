// OOP Assignment 3: Vehicle Hierarchy System
using System;

namespace oop_Vehicle_Hierarchy_System
{
    class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Vehicle(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine("\nVehicle Information:");
            Console.WriteLine($"Make: {Make}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Year: {Year}");
        }
    }

    class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }

        public Car(string make, string model, int year, int numberOfDoors)
            : base(make, model, year)
        {
            NumberOfDoors = numberOfDoors;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Vehicle Type: Car");
            Console.WriteLine($"Number of Doors: {NumberOfDoors}");
        }
    }

    class Truck : Vehicle
    {
        public double LoadCapacity { get; set; }

        public Truck(string make, string model, int year, double loadCapacity)
            : base(make, model, year)
        {
            LoadCapacity = loadCapacity;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Vehicle Type: Truck");
            Console.WriteLine($"Load Capacity: {LoadCapacity} tons");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vehicle Hierarchy System");
            Console.WriteLine("-----------------------");

            Car car = new Car("Toyota", "Camry", 2022, 4);
            Truck truck = new Truck("Ford", "F-150", 2021, 2.5);

            car.DisplayInfo();
            truck.DisplayInfo();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
