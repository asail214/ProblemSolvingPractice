using SalarySystem.Models;

namespace SalarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcom to salary calculator program\n--------------------------------");

            Console.Write("How many employess do you want to enter there data? ");
            int num = int.Parse(Console.ReadLine());

            Employee [] employees = new Employee[num];
            int id  = 0;

            foreach (Employee e in employees) {
                Console.WriteLine("------------------------");
                Console.WriteLine($"Employee({id + 1}) info: ");
                Console.Write("Enter the name: ");
                string name = Console.ReadLine();

                Console.Write("Enter the logged hours? ");
                double loggedHours = double.Parse(Console.ReadLine());
            
                Console.Write("Enter th wage? ");
                double wage = double.Parse(Console.ReadLine());

                new Employee(id + 1,name, loggedHours, wage);
                e.CalculateGrowth();
                e.CalculateNet(); 
            }

            //int n = 0;
            //foreach (Employee e in employees) {
            //    Console.WriteLine("------------------------");
            //    Console.WriteLine($"Employee({n + 1}) calculation: ");
            //    e.CalculateGrowth();
            //    e.CalculateNet();
            //}
        }
    }
}
