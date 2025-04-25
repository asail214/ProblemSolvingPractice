/*
    Simple Bank Account Simulation – OOP in C#
    ===========================================

    Problem Statement:
    -------------------
    Create a simple console-based banking system where a user can:
        - Check their balance
        - Withdraw money
        - Transfer money to another account
    Each account has an account holder and a balance. All transactions must check for sufficient funds.

    Solution Overview:
    -------------------
    - The 'Bank' class models a bank account with methods to check balance, withdraw, and transfer.
    - The main program loop allows a user to select an operation repeatedly until they choose to exit.
    - All user inputs are handled with basic validation to ensure smooth operation.

    Structure:
    ----------
    Bank class: Represents a bank account with owner name and balance.
    Main loop: Handles user input for withdrawal, transfer, and balance checking.
*/

using System;

namespace PracticeC_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create first user account with a default starting balance
            Console.Write("Enter your name: ");
            string name1 = Console.ReadLine();
            Bank user1 = new Bank(name1, 100);

            // Welcome message and show initial balance
            Console.WriteLine($"\nWelcome, {user1.AccountHolder}!");
            user1.CheckBalance();

            bool continueService = true;

            while (continueService)
            {
                Console.WriteLine("\nSelect an operation:");
                Console.WriteLine("1 - Withdraw");
                Console.WriteLine("2 - Transfer");
                Console.WriteLine("3 - View Balance");

                Console.Write("Enter your choice (1-3): ");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        // Withdraw money
                        Console.Write("Enter amount to withdraw: ");
                        if (double.TryParse(Console.ReadLine(), out double withdrawAmount))
                        {
                            user1.Withdraw(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "2":
                        // Transfer money to another user
                        Console.Write("Enter recipient's name: ");
                        string name2 = Console.ReadLine();
                        Bank user2 = new Bank(name2, 50); // New user starts with 50 OMR

                        Console.Write("Enter amount to transfer: ");
                        if (double.TryParse(Console.ReadLine(), out double transferAmount))
                        {
                            user1.Transfer(user2, transferAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "3":
                        // View balance
                        Console.WriteLine("Account Balance:");
                        user1.CheckBalance();
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Please choose 1, 2, or 3.");
                        break;
                }

                // Ask if user wants to continue
                Console.Write("\nDo you want to continue (yes/no)? ");
                string check = Console.ReadLine();
                if (check?.ToLower() == "no")
                {
                    continueService = false;
                }
            }

            Console.WriteLine("\nThank you for using the Bank system!");
        }
    }

    // Represents a bank account with basic operations.
    public class Bank
    {
        public string AccountHolder { get; set; }
        public double Balance { get; set; }

        // Initializes a new bank account with the owner's name and an initial balance.
        public Bank(string name, double initialBalance)
        {
            AccountHolder = name;
            Balance = initialBalance;
        }

        // Prints the account balance.
        public void CheckBalance()
        {
            Console.WriteLine($"{AccountHolder}'s balance: {Balance} OMR");
        }

        // Withdraws a specified amount if sufficient funds exist.
        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdraw amount must be positive.");
                return;
            }

            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Successful withdrawal. New balance: {Balance} OMR");
            }
            else
            {
                Console.WriteLine("Not enough balance.");
            }
        }

        /// Transfers a specified amount to another bank account, if sufficient funds exist.
        public void Transfer(Bank receiver, double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Transfer amount must be positive.");
                return;
            }

            if (amount <= Balance)
            {
                Balance -= amount;
                receiver.Balance += amount;
                Console.WriteLine($"Transferred {amount} OMR to {receiver.AccountHolder}.");
                Console.WriteLine($"Your new balance: {Balance} OMR");
            }
            else
            {
                Console.WriteLine("Insufficient balance for transfer.");
            }
        }
    }
}
