using EmployeeOOP.Models;

namespace EmployeeOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //User u = new User();

            Employee e = new Employee("Ali", 00, 22, 120);
            e.Display();

            Console.WriteLine();

            Customer c = new Customer("Mohammed", 01, 24, 40);
            c.Display();

            Manager m = new Manager("Boss", 02, 32, "Come early");
            m.Display();
        }
    }
}
