// Assignment 3: Inventory Management System
namespace Inventory_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] products = {"Apple","Orange","Milk"};
            int[] quantities = {3,4,5};

            Console.WriteLine("Assignment3: Inventory Management System");
            Console.WriteLine("----------------------------------------");

            string choice;

            do
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. View All Products");
                Console.WriteLine("2. Add Stock");
                Console.WriteLine("3. Sell Product");
                Console.WriteLine("4. Check Product Quantity");
                Console.WriteLine("5. Exit");

                Console.Write("Your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nAvailable Products:");
                        Console.WriteLine("--------------------");
                        for (int i = 0; i < products.Length; i++)
                        {
                            Console.WriteLine($"{products[i]}: {quantities[i]}");
                        }
                        break;

                    case "2":
                        Console.Write("Enter product name: ");
                        string addProduct = Console.ReadLine();

                        int productIndex = -1;
                        
                        for (int i = 0; i < products.Length; i++)
                        {
                            if (products[i].ToLower() == addProduct.ToLower())
                            {
                                productIndex = i;
                                break;
                            }
                        }

                        if (productIndex != -1)
                        {
                            Console.Write("Enter quantity to add: ");
                            int addQuantity = Convert.ToInt32(Console.ReadLine());

                            if (addQuantity > 0)
                            {
                                quantities[productIndex] += addQuantity;
                                Console.WriteLine($"Added {addQuantity} of {products[productIndex]}");
                                Console.WriteLine($"New quantity: {quantities[productIndex]}");
                            }
                            else
                            {
                                Console.WriteLine("Error: Enter valid quantity!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Product not found!");
                        }
                        break;

                    case "3": 
                        Console.Write("Enter product name: ");
                        string sellProduct = Console.ReadLine();

                        int sellIndex = -1;
                        
                        for (int i = 0; i < products.Length; i++)
                        {
                            if (products[i].ToLower() == sellProduct.ToLower())
                            {
                                sellIndex = i;
                                break;
                            }
                        }

                        if (sellIndex != -1)
                        {
                            Console.Write("Enter quantity to sell: ");
                            int sellQuantity = Convert.ToInt32(Console.ReadLine());

                            if (sellQuantity > 0 && sellQuantity <= quantities[sellIndex])
                            {
                                quantities[sellIndex] -= sellQuantity;
                                Console.WriteLine($"Sold {sellQuantity} of {products[sellIndex]}");
                                Console.WriteLine($"Remaining quantity: {quantities[sellIndex]}");
                            }
                            else if (sellQuantity <= 0)
                            {
                                Console.WriteLine("Error: Invalid Quantity!");
                            }
                            else
                            {
                                Console.WriteLine($"Error: Not enough stock!\nOnly {quantities[sellIndex]} available.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Product not found!");
                        }
                        break;

                    case "4": 
                        Console.Write("Enter product name: ");
                        string checkProduct = Console.ReadLine();

                        int checkIndex = -1;
                        
                        for (int i = 0; i < products.Length; i++)
                        {
                            if (products[i].ToLower() == checkProduct.ToLower())
                            {
                                checkIndex = i;
                                break;
                            }
                        }

                        if (checkIndex != -1)
                        {
                            Console.WriteLine($"Current stock of {products[checkIndex]} is {quantities[checkIndex]}");
                        }
                        else
                        {
                            Console.WriteLine("Error: Product not found!");
                        }
                        break;

                    case "5": 
                        Console.WriteLine("Logged Out sucssfuly!");
                        break;

                    default:
                        Console.WriteLine("Error: Invalid option. Try again!");
                        break;
                }
            } while (choice != "5");
        }
    }
}