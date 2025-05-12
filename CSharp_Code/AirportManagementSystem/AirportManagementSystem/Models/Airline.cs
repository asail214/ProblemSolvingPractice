using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AirportManagementSystem.Models
{
    public class Airline
    {
        [Key]
        public int AirlineId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string RepresentativeName { get; set; }

        // Navigation properties
        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Gate> AssignedGates { get; set; }
    }
}