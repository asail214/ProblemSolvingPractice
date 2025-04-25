/*
 * Topic: Employment Salary System 
 * 
 * Problem Definition:
 * -------------------
 * Build a simple C# console application to calculate and display the salary
 * for each employee in a small organization. The user will enter data for
 * multiple employees, including name, working hours, and hourly rate.
 * The system will calculate the salary for each employee after subtracting
 * a tax percentage, then print a summary.
 * 
 * Solution Overview:
 * -------------------
 * - Uses a basic 'Employee' class to store employee data and salary calculation logic.
 * - The program collects information for multiple employees using a list and a for-loop.
 * - Salaries are calculated (after tax) and printed in a summary table.
 * - The code uses simple structure, variable names, and clear comments to help beginners.
 */

using System;
using System.Collections.Generic;

namespace Employment_Salary_System
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask the user for the number of employees
            Console.Write("Enter number of employees: ");
            int count = int.Parse(Console.ReadLine());

            // List to store all employees
            List<Employee> employees = new List<Employee>();

            // Loop to collect employee data
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine($"\nEmployee {i}:");

                Console.Write("Enter name: ");
                string name = Console.ReadLine();

                Console.Write("Enter working hours: ");
                int hours = int.Parse(Console.ReadLine());

                Console.Write("Enter hourly rate: ");
                double rate = double.Parse(Console.ReadLine());

                // Create new employee and add to the list
                Employee emp = new Employee(name, hours, rate);
                employees.Add(emp);
            }

            // Print summary for all employees
            Console.WriteLine("\n--- Salary Summary ---");
            foreach (var emp in employees)
            {
                emp.PrintSalary();
            }
        }
    }

    // Represents an employee with basic info and salary calculation.
    public class Employee
    {
        public string Name;
        public int Hours;
        public double HourlyRate;
        private const double TaxRate = 0.03; // 3% tax

        // Initialize employee with name, hours, and rate.
        public Employee(string name, int hours, double rate)
        {
            Name = name;
            Hours = hours;
            HourlyRate = rate;
        }

        // Calculate the net salary after tax.
        public double CalculateSalary()
        {
            double gross = Hours * HourlyRate;
            return gross - (gross * TaxRate);
        }

        // Print the salary for this employee.
        public void PrintSalary()
        {
            Console.WriteLine($"{Name}'s salary is: {CalculateSalary():F2} OMR");
        }
    }
}

