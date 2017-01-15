using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class ShoppingCart : IEntityBases
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CartId { get; set; }
        public int ItemId { get; set; }
        public int TotalItems { get; set; }
        public virtual Item Item { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
