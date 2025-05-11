using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeOOP.Models
{
    internal class Employee : User
    {
        public double salary { get; set; }

        public Employee(string name, int age, int id, double salary) :
                        base(name, age, id)
        {
            this.salary = salary;
        }

        public override void Display()
        {
            Console.WriteLine("Employee: ");
            Console.WriteLine($"{id}: {name} with {age} years old.");
            Console.WriteLine($"With a salary of {salary}");
        }
    }
}
