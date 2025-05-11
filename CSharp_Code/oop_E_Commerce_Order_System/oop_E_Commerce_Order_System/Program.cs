// OOP Assignment 4: E-Commerce Order System
using System;
using System.Collections.Generic;

namespace oop_E_Commerce_Order_System
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product()
        {
            Name = "Unnamed Product";
            Price = 0.0;
            Quantity = 0;
        }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public double CalculateTotal()
        {
            return Price * Quantity;
        }

        // Overloaded method with parameters
        public double CalculateTotal(double price, int quantity)
        {
            return price * quantity;
        }
    }

    class Order
    {
        public List<Product> Products { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string OrderId { get; private set; }

        public Order(string orderId)
        {
            Products = new List<Product>();
            OrderDate = DateTime.Now;
            OrderId = orderId;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            Console.WriteLine($"Added {product.Name} to the order.");
        }

        public double CalculateTotalCost()
        {
            double totalCost = 0;
            foreach (Product product in Products)
            {
                totalCost += product.CalculateTotal();
            }
            return totalCost;
        }

        public void DisplayOrderDetails()
        {
            Console.WriteLine("\nOrder Details:");
            Console.WriteLine($"Order ID: {OrderId}");
            Console.WriteLine($"Order Date: {OrderDate}");
            Console.WriteLine("Products:");

            if (Products.Count == 0)
            {
                Console.WriteLine("No products in this order.");
            }
            else
            {
                foreach (Product product in Products)
                {
                    Console.WriteLine($"- {product.Name} (${product.Price} x {product.Quantity}) = ${product.CalculateTotal()}");
                }

                Console.WriteLine($"Total Order Cost: ${CalculateTotalCost()}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("E-Commerce Order System");
            Console.WriteLine("----------------------");

            Product product1 = new Product("Smartphone", 699.99, 1);
            Product product2 = new Product("Headphones", 89.99, 2);
            Product product3 = new Product();
            product3.Name = "Wireless Charger";
            product3.Price = 29.99;
            product3.Quantity = 3;

            Console.WriteLine($"Total for {product1.Name} using class fields: ${product1.CalculateTotal()}");
            Console.WriteLine($"Total for {product1.Name} using parameters: ${product1.CalculateTotal(799.99, 2)}");

            Order order = new Order("ORD-2023-001");
            order.AddProduct(product1);
            order.AddProduct(product2);
            order.AddProduct(product3);

            order.DisplayOrderDetails();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
