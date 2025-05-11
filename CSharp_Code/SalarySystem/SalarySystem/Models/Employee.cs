using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.Models
{
    internal class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public double loggedHours { get; set; }
        public double wage { get; set; }
        public Employee(int id, string name, double loggedHours, double wage) 
        { 
            this.id = id;
            this.name = name;
            this.loggedHours = loggedHours;
            this.wage = wage;
        }

        public void CalculateGrowth()
        {
            Console.WriteLine($"your growth salary is {loggedHours * wage}");
        }

        public void CalculateNet()
        {
            double growth = wage * loggedHours;
            Console.WriteLine($"your growth salary is {growth - (growth * 0.03)}");
        }
    }
}
