// Assignment 8: Movie Theatre Seat Booking System
namespace Movie_Theatre_Booking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] seats = new char[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++) 
                {
                    seats[i, j] = 'A';
                }
            }

            Console.WriteLine("Assignment8: Movie Theatre Seat Booking System");
            Console.WriteLine("----------------------------------------------");

            string choice;

            do
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. View Seats");
                Console.WriteLine("2. Book Seat");
                Console.WriteLine("3. Cancel Booking");
                Console.WriteLine("4. Show Available Seat Count");
                Console.WriteLine("5. Exit");

                Console.Write("Your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": 
                        Console.WriteLine("\nSeating Arrangement:");
                        Console.WriteLine("---------------------");

                        Console.Write("   ");
                        for (int j = 0; j < 5; j++)
                        {
                            Console.Write($" {j + 1} ");
                        }
                        Console.WriteLine();

                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write($" {i + 1} |");

                            for (int j = 0; j < 5; j++)
                            {
                                Console.Write($" {seats[i, j]} ");
                            }

                            Console.WriteLine();
                        }

                        Console.WriteLine("\nA: Available, X: Booked");
                        break;

                    case "2": 
                        Console.WriteLine("\nBook a Seat:");

                        Console.WriteLine("Current Seating Arrangement:");
                        Console.Write("   ");
                        for (int j = 0; j < 5; j++)
                        {
                            Console.Write($" {j + 1} ");
                        }
                        Console.WriteLine();

                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write($" {i + 1} |");

                            for (int j = 0; j < 5; j++)
                            {
                                Console.Write($" {seats[i, j]} ");
                            }

                            Console.WriteLine();
                        }

                        Console.Write("\nEnter row (1-5): ");
                        int row = Convert.ToInt32(Console.ReadLine()) - 1;

                        Console.Write("Enter column (1-5): ");
                        int col = Convert.ToInt32(Console.ReadLine()) - 1;

                        if (row >= 0 && row < 5 && col >= 0 && col < 5)
                        {

                            if (seats[row, col] == 'A')
                            {
                                seats[row, col] = 'X';
                                Console.WriteLine($"Seat at row {row + 1}, column {col + 1} booked successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Error: This seat is already booked.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Invalid row or column. Please enter numbers between 1 and 5.");
                        }
                        break;

                    case "3": 
                        Console.WriteLine("\nCancel a Booking:");

                        Console.WriteLine("Current Seating Arrangement:");
                        Console.Write("   ");
                        for (int j = 0; j < 5; j++)
                        {
                            Console.Write($" {j + 1} ");
                        }
                        Console.WriteLine();

                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write($" {i + 1} |");

                            for (int j = 0; j < 5; j++)
                            {
                                Console.Write($" {seats[i, j]} ");
                            }

                            Console.WriteLine();
                        }

                        Console.Write("\nEnter row (1-5): ");
                        int cancelRow = Convert.ToInt32(Console.ReadLine()) - 1; 

                        Console.Write("Enter column (1-5): ");
                        int cancelCol = Convert.ToInt32(Console.ReadLine()) - 1; 

                        if (cancelRow >= 0 && cancelRow < 5 && cancelCol >= 0 && cancelCol < 5)
                        {
                            if (seats[cancelRow, cancelCol] == 'X')
                            {
                                seats[cancelRow, cancelCol] = 'A'; 
                                Console.WriteLine($"Booking for seat at row {cancelRow + 1}, column {cancelCol + 1} cancelled successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Error: This seat is not booked yet.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Invalid row or column. Please enter numbers between 1 and 5.");
                        }
                        break;

                    case "4": 
                        int availableCount = 0;

                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (seats[i, j] == 'A')
                                {
                                    availableCount++;
                                }
                            }
                        }

                        Console.WriteLine($"\nAvailable Seats: {availableCount} out of 25");
                        Console.WriteLine($"Booked Seats: {25 - availableCount} out of 25");
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