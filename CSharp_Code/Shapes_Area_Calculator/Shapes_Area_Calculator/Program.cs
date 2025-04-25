/*
 * Topic: Shapes Area Calculator (Beginner OOP Example)
 * 
 * Problem Definition:
 * -------------------
 * Build a simple C# console program using OOP to:
 *   - Model different geometric shapes (Rectangle, Square, Circle, Triangle).
 *   - Store a color for each shape.
 *   - Calculate and display the area for each shape.
 * 
 * Solution Overview:
 * -------------------
 * - Use a base class 'Shape' with a virtual method for area and info printing.
 * - Use child classes for each shape type, overriding area calculation and info display.
 * - Demonstrate inheritance and method overriding in an easy, beginner-friendly way.
 */

using System;

namespace Shapes_Area_Calculator
{
    // The base class for all shapes.
    public class Shape
    {
        public string Color { get; set; }

        public Shape(string color)
        {
            Color = color;
        }

        // Virtual method for area; overridden by each shape.
        public virtual double GetArea()
        {
            return 0;
        }

        // Prints basic shape info.
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Shape color: {Color}");
        }
    }

    // Rectangle shape (inherits from Shape).
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width, string color) : base(color)
        {
            Length = length;
            Width = width;
        }

        public override double GetArea()
        {
            return Length * Width;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Rectangle → Length: {Length}, Width: {Width}, Area: {GetArea()}");
        }
    }

    // Square shape (inherits from Rectangle).
    public class Square : Rectangle
    {
        public Square(double side, string color) : base(side, side, color)
        {
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"This is a square with side: {Length}");
        }
    }

    // Circle shape (inherits from Shape).
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius, string color) : base(color)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Circle → Radius: {Radius}, Area: {GetArea():F2}");
        }
    }

    // Triangle shape (inherits from Shape).
    public class Triangle : Shape
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }

        public Triangle(double baseLength, double height, string color) : base(color)
        {
            BaseLength = baseLength;
            Height = height;
        }

        public override double GetArea()
        {
            return 0.5 * BaseLength * Height;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Triangle → Base: {BaseLength}, Height: {Height}, Area: {GetArea()}");
        }
    }

    // Main program to demonstrate shapes.
    class Program
    {
        static void Main(string[] args)
        {
            // Create different shapes
            Rectangle rect = new Rectangle(4, 6, "Red");
            Square square = new Square(5, "Blue");
            Circle circle = new Circle(3, "Green");
            Triangle triangle = new Triangle(4, 3, "Yellow");

            // Display info for each shape
            Console.WriteLine("\n--- Rectangle Info ---");
            rect.PrintInfo();

            Console.WriteLine("\n--- Square Info ---");
            square.PrintInfo();

            Console.WriteLine("\n--- Circle Info ---");
            circle.PrintInfo();

            Console.WriteLine("\n--- Triangle Info ---");
            triangle.PrintInfo();
        }
    }
}

