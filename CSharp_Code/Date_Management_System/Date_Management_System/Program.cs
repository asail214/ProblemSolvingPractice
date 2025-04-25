/*
    Date Validation and Management System – OOP in C#
    ================================================
    
    Problem Definition:
    -------------------
    This program implements a simple Inventory Management System for Code Academy.
    The user (admin) can manage products, record sales, and generate reports through a console interface.
    Features include user authentication, product management (add, update, display), sales tracking,
    product and sales reporting, and basic error handling.
    
    Solution Overview:
    -------------------
    - Uses OOP principles for organization (classes: Authentication, Product, Sale)
    - Stores product and sales data in lists
    - Implements input validation and error messages for robust user experience
    - Supports continuous operations until the user chooses to exit
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace HW3_Inventory_Management_System_wd0008
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Inventory Management System!");

            // Prompt for admin login
            Console.Write("Please enter your username: ");
            string admin = Console.ReadLine();

            Console.Write("Please enter your password: ");
            string adminpass = Console.ReadLine();

            // Authenticate user and enter main menu if successful
            Authentication user = new Authentication(admin, adminpass);
        }
    }

    /// Handles user authentication and main menu operations if login is successful.
    public class Authentication
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Authentication(string username, string password)
        {
            Username = username;
            Password = password;
            Check();
        }

        /// Verifies credentials and launches the main menu on success.
        public void Check()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                Console.WriteLine("Please enter your username and password.");
                return;
            }
            if (Username != "admin" || Password != "adminpass")
            {
                Console.WriteLine("Error: Wrong username or password!");
                return;
            }

            Console.WriteLine($"\nAuthentication successful! Welcome, {Username}!\n");

            // Initialize product and sales lists
            List<Product> products = new List<Product>();
            List<Sale> sales = new List<Sale>();

            Console.WriteLine(
                "Options:\n" +
                "1. Add a new product\n" +
                "2. Update product quantity\n" +
                "3. Display product list\n" +
                "4. Record sale\n" +
                "5. Generate product report\n" +
                "6. Generate sales report\n" +
                "7. Exit\n"
            );

            bool quit = false;
            do
            {
                Console.Write("\nSelect an operation (1-7): ");
                bool validInput = int.TryParse(Console.ReadLine(), out int option);

                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please enter a number (1-7).");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        // Add a new product
                        Console.WriteLine("Option 1: Add a new product");
                        Console.Write("Enter product name: ");
                        string productName = Console.ReadLine();

                        // Check if product already exists
                        if (products.Any(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase)))
                        {
                            Console.WriteLine("Product with this name already exists!");
                            break;
                        }

                        Console.Write("Enter product price: ");
                        if (!double.TryParse(Console.ReadLine(), out double productPrice) || productPrice < 0)
                        {
                            Console.WriteLine("Invalid price input.");
                            break;
                        }

                        Console.Write("Enter product quantity: ");
                        if (!int.TryParse(Console.ReadLine(), out int productQuantity) || productQuantity < 0)
                        {
                            Console.WriteLine("Invalid quantity input.");
                            break;
                        }

                        products.Add(new Product(productName, productPrice, productQuantity));
                        Console.WriteLine("Product added successfully!\n");
                        break;

                    case 2:
                        // Update product quantity
                        Console.WriteLine("Option 2: Update product quantity");
                        Console.Write("Enter the product name to update: ");
                        string updatedProductName = Console.ReadLine();

                        Product productToUpdate = products.FirstOrDefault(
                            p => p.Name.Equals(updatedProductName, StringComparison.OrdinalIgnoreCase));

                        if (productToUpdate == null)
                        {
                            Console.WriteLine($"Error: There is no product named '{updatedProductName}' in the system!");
                            break;
                        }

                        Console.Write("Enter the new quantity: ");
                        if (!int.TryParse(Console.ReadLine(), out int newProductQuantity) || newProductQuantity < 0)
                        {
                            Console.WriteLine("Invalid quantity input.");
                            break;
                        }

                        productToUpdate.Quantity = newProductQuantity;
                        Console.WriteLine("Quantity updated successfully.");
                        break;

                    case 3:
                        // Display product list
                        Console.WriteLine("Option 3: Display product list");
                        if (!products.Any())
                        {
                            Console.WriteLine("No products in the inventory.");
                        }
                        else
                        {
                            foreach (Product product in products)
                            {
                                product.Display();
                            }
                        }
                        break;

                    case 4:
                        // Record a sale
                        Console.WriteLine("Option 4: Record sale");
                        if (!products.Any())
                        {
                            Console.WriteLine("No products available to sell.");
                            break;
                        }

                        Console.Write("Enter product name: ");
                        string saleProductName = Console.ReadLine();

                        Product productToSell = products.FirstOrDefault(
                            p => p.Name.Equals(saleProductName, StringComparison.OrdinalIgnoreCase));

                        if (productToSell == null)
                        {
                            Console.WriteLine("Product not found!");
                            break;
                        }

                        Console.Write("Enter quantity sold: ");
                        if (!int.TryParse(Console.ReadLine(), out int quantitySold) || quantitySold <= 0)
                        {
                            Console.WriteLine("Invalid quantity.");
                            break;
                        }

                        if (quantitySold > productToSell.Quantity)
                        {
                            Console.WriteLine($"Error: Not enough stock. Only {productToSell.Quantity} available.");
                            break;
                        }

                        // Update product quantity and record sale
                        productToSell.Quantity -= quantitySold;
                        sales.Add(new Sale(productToSell.Name, quantitySold, productToSell.Price));
                        Console.WriteLine("Sale recorded successfully!");
                        break;

                    case 5:
                        // Product report
                        Console.WriteLine("Option 5: Generate product report");
                        if (!products.Any())
                        {
                            Console.WriteLine("No products available.");
                        }
                        else
                        {
                            Console.WriteLine("\nProduct Report:\n-----------------");
                            foreach (Product product in products)
                            {
                                product.Display();
                            }
                        }
                        break;

                    case 6:
                        // Sales report
                        Console.WriteLine("Option 6: Generate sales report");
                        if (!sales.Any())
                        {
                            Console.WriteLine("No sales recorded yet.");
                        }
                        else
                        {
                            int totalSales = sales.Sum(s => s.QuantitySold);
                            double totalRevenue = sales.Sum(s => s.TotalPrice);

                            Console.WriteLine("\nSales Report:\n-----------------");
                            foreach (Sale sale in sales)
                            {
                                sale.Display();
                            }
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine($"Total Sales: {totalSales}");
                            Console.WriteLine($"Total Revenue: ${totalRevenue}");
                        }
                        break;

                    case 7:
                        // Exit
                        Console.WriteLine($"Thank you for using the Inventory Management System, {Username}!");
                        quit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid operation (1-7).");
                        break;
                }

            } while (!quit);
        }
    }


    // Represents a product in the inventory.
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        // Displays the product's information.
        public void Display()
        {
            Console.WriteLine($"Product: Name: {Name}, Price: {Price}, Quantity: {Quantity}");
        }
    }

    // Represents a sale transaction.
    public class Sale
    {
        public string ProductName { get; set; }
        public int QuantitySold { get; set; }
        public double PricePerUnit { get; set; }
        public double TotalPrice { get; set; }

        public Sale(string productName, int quantitySold, double pricePerUnit)
        {
            ProductName = productName;
            QuantitySold = quantitySold;
            PricePerUnit = pricePerUnit;
            TotalPrice = quantitySold * pricePerUnit;
        }

        // Displays the sale's details.
        public void Display()
        {
            Console.WriteLine($"Product: Name: {ProductName}, Quantity: {QuantitySold}, Price: {PricePerUnit}, Total: {TotalPrice}");
        }
    }
}
