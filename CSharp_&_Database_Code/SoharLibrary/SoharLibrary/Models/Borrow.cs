using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoharLibrary.Models
{
    public class Borrow
    {
        public int Id { get; set; }

        public string MemberId { get; set; }
        public Member Member { get; set; }

        public string ISBN { get; set; }
        public Book Book { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}

