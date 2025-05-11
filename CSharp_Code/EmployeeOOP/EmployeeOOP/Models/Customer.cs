using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeOOP.Models
{
    internal class Customer : User
    {
        public double pay { get; set; }

        public Customer(string name, int age, int id, double pay) : base(name, age, id)
        {
            this.pay = pay;
        }

        public override void Display()
        {
            Console.WriteLine("Customer: ");
            Console.WriteLine($"{id}: {name} with {age} years old.");
            Console.WriteLine($"Who paied {pay} OR.");
        }
    }
}
