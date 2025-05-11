// Assignment 4: Student Grade Management System
namespace Student_Grade_Management
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxStudents = 5;

            string[] students = new string[maxStudents];
            double[] grades = new double[maxStudents];

            int studentCount = 0;

            Console.WriteLine("Assignment4: Student Grade Management System");
            Console.WriteLine("--------------------------------------------");

            string choice;

            do
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Grade");
                Console.WriteLine("3. View All Students and Grades");
                Console.WriteLine("4. Show Average, Highest, and Lowest Grades");
                Console.WriteLine("5. Exit");

                Console.Write("Your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (studentCount < maxStudents)
                        {
                            Console.Write("Enter student name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter grade (0-100): ");
                            double grade = Convert.ToDouble(Console.ReadLine());

                            if (grade >= 0 && grade <= 100)
                            {
                                students[studentCount] = name;
                                grades[studentCount] = grade;
                                studentCount++;

                                Console.WriteLine($"Student {name} added with grade {grade}");
                            }
                            else
                            {
                                Console.WriteLine("Error: Grade out of range!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Maximum number of students reached!");
                        }
                        break;

                    case "2":
                        Console.Write("Enter student name to update: ");
                        string updateStudent = Console.ReadLine();

                        int updateIndex = -1;
                        
                        for (int i = 0; i < studentCount; i++)
                        {
                            if (students[i].ToLower() == updateStudent.ToLower())
                            {
                                updateIndex = i;
                                break;
                            }
                        }

                        if (updateIndex != -1)
                        {
                            Console.Write("Enter new grade (0-100): ");
                            double newGrade = Convert.ToDouble(Console.ReadLine());

                            if (newGrade >= 0 && newGrade <= 100)
                            {
                                grades[updateIndex] = newGrade;
                                Console.WriteLine($"Grade updated for {students[updateIndex]} to {newGrade}.");
                            }
                            else
                            {
                                Console.WriteLine("Error: Grade out of range!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Student not found!");
                        }
                        break;

                    case "3": 
                        if (studentCount > 0)
                        {
                            Console.WriteLine("\nAll Students and Grades:");
                            Console.WriteLine("------------------------");
                            for (int i = 0; i < studentCount; i++)
                            {
                                Console.WriteLine($"{students[i]}: {grades[i]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No student found!");
                        }
                        break;

                    case "4": 
                        if (studentCount > 0)
                        {
                            double sum = 0;
                            double highest = grades[0];
                            double lowest = grades[0];
                            string highestStudent = students[0];
                            string lowestStudent = students[0];

                            for (int i = 0; i < studentCount; i++)
                            {
                                sum += grades[i];

                                if (grades[i] > highest)
                                {
                                    highest = grades[i];
                                    highestStudent = students[i];
                                }

                                if (grades[i] < lowest)
                                {
                                    lowest = grades[i];
                                    lowestStudent = students[i];
                                }
                            }

                            double average = sum / studentCount;

                            Console.WriteLine("\nGrade Statistics:");
                            Console.WriteLine("----------------");
                            Console.WriteLine($"Average Grade: {average}");
                            Console.WriteLine($"Highest Grade: {highest} (Student: {highestStudent})");
                            Console.WriteLine($"Lowest Grade: {lowest} (Student: {lowestStudent})");
                        }
                        else
                        {
                            Console.WriteLine("No student found!");
                        }
                        break;

                    case "5": // Exit
                        Console.WriteLine("EXIT!");
                        break;

                    default:
                        Console.WriteLine("Error: Invalid option.\nTry again!");
                        break;
                }
            } while (choice != "5");
        }
    }
}