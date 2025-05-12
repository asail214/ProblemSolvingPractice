using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportManagementSystem.Models
{
    public class Gate
    {
        [Key]
        public int GateId { get; set; }
        public string GateNumber { get; set; }
        public bool IsAvailable { get; set; }

        // Foreign keys
        public int TerminalId { get; set; }
        public int? AirlineId { get; set; }

        // Navigation properties
        [ForeignKey("TerminalId")]
        public virtual Terminal Terminal { get; set; }

        [ForeignKey("AirlineId")]
        public virtual Airline Airline { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}