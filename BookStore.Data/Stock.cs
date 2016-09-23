namespace BookStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        public int ID { get; set; }

        public int? BookID { get; set; }

        public int? Barcode { get; set; }

        public decimal? Price { get; set; }

        public bool? Reorder { get; set; }

        public int? ReeorderAmount { get; set; }

        [Column("Stock")]
        public int? Stock1 { get; set; }

        public virtual Book Book { get; set; }
    }
}
