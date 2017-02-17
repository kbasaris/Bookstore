using BookStore.Utilities.Models;
using BookStore.Data.Entities;
using BookStore.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Api.Infrastracture.Extensions
{
    public static class EntitiesExtensions
    {
        public static void UpdateItem(this Item item, BookViewModel bookVm)
        {
            item.Book.Author = bookVm.Author;
            item.Book.Title = bookVm.Title;
            item.Book.Image = bookVm.ImageUrl;
            item.NumOfStocks = bookVm.NumOfStocks;
            item.Price = bookVm.Price;
            item.Reorder = bookVm.Reorder;
            item.ReorderAmount = bookVm.ReorderAmount;
        }

        public static void UpdateBook(this Book book, BookViewModel bookVm)
        {
            book.Author = bookVm.Author;
            book.Image = bookVm.ImageUrl;
            book.Title = bookVm.Title;
        }
    }
}