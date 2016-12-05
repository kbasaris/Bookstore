using BookStore.Utilities.Models;
using BookStore.Data.Entities;
using BookStore.Utilities.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

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
        public BookViewModel MapTobookVm(Item item)
        {
            BookViewModel bookVm = new BookViewModel();
            bookVm.Author = item.Book.Author;
            bookVm.Title = item.Book.Title;
            bookVm.ImageUrl= item.Book.Image;
            bookVm.BookId = item.Book.Id;
            bookVm.Id = item.Id;
            bookVm.NumOfStocks = item.NumOfStocks;
            bookVm.Price = item.Price;
            bookVm.Reorder = item.Reorder;
            bookVm.ReorderAmount = item.ReorderAmount;

            return bookVm;
        }
        public IEnumerable<BookViewModel> MapToIEnumerableOfBookVm(IEnumerable<Item> items)
        {
            List<BookViewModel> newBookVms = new List<BookViewModel>();
            foreach (var item in items)
            {
                BookViewModel bookVm = new BookViewModel();
                bookVm.Author = item.Book.Author;
                bookVm.Title = item.Book.Title;
                bookVm.ImageUrl = item.Book.Image;
                bookVm.BookId = item.Book.Id;
                bookVm.Id = item.Id;
                bookVm.ImageName = !string.IsNullOrEmpty(item.Book.Image) ? Path.GetFileName(item.Book.Image) : "";
                bookVm.Image = GetImageInBytes(item.Book.Image);
                bookVm.NumOfStocks = item.NumOfStocks;
                bookVm.Price = item.Price;
                bookVm.Reorder = item.Reorder;
                bookVm.ReorderAmount = item.ReorderAmount;
                newBookVms.Add(bookVm);
            }

            return newBookVms;
        }
        public byte[] GetImageInBytes(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
               return File.ReadAllBytes(path);
            }
            return null;
        }
    }
}