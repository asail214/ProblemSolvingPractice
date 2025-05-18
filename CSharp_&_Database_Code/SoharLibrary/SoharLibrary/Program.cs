using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SoharLibrary.Models;
using SoharLibrary.Context;

namespace SoharLibrary
{
    class Program
    {
        static void Main()
        {
            int counter = GetNextMemberCounter();

            while (true)
            {
                Console.WriteLine("\n--- Sohar Public Library ---");
                Console.WriteLine("1. Register New Member");
                Console.WriteLine("2. Add New Book");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. View Member Borrowed Books");
                Console.WriteLine("6. Show Overdue Books");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                if (choice == "1") // Register New Member
                {
                    RegisterNewMember(ref counter);
                }
                else if (choice == "2") // Add New Book
                {
                    AddNewBook();
                }
                else if (choice == "3") // Borrow Book
                {
                    BorrowBook();
                }
                else if (choice == "4") // Return Book
                {
                    ReturnBook();
                }
                else if (choice == "5") // View Member Borrowed Books
                {
                    ViewMemberBooks();
                }
                else if (choice == "6") // Show Overdue Books
                {
                    ShowOverdueBooks();
                }
                else if (choice == "7") // Exit
                {
                    Console.WriteLine("Thank you for using Sohar Library System.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Try again.");
                }
            }
        }

        // Get the next member counter by finding the highest existing member ID
        static int GetNextMemberCounter()
        {
            using var db = new ApplicationDBContext();
            var lastMember = db.Members
                .OrderByDescending(m => m.MemberId)
                .FirstOrDefault();

            if (lastMember == null)
                return 1; 

            if (lastMember.MemberId.StartsWith("M") && int.TryParse(lastMember.MemberId[1..], out int lastNumber))
                return lastNumber + 1;

            return 1; 
        }

        static void RegisterNewMember(ref int counter)
        {
            Console.Write("Enter Member Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Join Date (dd/mm/yyyy): ");
            DateTime joinDate = DateTime.Parse(Console.ReadLine());

            string memberId = $"M{counter.ToString("D3")}";

            using var db = new ApplicationDBContext();
            db.Members.Add(new Member
            {
                MemberId = memberId,
                Name = name,
                JoinDate = joinDate
            });
            db.SaveChanges();

            Console.WriteLine($"Member registered with ID: {memberId}");
            counter++;
        }

        static void AddNewBook()
        {
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();

            using var db = new ApplicationDBContext();

            // Check if book already exists
            if (db.Books.Any(b => b.ISBN == isbn))
            {
                Console.WriteLine("A book with this ISBN already exists.");
                return;
            }

            db.Books.Add(new Book
            {
                ISBN = isbn,
                Title = title,
                Author = author,
                IsAvailable = true
            });
            db.SaveChanges();

            Console.WriteLine("Book added successfully.");
        }

        static void BorrowBook()
        {
            Console.Write("Enter Member ID: ");
            string memberId = Console.ReadLine();
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Enter Borrow Date (dd/mm/yyyy): ");
            DateTime borrowDate = DateTime.Parse(Console.ReadLine());

            using var db = new ApplicationDBContext();

            // Find the member
            var member = db.Members.FirstOrDefault(m => m.MemberId == memberId);
            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            // Find the book
            var book = db.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (!book.IsAvailable)
            {
                Console.WriteLine("Book is not available.");
                return;
            }

            // Create borrow record
            db.Borrows.Add(new Borrow
            {
                MemberId = memberId,
                ISBN = isbn,
                BorrowDate = borrowDate,
                ReturnDate = null
            });

            // Update book availability
            book.IsAvailable = false;
            db.SaveChanges();

            Console.WriteLine("Book borrowed successfully.");
        }

        static void ReturnBook()
        {
            Console.Write("Enter Member ID: ");
            string memberId = Console.ReadLine();
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Enter Return Date (dd/mm/yyyy): ");
            DateTime returnDate = DateTime.Parse(Console.ReadLine());

            using var db = new ApplicationDBContext();

            // Find the borrow record
            var borrow = db.Borrows
                .FirstOrDefault(b => b.MemberId == memberId &&
                                     b.ISBN == isbn &&
                                     b.ReturnDate == null);

            if (borrow == null)
            {
                Console.WriteLine("Borrow record not found.");
                return;
            }

            // Update return date
            borrow.ReturnDate = returnDate;

            // Find and update book availability
            var book = db.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null)
            {
                book.IsAvailable = true;
            }

            db.SaveChanges();
            Console.WriteLine("Book returned successfully.");
        }

        static void ViewMemberBooks()
        {
            Console.Write("Enter Member ID: ");
            string memberId = Console.ReadLine();

            using var db = new ApplicationDBContext();

            var member = db.Members.FirstOrDefault(m => m.MemberId == memberId);
            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            // Get all unreturned books for this member
            var borrowedBooks = db.Borrows
                .Where(b => b.MemberId == memberId && b.ReturnDate == null)
                .Include(b => b.Book)
                .ToList();

            Console.WriteLine($"\nBorrowed Books for {memberId} - {member.Name}:");

            if (borrowedBooks.Count == 0)
            {
                Console.WriteLine("No books currently borrowed.");
            }
            else
            {
                foreach (var borrow in borrowedBooks)
                {
                    // Using navigation property
                    var book = db.Books.FirstOrDefault(b => b.ISBN == borrow.ISBN);
                    Console.WriteLine($"- {book.Title} (ISBN: {borrow.ISBN})");
                }
            }
        }

        static void ShowOverdueBooks()
        {
            Console.Write("Enter today's date (dd/mm/yyyy): ");
            DateTime today = DateTime.Parse(Console.ReadLine());

            using var db = new ApplicationDBContext();

            // Find overdue books (more than 14 days )
            var overdue = db.Borrows
                .Where(b => b.ReturnDate == null &&
                           (today - b.BorrowDate).TotalDays > 14)
                .Include(b => b.Book)
                .Include(b => b.Member)
                .ToList();

            if (overdue.Count == 0)
            {
                Console.WriteLine("No overdue books.");
                return;
            }

            Console.WriteLine("Overdue Books:");
            foreach (var borrow in overdue)
            {
                var book = db.Books.FirstOrDefault(b => b.ISBN == borrow.ISBN);
                var member = db.Members.FirstOrDefault(m => m.MemberId == borrow.MemberId);

                Console.WriteLine($"- Title: {book.Title}");
                Console.WriteLine($"  ISBN: {book.ISBN}");
                Console.WriteLine($"  Borrowed by: {borrow.MemberId} ({member.Name})");
                Console.WriteLine($"  Borrowed on: {borrow.BorrowDate.ToShortDateString()}\n");
            }
        }
    }
}