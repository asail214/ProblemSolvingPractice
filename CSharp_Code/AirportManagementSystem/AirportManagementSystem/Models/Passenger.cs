using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirportManagementSystem.Models
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string PassportNumber { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }

        // Navigation properties
        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Baggage> Baggage { get; set; }
    }
}