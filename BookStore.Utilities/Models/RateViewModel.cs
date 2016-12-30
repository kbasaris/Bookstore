using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Utilities.Models
{
    public class RateViewModel
    {
        public int BookId { get; set; }
        public bool Active { get; set; }
        public string Username { get; set; }
        public int Vote { get; set; }

    }
}
