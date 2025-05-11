//Assignment 2: Online Course Enrollment System
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_OnlineCourseEnrollmentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CourseCatalog catalog = new CourseCatalog();

            catalog.AddCourse(new VideoCourse
            {
                Name = "C# Basics",
                Instructor = "John Smith",
                Level = Level.Beginner,
                DurationInHours = 2.5
            });

            catalog.AddCourse(new LiveSession
            {
                Name = "Advanced C# Programming",
                Instructor = "Jane Doe",
                Level = Level.Advanced,
                Schedule = new DateTime(2025, 6, 15, 14, 0, 0)
            });

            catalog.AddCourse(new VideoCourse
            {
                Name = "Object-Oriented Design",
                Instructor = "Bob Johnson",
                Level = Level.Intermediate,
                DurationInHours = 4.0
            });

            catalog.AddCourse(new LiveSession
            {
                Name = "Data Structures in C#",
                Instructor = "Alice Brown",
                Level = Level.Intermediate,
                Schedule = new DateTime(2025, 7, 10, 10, 0, 0)
            });

            catalog.AddCourse(new VideoCourse
            {
                Name = "Database Fundamentals",
                Instructor = "Mike Wilson",
                Level = Level.Beginner,
                DurationInHours = 3.0
            });

            Console.WriteLine("Beginner Courses:");
            foreach (var course in catalog[Level.Beginner])
            {
                Console.WriteLine($"- {course.Name} by {course.Instructor}");
                if (course is VideoCourse vc)
                    Console.WriteLine($"  Duration: {vc.DurationInHours} hours");
                else if (course is LiveSession ls)
                    Console.WriteLine($"  Schedule: {ls.Schedule}");
            }

            Console.WriteLine("\nIntermediate Courses:");
            foreach (var course in catalog[Level.Intermediate])
            {
                Console.WriteLine($"- {course.Name} by {course.Instructor}");
                if (course is VideoCourse vc)
                    Console.WriteLine($"  Duration: {vc.DurationInHours} hours");
                else if (course is LiveSession ls)
                    Console.WriteLine($"  Schedule: {ls.Schedule}");
            }

            Console.WriteLine("\nAdvanced Courses:");
            foreach (var course in catalog[Level.Advanced])
            {
                Console.WriteLine($"- {course.Name} by {course.Instructor}");
                if (course is VideoCourse vc)
                    Console.WriteLine($"  Duration: {vc.DurationInHours} hours");
                else if (course is LiveSession ls)
                    Console.WriteLine($"  Schedule: {ls.Schedule}");
            }
        }
    }

    enum Level
    {
        Beginner,
        Intermediate,
        Advanced
    }

    class Course
    {
        public string Name { get; set; }
        public string Instructor { get; set; }
        public Level Level { get; set; }
    }

    class VideoCourse : Course
    {
        public double DurationInHours { get; set; }
    }

    class LiveSession : Course
    {
        public DateTime Schedule { get; set; }
    }

    class CourseCatalog
    {
        private List<Course> courses = new List<Course>();

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public List<Course> this[Level level]
        {
            get
            {
                List<Course> result = new List<Course>();
                foreach (var course in courses)
                {
                    if (course.Level == level)
                    {
                        result.Add(course);
                    }
                }
                return result;
            }
        }
    }
}