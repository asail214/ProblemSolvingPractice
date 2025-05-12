using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AirportManagementSystem.Models
{
    public class Terminal
    {
        [Key]
        public int TerminalId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }

        // Navigation properties
        public virtual ICollection<Gate> Gates { get; set; }
        public virtual ICollection<SecurityCheckpoint> SecurityCheckpoints { get; set; }
    }
}
