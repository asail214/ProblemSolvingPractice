/*
 * Topic: Vehicles System (OOP Example)
 * 
 * Problem Definition:
 * -------------------
 * Write a simple C# console program using OOP to:
 *   - Model different vehicle types (Car, Van, etc.) using inheritance.
 *   - Store basic info for each vehicle: Name, Model, Color.
 *   - Display details for each vehicle.
 *   - Check for valid input before adding vehicles to the system.
 * 
 * Solution Overview:
 * -------------------
 * - Use a base class 'Vehicle' for common fields and methods.
 * - Use child classes for specific vehicle types (Car, Van, ...).
 * - Use a List<Vehicle> to store and display all valid vehicles.
 * - All code is kept simple, with lots of comments for learning.
 */

using System;
using System.Collections.Generic;

namespace Vehicles_System
{
    class Program
    {
        static void Main(string[] args)
        {
            // List to store all vehicles
            List<Vehicle> vehicleList = new List<Vehicle>();

            // Create vehicle objects
            Car car1 = new Car("Toyota", "Corolla", "Red", "Petrol");
            Car car2 = new Car("Honda", "Civic", "Blue", "Hybrid");
            Van van1 = new Van("Ford", "Transit", "White", 12);

            // Add only valid vehicles
            if (car1.IsValid()) vehicleList.Add(car1);
            if (car2.IsValid()) vehicleList.Add(car2);
            if (van1.IsValid()) vehicleList.Add(van1);

            // Print details of all vehicles
            Console.WriteLine("All Vehicle Details:\n");
            PrintAllVehicles(vehicleList);
        }

        // Prints details for each vehicle in the list.
        static void PrintAllVehicles(List<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                vehicle.ShowDetails();
                Console.WriteLine("------------------");
            }
        }
    }

    // Base class for all vehicles.
    class Vehicle
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public Vehicle(string name, string model, string color)
        {
            Name = name;
            Model = model;
            Color = color;
        }

        // Checks if the vehicle has all required information.
        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Model) || string.IsNullOrWhiteSpace(Color))
            {
                Console.WriteLine("Error: Invalid vehicle data! All fields must be filled.");
                return false;
            }
            return true;
        }

        // Shows basic vehicle details.
        public virtual void ShowDetails()
        {
            Console.WriteLine($"Name: {Name}\nModel: {Model}\nColor: {Color}");
        }
    }

    // Represents a car (inherits from Vehicle).
    class Car : Vehicle
    {
        public string EngineType { get; set; }

        public Car(string name, string model, string color, string engineType = "Unknown")
            : base(name, model, color)
        {
            EngineType = engineType;
        }

        // Simulates driving the car.
        public void Drive()
        {
            Console.WriteLine($"{Name} is now driving...");
        }

        // Shows details specific to cars.
        public override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine($"Engine Type: {EngineType}");
        }
    }

    // Represents a van (inherits from Vehicle).
    class Van : Vehicle
    {
        public int Capacity { get; set; } // Number of passengers or cargo size

        public Van(string name, string model, string color, int capacity)
            : base(name, model, color)
        {
            Capacity = capacity;
        }

        // Shows details specific to vans.
        public override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine($"Capacity: {Capacity} seats");
        }
    }
}

