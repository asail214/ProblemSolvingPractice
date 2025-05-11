using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeOOP.Models
{
    sealed class Manager : User
    {
        public string rulesMaker { get; set; }
        public Manager(string name, int id, int age, string rulesMaker):
                base(name,id,age){ 
            this.rulesMaker = rulesMaker;
        }

        public override void Display()
        {
            Console.WriteLine("Manager: ");
            Console.WriteLine($"{id}: {name} with {age} years old.");
            Console.WriteLine($"Put the rules: {rulesMaker}");
        }
    }
