using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Utilities.Models
{
    public class BookViewModel 
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        [Required(ErrorMessage = "You have to provide a Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "You have to provide a Author")]
        public string Author { get; set; }
        [Required(ErrorMessage = "You have to provide a Price")]
        public decimal? Price { get; set; }
        public bool Reorder { get; set; }
        public int? ReorderAmount { get; set; }
        public int? NumOfStocks { get; set; }
        public byte[] Image { get; set; }
        public string ImageUrl { get; set; }
        public string ImageBase64 { get; set; }
        public string ImageName { get; set; }
       
    }
}