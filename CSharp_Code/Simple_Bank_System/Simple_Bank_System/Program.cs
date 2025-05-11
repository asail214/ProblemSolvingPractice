// Assignment 1: Simple Bank System 
namespace Simple_Bank_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declare the user info arrays
            string[] usernames = { "user1", "user2", "user3" };
            string[] passwords = { "123", "456", "789" };
            double[] balances = { 100.00, 200.00, 300.00 };

            bool done = false;
            int index = -1; // Using -1 instead of 0 prevents logical errors when transferring to the first user (index 0)
            string username;

            Console.WriteLine("Login to your Bank System");
            Console.WriteLine("______________________");

            do
            {
                Console.Write("User name: ");
                username = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                for (int i = 0; i < usernames.Length; i++)
                {
                    if (username == usernames[i] && password == passwords[i])
                    {
                        index = i;
                        done = true;
                        break;
                    }
                }

                if (!done)
                {
                    Console.WriteLine("Error: Invalid username or password!");
                }
            } while (!done);

            Console.WriteLine($"Welcome {username}!");

            string choice;

            do
            {
                // Display menu
                Console.WriteLine("\nSelect a service:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Exit");

                Console.Write("Your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Balance = {balances[index]} Omani rials");
                        break;

                    case "2":
                        Console.Write("Enter amount to deposit: ");
                        double amount1 = Convert.ToDouble(Console.ReadLine());

                        if (amount1 > 0)
                        {
                            balances[index] += amount1;
                            Console.WriteLine($"Deposit successful.\n New balance: {balances[index]}");
                        }
                        else
                        {
                            Console.WriteLine("Error: Invalid amount.\n Try again!");
                        }
                        break;

                    case "3":
                        Console.Write("Enter amount to withdraw: ");
                        double amount2 = Convert.ToDouble(Console.ReadLine());

                        if (amount2 > 0 && amount2 <= balances[index])
                        {
                            balances[index] -= amount2;
                            Console.WriteLine($"Withdrawal successful. \n New balance: {balances[index]} Omani rials");
                        }
                        else
                        {
                            Console.WriteLine("Error: Invalid amount.\n Try again!");
                        }
                        break;

                    case "4":
                        Console.Write("Enter username to transfer to: ");
                        string toUser = Console.ReadLine();

                        int index2 = -1;
                        for (int i = 0; i < usernames.Length; i++)
                        {
                            if (toUser == usernames[i])
                            {
                                index2 = i;
                                break;
                            }
                        }

                        if (index2 != -1)
                        {
                            Console.Write("Enter amount to transfer: ");
                            double transferAmount = Convert.ToDouble(Console.ReadLine());

                            if (transferAmount > 0 && transferAmount <= balances[index])
                            {
                                balances[index] -= transferAmount;
                                balances[index2] += transferAmount;
                                Console.WriteLine($"Transfer successful.\n Your new balance: {balances[index]} Omani rials");
                            }
                            else
                            {
                                Console.WriteLine("Error: Invalid amount.\n Try again!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Invalid user name.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Logged out successfuly!");
                        break;

                    default:
                        Console.WriteLine("Error: Selection out of range. Try again!");
                        break;
                }
            } while (choice != "5");
        }
    }
}