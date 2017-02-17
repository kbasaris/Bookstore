using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace BookStore.Data.Entities
{
    [Table("Item")]
    public class Item : IEntityBase
    {
        public int Id { get; set; }
        public int BookID { get; set; }
        public bool Reorder { get; set; }
        public int? ReorderAmount { get; set; }
        public decimal? Price { get; set; }
        public int? NumOfStocks { get; set; }
        public virtual Book Book { get; set; }

    }
}
