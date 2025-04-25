/*
 * Coffee Shop Order System (Console App)
 * 
 * Problem Definition:
 * -------------------
 * Write a simple C# console application for a coffee shop where:
 *   - The menu has three types of coffee.
 *   - The user selects a coffee, chooses a size, and customizes (sugar, milk).
 *   - The program prints an order summary and the total price.
 *
 * Solution Overview:
 * -------------------
 * - Uses basic variables for menu data and order info.
 * - Handles user input with simple if/else statements.
 * - Prints a clear summary at the end.
 * - The code is organized, commented, and kept simple for learning.
 */

using System;

namespace Coffee_Shop_Order_System
{
    class Program
    {
        static void Main(string[] args)
        {
            // Welcome message
            Console.WriteLine("Welcome to the Coffee Shop!");

            // Display menu
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Americano - $2.50");
            Console.WriteLine("2. Latte     - $3.00");
            Console.WriteLine("3. Cappuccino- $3.50");

            // Get coffee selection
            Console.Write("\nSelect a coffee (1-3): ");
            int coffeeChoice = Convert.ToInt32(Console.ReadLine());

            // Store coffee name and price
            string coffeeName = "";
            double coffeePrice = 0;

            // Simple selection using if/else
            if (coffeeChoice == 1)
            {
                coffeeName = "Americano";
                coffeePrice = 2.50;
            }
            else if (coffeeChoice == 2)
            {
                coffeeName = "Latte";
                coffeePrice = 3.00;
            }
            else if (coffeeChoice == 3)
            {
                coffeeName = "Cappuccino";
                coffeePrice = 3.50;
            }
            else
            {
                Console.WriteLine("Invalid selection. Please restart the order.");
                return;
            }

            // Display size options
            Console.WriteLine("\nCustomizations (choose size):");
            Console.WriteLine("1. Small");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Large");

            // Get size selection
            Console.Write("Select a size (1-3): ");
            int sizeChoice = Convert.ToInt32(Console.ReadLine());

            string size = "";
            if (sizeChoice == 1)
                size = "Small";
            else if (sizeChoice == 2)
                size = "Medium";
            else if (sizeChoice == 3)
                size = "Large";
            else
            {
                Console.WriteLine("Invalid size selection. Please restart the order.");
                return;
            }

            // Ask for sugar
            Console.Write("Do you want sugar? (yes/no): ");
            string sugarChoice = Console.ReadLine().ToLower();
            bool sugar = sugarChoice == "yes";

            // Ask for milk
            Console.Write("Do you want milk? (yes/no): ");
            string milkChoice = Console.ReadLine().ToLower();
            bool milk = milkChoice == "yes";

            // Print order summary
            Console.WriteLine("\n--- Your Order Summary ---");
            Console.WriteLine($"{coffeeName} ({size})");

            if (sugar && milk)
                Console.WriteLine("with sugar and milk");
            else if (sugar)
                Console.WriteLine("with sugar");
            else if (milk)
                Console.WriteLine("with milk");
            else
                Console.WriteLine("no extra customizations");

            // Show total cost
            Console.WriteLine($"Total Cost: ${coffeePrice:F2}");
            Console.WriteLine("Thank you for ordering!");

            // Keep the console open until user presses Enter
            Console.ReadLine();
        }
    }
}

