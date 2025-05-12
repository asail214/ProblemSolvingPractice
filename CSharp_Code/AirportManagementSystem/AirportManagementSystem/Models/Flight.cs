using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AirportManagementSystem.Models
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public string DestinationCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Status { get; set; }

        // Foreign keys
        public int AirlineId { get; set; }
        public int? GateId { get; set; }

        // Navigation properties
        [ForeignKey("AirlineId")]
        public virtual Airline Airline { get; set; }

        [ForeignKey("GateId")]
        public virtual Gate Gate { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}