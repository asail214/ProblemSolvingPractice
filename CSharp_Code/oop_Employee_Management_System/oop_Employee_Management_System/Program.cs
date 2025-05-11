// OOP Assignment 8: Employee Management System with Polymorphism
using System;
using System.Collections.Generic;

namespace oop_Employee_Management_System
{
    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary)
        {
            if (salary < 0)
            {
                throw new ArgumentException("Salary cannot be negative");
            }

            Name = name;
            Salary = salary;
        }

        public virtual double CalculateBonus()
        {
            return Salary * 0.10; 
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Salary: ${Salary}");
            Console.WriteLine($"Bonus: ${CalculateBonus()}");
        }
    }

    class Manager : Employee
    {
        public int TeamSize { get; set; }

        public Manager(string name, double salary, int teamSize)
            : base(name, salary)
        {
            TeamSize = teamSize;
        }

        public override double CalculateBonus()
        {
            return Salary * 0.20; 
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Role: Manager");
            Console.WriteLine($"Team Size: {TeamSize}");
        }
    }

    class Developer : Employee
    {
        public string ProgrammingLanguage { get; set; }

        public Developer(string name, double salary, string programmingLanguage)
            : base(name, salary)
        {
            ProgrammingLanguage = programmingLanguage;
        }

        public override double CalculateBonus()
        {
            return Salary * 0.15; 
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Role: Developer");
            Console.WriteLine($"Programming Language: {ProgrammingLanguage}");
        }
    }

    class HR
    {
        public void PrintBonusReport(List<Employee> employees)
        {
            Console.WriteLine("\nBonus Report:");
            Console.WriteLine("-------------");

            double totalBonus = 0;

            foreach (Employee emp in employees)
            {
                double bonus = emp.CalculateBonus();
                totalBonus += bonus;
                Console.WriteLine($"{emp.Name} - Bonus: ${bonus}");
            }

            Console.WriteLine($"Total Bonuses: ${totalBonus}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee Management System");
            Console.WriteLine("-------------------------");

            try
            {
                Employee regularEmployee = new Employee("Ahmed", 50000);
                Manager manager = new Manager("Sara", 80000, 10);
                Developer developer = new Developer("Mohammed", 65000, "C#");

                try
                {
                    Employee invalidEmployee = new Employee("Invalid", -1000);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error creating employee: {ex.Message}");
                }

                Console.WriteLine("\nEmployee Information:");
                Console.WriteLine("--------------------");
                regularEmployee.DisplayInfo();

                Console.WriteLine("\nManager Information:");
                Console.WriteLine("-------------------");
                manager.DisplayInfo();

                Console.WriteLine("\nDeveloper Information:");
                Console.WriteLine("---------------------");
                developer.DisplayInfo();

                HR hr = new HR();
                List<Employee> employees = new List<Employee>
                {
                    regularEmployee,
                    manager,
                    developer
                };

                hr.PrintBonusReport(employees);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit:");
            Console.ReadKey();
        }
    }
}
