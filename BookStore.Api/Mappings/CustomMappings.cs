using BookStore.Utilities.Models;
using BookStore.Data.Entities;
using BookStore.Utilities.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using BookStore.Api.Infrastracture.Extensions;

namespace BookStore.Api.Mappings
{
    public class CustomMappings
    {
        public Item MapToItem(BookViewModel bookVm)
        {
            Item item = new Item();
            item.Book = new Book();
            item.Book.Author = bookVm.Author;
            item.Book.Title = bookVm.Title;
            item.Book.Image = bookVm.ImageUrl;
            item.NumOfStocks = bookVm.NumOfStocks;
            item.Price = bookVm.Price;
            item.Reorder = bookVm.Reorder;
            item.ReorderAmount = bookVm.ReorderAmount;

            return item;
        }
        public BookViewModel MapTobookVm(Book book)
        {
            BookViewModel bookVm = new BookViewModel();
            bookVm.Author = book.Author;
            bookVm.Title = book.Title;
            bookVm.ImageUrl= book.Image;
            bookVm.Image = string.IsNullOrEmpty(book.Image) ? null : File.ReadAllBytes(book.Image);
            bookVm.BookId = book.Id;
            bookVm.Stocks = book.Stocks;
            bookVm.NumOfStocks = book.Stocks.Count();
            bookVm.Price = book.Stocks.Select(x => x.Price).FirstOrDefault();
            bookVm.Reorder = book.Stocks.Select(x => x.Reorder).FirstOrDefault();
            bookVm.ReorderAmount = book.Stocks.Select(x => x.ReorderAmount).FirstOrDefault();

            return bookVm;
        }
        public IEnumerable<BookViewModel> MapToIEnumerableOfBookVm(IEnumerable<Book> books)
        {
            List<BookViewModel> newBookVms = new List<BookViewModel>();
            foreach (var book in books)
            {
                BookViewModel bookVm = new BookViewModel();
                bookVm.Author = book.Author;
                bookVm.Title = book.Title;
                bookVm.ImageUrl = book.Image;
                bookVm.BookId = book.Id;
                bookVm.ImageName = !string.IsNullOrEmpty(book.Image) ? Path.GetFileName(book.Image) : "";
                bookVm.Image = string.IsNullOrEmpty(book.Image) ? null : File.ReadAllBytes(book.Image);
                bookVm.NumOfStocks = book.Stocks.Count();
                bookVm.Stocks = book.Stocks;
                bookVm.Price = book.Stocks.Select(x => x.Price).FirstOrDefault();
                bookVm.Reorder = book.Stocks.Select(x => x.Reorder).FirstOrDefault();
                bookVm.ReorderAmount = book.Stocks.Select(x => x.ReorderAmount).FirstOrDefault();
                newBookVms.Add(bookVm);
            }

            return newBookVms;
        }


    }
}