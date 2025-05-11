// Assignment 5: Parking Lot System
namespace Parking_Lot_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] slots = new string[10];

            for (int i = 0; i < slots.Length; i++)
            {
                slots[i] = "";
            }

            Console.WriteLine("Assignment5: Parking Lot System");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Total Parking Slots: {slots.Length}");

            string choice;

            do
            {
                // Display menu
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Park a Car");
                Console.WriteLine("2. Remove a Car");
                Console.WriteLine("3. View All Slots");
                Console.WriteLine("4. Search for a Car");
                Console.WriteLine("5. Exit");

                Console.Write("Your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Park a Car
                        bool isFull = true;
                        for (int i = 0; i < slots.Length; i++)
                        {
                            if (slots[i] == "")
                            {
                                isFull = false;
                                break;
                            }
                        }

                        if (isFull)
                        {
                            Console.WriteLine("Error: Parking is full!");
                            break;
                        }

                        Console.Write("Enter car license number: ");
                        string licensePlate = Console.ReadLine();

                        bool isDuplicate = false;
                        for (int i = 0; i < slots.Length; i++)
                        {
                            if (slots[i] == licensePlate)
                            {
                                isDuplicate = true;
                                break;
                            }
                        }

                        if (isDuplicate)
                        {
                            Console.WriteLine("Error: Car is already parked!");
                            break;
                        }

                        for (int i = 0; i < slots.Length; i++)
                        {
                            if (slots[i] == "")
                            {
                                slots[i] = licensePlate;
                                Console.WriteLine($"Car with license {licensePlate} parked at slot {i + 1}");
                                break;
                            }
                        }
                        break;

                    case "2":
                        Console.Write("Enter car license number to remove: ");
                        string removePlate = Console.ReadLine();

                        bool found = false;
                        for (int i = 0; i < slots.Length; i++)
                        {
                            if (slots[i] == removePlate)
                            {
                                slots[i] = "";
                                Console.WriteLine($"Car with license {removePlate} removed from slot {i + 1}");
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Error: Car not found!");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nView All Slots:");
                        Console.WriteLine("------------------");

                        int occupied = 0;
                        for (int i = 0; i < slots.Length; i++)
                        {
                            string status = (slots[i] == "") ? "Empty" : slots[i];
                            Console.WriteLine($"Slot {i + 1}: {status}");

                            if (slots[i] != "")
                            {
                                occupied++;
                            }
                        }

                        Console.WriteLine($"\nTacken Slots: {occupied}");
                        Console.WriteLine($"Empty Slots: {slots.Length - occupied}");
                        break;

                    case "4": // Search for a Car
                        Console.Write("Enter car license number to search: ");
                        string searchPlate = Console.ReadLine();

                        bool carFound = false;
                        for (int i = 0; i < slots.Length; i++)
                        {
                            if (slots[i] == searchPlate)
                            {
                                Console.WriteLine($"Car with license {searchPlate} found at slot {i + 1}");
                                carFound = true;
                                break;
                            }
                        }

                        if (!carFound)
                        {
                            Console.WriteLine("Car not found in parking lot.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("EXIT!");
                        break;

                    default:
                        Console.WriteLine("Error: Invalid option!");
                        break;
                }
            } while (choice != "5");
        }
    }
}