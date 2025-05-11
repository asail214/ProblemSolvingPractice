//Assignment 5: Task Tracker Application
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP__TaskTrackerApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskList taskList = new TaskList();

            taskList.AddTask(new Task
            {
                Title = "Complete Assignment",
                Description = "Finish the C# OOP assignment",
                Priority = TaskPriority.High,
                IsCompleted = false
            });

            taskList.AddTask(new Task
            {
                Title = "Buy Groceries",
                Description = "Get milk, eggs, and bread",
                Priority = TaskPriority.Medium,
                IsCompleted = false
            });

            taskList.AddTask(new Task
            {
                Title = "Call Mom",
                Description = "Weekly check-in call",
                Priority = TaskPriority.Low,
                IsCompleted = false
            });

            taskList.AddTask(new Task
            {
                Title = "Pay Bills",
                Description = "Pay electricity and water bills",
                Priority = TaskPriority.High,
                IsCompleted = false
            });

            taskList.AddTask(new Task
            {
                Title = "Clean Room",
                Description = "Vacuum and dust the bedroom",
                Priority = TaskPriority.Medium,
                IsCompleted = false
            });

            Console.WriteLine("\nHigh Priority Tasks:");
            foreach (var task in taskList[TaskPriority.High])
            {
                Console.WriteLine($"- {task.Title} - {(task.IsCompleted ? "Completed" : "Pending")}");
            }

            Console.WriteLine("\nMarking tasks as complete:");
            taskList.MarkComplete("Complete Assignment");
            taskList.MarkComplete("Pay Bills");

            Console.WriteLine("\nHigh Priority Tasks after completing some:");
            foreach (var task in taskList[TaskPriority.High])
            {
                Console.WriteLine($"- {task.Title} - {(task.IsCompleted ? "Completed" : "Pending")}");
            }

            Console.WriteLine("\nAll Tasks:");
            taskList.ShowAll();
        }
    }

    enum TaskPriority
    {
        Low,
        Medium,
        High
    }

    class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public bool IsCompleted { get; set; }
    }

    class TaskList
    {
        private List<Task> tasks = new List<Task>();

        public void AddTask(Task task)
        {
            tasks.Add(task);
            Console.WriteLine($"Task '{task.Title}' added with {task.Priority} priority");
        }

        public void MarkComplete(string taskTitle)
        {
            Task task = tasks.Find(t => t.Title.Equals(taskTitle, StringComparison.OrdinalIgnoreCase));
            if (task != null)
            {
                task.IsCompleted = true;
                Console.WriteLine($"Task '{taskTitle}' marked as complete");
            }
            else
            {
                Console.WriteLine($"Task '{taskTitle}' not found");
            }
        }

        public void ShowAll()
        {
            Console.WriteLine("All Tasks:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"- {task.Title} ({task.Priority}) - {(task.IsCompleted ? "Completed" : "Pending")}");
                Console.WriteLine($"  Description: {task.Description}");
            }
        }

        public List<Task> this[TaskPriority priority]
        {
            get
            {
                return tasks.Where(t => t.Priority == priority).ToList();
            }
        }
    }
}
