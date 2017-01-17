using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Utilities.Models
{
    public class RemoveFromCartDto
    {
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }
        public int CartTotal { get; set; }
        public string Message { get; set; }
        
    }
}
