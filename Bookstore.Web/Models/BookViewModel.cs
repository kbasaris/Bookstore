using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Web.Models
{
    public class BookViewModel
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        public int? Barcode { get; set; }

        public decimal? Price { get; set; }

        public bool? Reorder { get; set; }

        public int? ReeorderAmount { get; set; }

        public int NumberOfStocks { get; set; }
    }
}
