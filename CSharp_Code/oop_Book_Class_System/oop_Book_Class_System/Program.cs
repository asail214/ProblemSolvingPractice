// OOP Assignment 1: Book Class System
using System;

namespace oop_Book_Class_System
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }

        // Constructor
        public Book(string title, string author, int year, string isbn)
        {
            Title = title;
            Author = author;
            Year = year;
            ISBN = isbn;
        }

        public void PrintBookInfo()
        {
            Console.WriteLine("\nBook Information:");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"ISBN: {ISBN}");
        }

        public bool IsOlderThan(int yearToCompare)
        {
            return Year < yearToCompare;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Book Class System");
            Console.WriteLine("----------------");

            Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, "978-0743273565");
            Book book2 = new Book("Programming C#", "Ian Griffiths", 2020, "978-1491976708");
            Book book3 = new Book("Data Structures and Algorithms", "Michael T. Goodrich", 2014, "978-1118771334");

            Console.WriteLine("\nDemonstrating book class methods:");

            book1.PrintBookInfo();
            book2.PrintBookInfo();
            book3.PrintBookInfo();

            int yearToCompare = 2000;
            Console.WriteLine($"\nChecking if books are older than {yearToCompare}:");

            Console.WriteLine($"{book1.Title} is older than {yearToCompare}: {book1.IsOlderThan(yearToCompare)}");
            Console.WriteLine($"{book2.Title} is older than {yearToCompare}: {book2.IsOlderThan(yearToCompare)}");
            Console.WriteLine($"{book3.Title} is older than {yearToCompare}: {book3.IsOlderThan(yearToCompare)}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
