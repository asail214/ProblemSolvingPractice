using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportManagementSystem.Models
{
    public class Baggage
    {
        [Key]
        public int BaggageId { get; set; }
        public double Weight { get; set; }
        public string TrackingNumber { get; set; }

        // Foreign key
        public int PassengerId { get; set; }

        // Navigation property
        [ForeignKey("PassengerId")]
        public virtual Passenger Passenger { get; set; }
    }
}