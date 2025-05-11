//Assignment 4: Library System with Book Status Tracking
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_LibrarySystem_BookTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook(new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Status = BookStatus.Available });
            library.AddBook(new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Status = BookStatus.CheckedOut });
            library.AddBook(new Book { Title = "1984", Author = "George Orwell", Status = BookStatus.Available });
            library.AddBook(new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Status = BookStatus.Reserved });
            library.AddBook(new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", Status = BookStatus.Available });

            Console.WriteLine("Accessing books by title:");
            Book book = library["1984"];
            Console.WriteLine($"Found book: {book.Title} by {book.Author}, Status: {book.Status}");

            Console.WriteLine("\nChanging book status:");
            library.ChangeStatus("The Great Gatsby", BookStatus.CheckedOut);

            Console.WriteLine("\nAvailable books:");
            foreach (var availableBook in library.ShowBooksByStatus(BookStatus.Available))
            {
                Console.WriteLine($"- {availableBook.Title} by {availableBook.Author}");
            }

            Console.WriteLine("\nChecked out books:");
            foreach (var checkedOutBook in library.ShowBooksByStatus(BookStatus.CheckedOut))
            {
                Console.WriteLine($"- {checkedOutBook.Title} by {checkedOutBook.Author}");
            }

            Console.WriteLine("\nReserved books:");
            foreach (var reservedBook in library.ShowBooksByStatus(BookStatus.Reserved))
            {
                Console.WriteLine($"- {reservedBook.Title} by {reservedBook.Author}");
            }
        }
    }

    enum BookStatus
    {
        Available,
        CheckedOut,
        Reserved
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public BookStatus Status { get; set; }
    }

    class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public Book this[string title]
        {
            get
            {
                return books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            }
        }

        public void ChangeStatus(string title, BookStatus status)
        {
            Book book = this[title];
            if (book != null)
            {
                book.Status = status;
                Console.WriteLine($"Status of '{title}' changed to {status}");
            }
            else
            {
                Console.WriteLine($"Book with title '{title}' not found");
            }
        }

        public List<Book> ShowBooksByStatus(BookStatus status)
        {
            return books.Where(b => b.Status == status).ToList();
        }
    }
}
