/*
 * Topic: List Processor – Even Number Filter & Simple Adder
 * 
 * Problem Definition:
 * -------------------
 * Write a basic C# console program that:
 *   - Takes a list of integers.
 *   - Finds all the even numbers in the list.
 *   - Demonstrates simple method overloading with an 'add' method.
 *
 * Solution Overview:
 * -------------------
 * - The 'NumberProcessor' class provides methods to check for even numbers,
 *   filter even numbers from a list, and add numbers.
 * - The program creates a list of numbers, prints the even numbers, and 
 *   demonstrates the 'add' methods.
 * - The code is clear, simple, and well-commented for beginner learning.
 */

using System;
using System.Collections.Generic;

namespace PracticeC_
{
    // The main class for running the List Processor application.
    class ListProcessor
    {
        static void Main(string[] args)
        {
            // Create an instance of NumberProcessor to use its methods
            NumberProcessor processor = new NumberProcessor();

            // Sample list of numbers
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Get only the even numbers
            List<int> evenNumbers = processor.GetEvenNumbers(numbers);

            // Print even numbers
            Console.WriteLine("Even numbers:");
            foreach (int num in evenNumbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Demonstrate overloaded add methods
            int sum2 = processor.Add(3, 5);
            int sum3 = processor.Add(1, 2, 3);
            Console.WriteLine($"\nSum of 3 and 5: {sum2}");
            Console.WriteLine($"Sum of 1, 2, and 3: {sum3}");
        }
    }

    // Provides methods for processing lists and numbers.
    public class NumberProcessor
    {
        // Checks if a number is even.
        public bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        // Returns a list of even numbers from the given list.
        public List<int> GetEvenNumbers(List<int> numbers)
        {
            List<int> evens = new List<int>();

            foreach (int num in numbers)
            {
                if (IsEven(num))
                {
                    evens.Add(num);
                }
            }

            return evens;
        }

        // Adds two integers (method overloading).
        public int Add(int x, int y)
        {
            return x + y;
        }

        // Adds three integers (method overloading).
        public int Add(int x, int y, int z)
        {
            return x + y + z;
        }
    }
}
