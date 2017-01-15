using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Utilities.Models
{
    public class ShoppingCartDto
    {
            public string UserId { get; set; }
            public List<CartItemDto> CartItems { get; set; }
            public decimal CartTotal { get; set; }
    }
}
