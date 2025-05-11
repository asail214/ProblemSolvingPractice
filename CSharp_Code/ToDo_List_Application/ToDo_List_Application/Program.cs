// Assignment 6: To-Do List Application
namespace Todo_List_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxTasks = 5;

            string[] tasks = new string[maxTasks];
            bool[] isCompleted = new bool[maxTasks];

            int taskCount = 0;

            Console.WriteLine("Assignment6: To-Do List Application");
            Console.WriteLine("-----------------------------------");

            string choice;

            do
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Delete Task");
                Console.WriteLine("3. Mark Task as Completed");
                Console.WriteLine("4. View Tasks");
                Console.WriteLine("5. Clear Completed Tasks");
                Console.WriteLine("6. Exit");

                Console.Write("Your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (taskCount < maxTasks)
                        {
                            Console.Write("Enter task description: ");
                            string taskDesc = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(taskDesc))
                            {
                                tasks[taskCount] = taskDesc;
                                isCompleted[taskCount] = false;
                                taskCount++;

                                Console.WriteLine("Added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Error: No empty task description!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Maximum number of tasks reached!");
                        }
                        break;

                    case "2":
                        if (taskCount > 0)
                        {
                            Console.WriteLine("\nCurrent Tasks:");
                            for (int i = 0; i < taskCount; i++)
                            {
                                string status = isCompleted[i] ? "Done" : "Pending";
                                Console.WriteLine($"{i + 1}. {tasks[i]} - {status}");
                            }

                            Console.Write("\nEnter task number to delete: ");
                            int taskNum = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (taskNum >= 0 && taskNum < taskCount)
                            {
                                for (int i = taskNum; i < taskCount - 1; i++)
                                {
                                    tasks[i] = tasks[i + 1];
                                    isCompleted[i] = isCompleted[i + 1];
                                }

                                taskCount--;
                                Console.WriteLine("Deleted successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Error: Invalid task number!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No task to be deleted!");
                        }
                        break;

                    case "3":
                        if (taskCount > 0)
                        {
                            Console.WriteLine("\nCurrent Tasks:");
                            for (int i = 0; i < taskCount; i++)
                            {
                                string status = isCompleted[i] ? "Done" : "Pending";
                                Console.WriteLine($"{i + 1}. {tasks[i]} - {status}");
                            }

                            Console.Write("\nEnter task number to mark as completed: ");
                            int markNum = Convert.ToInt32(Console.ReadLine()) - 1;

                            if (markNum >= 0 && markNum < taskCount)
                            {
                                if (!isCompleted[markNum])
                                {
                                    isCompleted[markNum] = true;
                                    Console.WriteLine("Task marked as completed.");
                                }
                                else
                                {
                                    Console.WriteLine("Task is already marked as completed.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error: Invalid task number.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No tasks available to mark as completed.");
                        }
                        break;

                    case "4":
                        if (taskCount > 0)
                        {
                            Console.WriteLine("\nAll Tasks:");
                            Console.WriteLine("-------------");

                            for (int i = 0; i < taskCount; i++)
                            {
                                string status = isCompleted[i] ? "Done" : "Pending";
                                Console.WriteLine($"{i + 1}. {tasks[i]} - {status}");
                            }

                            int completedCount = 0;
                            for (int i = 0; i < taskCount; i++)
                            {
                                if (isCompleted[i])
                                {
                                    completedCount++;
                                }
                            }

                            Console.WriteLine($"\nTotal Tasks: {taskCount}");
                            Console.WriteLine($"Completed: {completedCount}");
                            Console.WriteLine($"Pending: {taskCount - completedCount}");
                        }
                        else
                        {
                            Console.WriteLine("No tasks available.");
                        }
                        break;

                    case "5":
                        if (taskCount > 0)
                        {
                            int completedCount = 0;

                            for (int i = 0; i < taskCount; i++)
                            {
                                if (isCompleted[i])
                                {
                                    completedCount++;
                                }
                            }

                            if (completedCount > 0)
                            {
                                string[] tempTasks = new string[maxTasks];
                                bool[] tempCompleted = new bool[maxTasks];
                                int newIndex = 0;

                                for (int i = 0; i < taskCount; i++)
                                {
                                    if (!isCompleted[i])
                                    {
                                        tempTasks[newIndex] = tasks[i];
                                        tempCompleted[newIndex] = false;
                                        newIndex++;
                                    }
                                }

                                tasks = tempTasks;
                                isCompleted = tempCompleted;
                                taskCount -= completedCount;

                                Console.WriteLine($"{completedCount} completed tasks cleared.");
                            }
                            else
                            {
                                Console.WriteLine("No completed tasks to clear.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No tasks available.");
                        }
                        break;

                    case "6": 
                        Console.WriteLine("EXIT!");
                        break;

                    default:
                        Console.WriteLine("Error: Invalid option\n Try again!");
                        break;
                }
            } while (choice != "6");
        }
    }
}