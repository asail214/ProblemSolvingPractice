/*
    Inventory Payment System – OOP Example in C#

    Problem Statement:
    -------------------
    This application simulates payment transactions in a retail shop:
        - Customers can pay using Cash, Debit, or Visa.
        - A Cashier processes these payments.
        - Each transaction stores customer information, payment amount, and (if applicable) card details.
    The system uses OOP concepts: inheritance, interface, override, and polymorphism.

    Solution Overview:
    -------------------
    - The interface 'IPay' defines a contract for all payment methods (each must have ShowTransaction()).
    - The base class 'Payment' implements IPay, holding common data and methods for payments.
    - Derived classes (Cash, Debit, Visa) inherit from Payment and override ShowTransaction() to display specific info.
    - The 'Cashier' class handles any payment type via the IPay interface (polymorphism).
    - All transactions are stored as IPay, so the list can contain any current or future payment types.

    Flowchart/Class Diagram:
                (interface)
                    IPay
                    ▲
                    │
                ┌────┴─────┐
                │  Payment │   <----- (base class)
                └────┬─────┘
            ┌─────┼──────┐
            Cash   Debit   Visa   <----- (derived classes)
            ▲      ▲      ▲
            │      │      │
            (all inherit from Payment and implement IPay)
           
    Cashier -------> handles (uses) --------> List<IPay> (Cash, Debit, Visa)
*/

using System;
using System.Collections.Generic;

namespace InheritanceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create two cashiers (could be expanded to allow user selection)
            Cashier cashier1 = new Cashier("Ahmed", "C001");
            Cashier cashier2 = new Cashier("Fatma", "C002");

            // Store all transactions in a polymorphic list of IPay
            List<IPay> transactions = new List<IPay>
            {
                new Cash("Ali", 100.5),
                new Debit("Mona", 200, "1234"),
                new Visa("Salim", 350, "4111")
            };

            Console.WriteLine("All Transaction Details:\n");
            foreach (var payment in transactions)
            {
                // Demonstrates polymorphism: cashier can handle any type of IPay
                cashier1.HandleTransaction(payment);
            }
        }
    }

    // Interface for payment methods.
    // Enforces the ShowTransaction() method in all implementing classes.
    public interface IPay
    {
        void ShowTransaction();
    }

    // The Cashier class handles transactions.
    // Demonstrates association (not inheritance) with payment types.
    public class Cashier
    {
        public string Name { get; set; }
        public string CashierID { get; set; }

        public Cashier(string name, string cashierID)
        {
            Name = name;
            CashierID = cashierID;
        }

        // HandleTransaction uses polymorphism: accepts any IPay type.
        public void HandleTransaction(IPay payment)
        {
            Console.WriteLine($"Handled by Cashier: {Name} (ID: {CashierID})");
            payment.ShowTransaction(); // Calls the correct version depending on the payment type.
            Console.WriteLine("----------------------");
        }
    }

    // The base class for all payment types.
    // Implements the IPay interface.
    public class Payment : IPay
    {
        public string CustomerName { get; set; }
        public double Amount { get; set; }
        public Payment(string customerName, double amount)
        {
            CustomerName = customerName;
            Amount = amount;
        }

        // Virtual method to be overridden by child classes for custom info
        public virtual void ShowTransaction()
        {
            Console.WriteLine($"Customer: {CustomerName}\nAmount: ${Amount}");
        }
    }

    // Represents cash payment. Inherits from Payment.
    public class Cash : Payment
    {
        public Cash(string customerName, double amount)
            : base(customerName, amount) { }

        // Override to specify payment method
        public override void ShowTransaction()
        {
            Console.WriteLine("Payment Method: Cash");
            base.ShowTransaction();
        }
    }

    // Represents debit card payment. Inherits from Payment.
    public class Debit : Payment
    {
        public string CardNumber { get; set; }

        public Debit(string customerName, double amount, string cardNumber)
            : base(customerName, amount)
        {
            CardNumber = cardNumber;
        }

        public override void ShowTransaction()
        {
            Console.WriteLine("Payment Method: Debit Card");
            base.ShowTransaction();
            Console.WriteLine($"Card Number: {CardNumber}");
        }
    }

    // Represents Visa payment. Inherits from Payment.
    public class Visa : Payment
    {
        public string VisaNumber { get; set; }

        public Visa(string customerName, double amount, string visaNumber)
            : base(customerName, amount)
        {
            VisaNumber = visaNumber;
        }

        public override void ShowTransaction()
        {
            Console.WriteLine("Payment Method: Visa");
            base.ShowTransaction();
            Console.WriteLine($"Visa Number: {VisaNumber}");
        }
    }
}
