using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeOOP.Models
{
    abstract class User
    {
        public string name { get; set; }
        public int age { get; set; }
        public int id { get; set; }

        public User(string name, int age, int id)
        {
            this.name = name;
            this.age = age;
            this.id = id;
        }

        public abstract void Display();
    }
}
