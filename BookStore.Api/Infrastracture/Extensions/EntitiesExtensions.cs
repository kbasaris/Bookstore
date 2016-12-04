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
        public static void UpdateBook(this Book book, BookViewModel bookVm)
        {
            book.Title = bookVm.Title;
            book.Author = bookVm.Author;
            //book.Price = bookVm.Price;
            //book.NumOfStocks = bookVm.NumOfStocks;
        }
    }
}