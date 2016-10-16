﻿namespace BookStore.Mvc.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal? Price { get; set; }
        public int? Barcode { get; set; }
        public bool Reorder { get; set; }
        public int? ReorderAmount { get; set; }
        public int? NumOfStocks { get; set; }
    }
}