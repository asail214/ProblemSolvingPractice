using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.Models
{
    internal class HelperFunction
    {
        public void CalculateGrowth(double loggedHours, double Wage)
        {
            Console.WriteLine($"your growth salary is {loggedHours * Wage}");
        }

        public double CalculateNet(double loggedHours, double Wage)
        {
            double growth = Wage * loggedHours;
            return growth-(growth*0.03);
        }
    }
}
