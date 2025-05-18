using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoharLibrary.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string MemberId { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public List<Borrow> Borrows { get; set; }
    }

}
