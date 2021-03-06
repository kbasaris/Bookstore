using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace BookStore.Data.Entities
{
    [Table("Book")]
    public class Book : IEntityBase
    {
        public Book()
        {
            Stocks = new List<Item>();
        }
        public int Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Author { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }
        public int TotalRaters { get; set; }
        public List<Item> Stocks { get; set; }
    }
}
