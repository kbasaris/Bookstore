using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Entities
{
    public class ShoppingCart : IEntityBase
    {
        public int Id { get; set; }
        [MaxLength(128)]
        public string UserId { get; set; }
        public string CartId { get; set; }
        public int ItemId { get; set; }
        public int TotalItems { get; set; }
        public virtual Item Item { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
