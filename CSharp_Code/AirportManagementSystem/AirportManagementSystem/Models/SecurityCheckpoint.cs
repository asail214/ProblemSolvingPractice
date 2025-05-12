using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportManagementSystem.Models
{
    public class SecurityCheckpoint
    {
        [Key]
        public int CheckpointId { get; set; }
        public int PassengerCapacity { get; set; }
        public string Location { get; set; }

        // Foreign key
        public int TerminalId { get; set; }

        // Navigation property
        [ForeignKey("TerminalId")]
        public virtual Terminal Terminal { get; set; }
    }
}