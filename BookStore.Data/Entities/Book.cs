using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace BookStore.Data.Entities
{
    [Table("Book")]
    public partial class Book
    {
        public Book()
        {
            Stocks = new HashSet<Stock>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
