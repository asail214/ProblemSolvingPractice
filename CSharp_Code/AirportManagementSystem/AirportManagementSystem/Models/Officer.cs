using System.ComponentModel.DataAnnotations;

namespace AirportManagementSystem.Models
{
    public class Officer
    {
        [Key]
        public int OfficerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
    }
}