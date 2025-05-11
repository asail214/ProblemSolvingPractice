// OOP Assignment 2: Student Grade Tracker
using System;
using System.Collections.Generic;

namespace oop_Student_Grade_Tracker
{
    class Student
    {
        public string Name { get; set; }
        public string ID { get; set; }
        private List<int> Grades { get; set; }

        public Student(string name, string id)
        {
            Name = name;
            ID = id;
            Grades = new List<int>();
        }

        public void AddGrade(int grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                Grades.Add(grade);
                Console.WriteLine($"Grade {grade} added for {Name}.");
            }
            else
            {
                Console.WriteLine("Error: Grade must be between 0 and 100.");
            }
        }

        public double CalculateAverage()
        {
            if (Grades.Count == 0)
                return 0;

            int sum = 0;
            foreach (int grade in Grades)
            {
                sum += grade;
            }

            return (double)sum / Grades.Count;
        }

        public void PrintStudentReport()
        {
            Console.WriteLine("\nStudent Report");
            Console.WriteLine("---------------");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine("Grades:");

            if (Grades.Count == 0)
            {
                Console.WriteLine("No grades recorded yet.");
            }
            else
            {
                foreach (int grade in Grades)
                {
                    Console.WriteLine($"- {grade}");
                }

                Console.WriteLine($"Average Grade: {CalculateAverage():F2}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Student Grade Tracker");
            Console.WriteLine("--------------------");

            // Create multiple students
            Student student1 = new Student("Ahmed", "S001");
            Student student2 = new Student("Sara", "S002");
            Student student3 = new Student("Mohammed", "S003");

            // Add grades for each student
            student1.AddGrade(85);
            student1.AddGrade(92);
            student1.AddGrade(78);

            student2.AddGrade(95);
            student2.AddGrade(88);
            student2.AddGrade(91);

            student3.AddGrade(75);
            student3.AddGrade(80);
            student3.AddGrade(82);

            // Print individual reports
            student1.PrintStudentReport();
            student2.PrintStudentReport();
            student3.PrintStudentReport();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}