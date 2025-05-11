// Assignment 7: Library Book Borrowing System
namespace Library_Book_Borrowing_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] books = {
                "C# Programming",
                "Debugging",
                "Web Development",
                "Database",
                "Code Academy"
            };

            bool[] isBorrowed = new bool[books.Length];

            Console.WriteLine("Assignment7: Library Book Borrowing System");
            Console.WriteLine("------------------------------------------");

            string choice;

            do
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. View Books");
                Console.WriteLine("2. Borrow Book");
                Console.WriteLine("3. Return Book");
                Console.WriteLine("4. Check Availability");
                Console.WriteLine("5. Exit");

                Console.Write("Your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": 
                        Console.WriteLine("\nLibrary Catalog:");
                        Console.WriteLine("-----------------");

                        for (int i = 0; i < books.Length; i++)
                        {
                            string status = isBorrowed[i] ? "Borrowed" : "Available";
                            Console.WriteLine($"{i + 1}. {books[i]} - {status}");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nLibrary Catalog:");
                        for (int i = 0; i < books.Length; i++)
                        {
                            string status = isBorrowed[i] ? "Borrowed" : "Available";
                            Console.WriteLine($"{i + 1}. {books[i]} - {status}");
                        }

                        Console.Write("\nEnter book number to borrow: ");
                        int borrowNum = Convert.ToInt32(Console.ReadLine()) - 1; // Adjust for zero-based indexing

                        if (borrowNum >= 0 && borrowNum < books.Length)
                        {
                            if (!isBorrowed[borrowNum])
                            {
                                isBorrowed[borrowNum] = true;
                                Console.WriteLine($"You have successfully borrowed \"{books[borrowNum]}\".");
                            }
                            else
                            {
                                Console.WriteLine("Error: This book is already borrowed.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Invalid book number.");
                        }
                        break;

                    case "3":
                        bool anyBorrowed = false;
                        for (int i = 0; i < isBorrowed.Length; i++)
                        {
                            if (isBorrowed[i])
                            {
                                anyBorrowed = true;
                                break;
                            }
                        }

                        if (anyBorrowed)
                        {
                            Console.WriteLine("\nBorrowed Books:");
                            for (int i = 0; i < books.Length; i++)
                            {
                                if (isBorrowed[i])
                                {
                                    Console.WriteLine($"{i + 1}. {books[i]}");
                                }
                            }

                            Console.Write("\nEnter book number to return: ");
                            int returnNum = Convert.ToInt32(Console.ReadLine()) - 1; // Adjust for zero-based indexing

                            if (returnNum >= 0 && returnNum < books.Length)
                            {
                                if (isBorrowed[returnNum])
                                {
                                    isBorrowed[returnNum] = false;
                                    Console.WriteLine($"You have successfully returned \"{books[returnNum]}\".");
                                }
                                else
                                {
                                    Console.WriteLine("Error: This book is not currently borrowed.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error: Invalid book number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No books are currently borrowed.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter book name to check: ");
                        string bookName = Console.ReadLine();

                        bool found = false;
                        for (int i = 0; i < books.Length; i++)
                        {
                            if (books[i].ToLower() == bookName.ToLower())
                            {
                                string status = isBorrowed[i] ? "borrowed" : "available";
                                Console.WriteLine($"\"{books[i]}\" is currently {status}.");
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Book not found in the library.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("EXIT!");
                        break;

                    default:
                        Console.WriteLine("Error: Invalid option\nTry again!");
                        break;
                }
            } while (choice != "5");
        }
    }
}