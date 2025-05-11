// OOP Assignment 6: Bank Account Management System
using System;
using System.Collections.Generic;

namespace BankAccountManagementSystem
{
    class BankAccount
    {
        private static int totalAccounts = 0;

        private string accountNumber;
        private double balance;
        private string owner;

        public string AccountNumber
        {
            get { return accountNumber; }
            private set { accountNumber = value; }
        }

        public double Balance
        {
            get { return balance; }
            private set { balance = value; }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public BankAccount(string accountNumber, string owner, double initialBalance = 0)
        {
            AccountNumber = accountNumber;
            Owner = owner;

            if (initialBalance >= 0)
            {
                Balance = initialBalance;
            }
            else
            {
                Balance = 0;
                Console.WriteLine("Warning: Initial balance cannot be negative. Setting balance to 0.");
            }

            totalAccounts++;
        }

        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"${amount} deposited successfully. New balance: ${Balance}");
                return true;
            }
            else
            {
                Console.WriteLine("Error: Deposit amount must be positive.");
                return false;
            }
        }

        public bool Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Error: Withdrawal amount must be positive.");
                return false;
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Error: Insufficient funds.");
                return false;
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"${amount} withdrawn successfully. New balance: ${Balance}");
                return true;
            }
        }

        public static void ShowTotalAccounts()
        {
            Console.WriteLine($"Total number of accounts created: {totalAccounts}");
        }

        public void DisplayAccountInfo()
        {
            Console.WriteLine("\nAccount Information:");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Owner: {Owner}");
            Console.WriteLine($"Balance: ${Balance}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bank Account Management System");
            Console.WriteLine("-----------------------------");

            BankAccount account1 = new BankAccount("ACC001", "Ahmed", 1000);
            BankAccount account2 = new BankAccount("ACC002", "Sara", 2500);
            BankAccount account3 = new BankAccount("ACC003", "Mohammed", -100); // Testing validation

            account1.DisplayAccountInfo();
            account2.DisplayAccountInfo();
            account3.DisplayAccountInfo();

            Console.WriteLine("\nTesting deposit and withdraw operations:");
            account1.Deposit(500);
            account1.Withdraw(200);
            account1.Withdraw(2000); 

            account2.Deposit(-100); 
            account2.Withdraw(500);

            Console.WriteLine();
            BankAccount.ShowTotalAccounts();

            Console.WriteLine("\nPress any key to exit: ");
            Console.ReadKey();
        }
    }
}
