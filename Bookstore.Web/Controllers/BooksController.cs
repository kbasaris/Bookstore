using Bookstore.Web.Models;
using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bookstore.Web.Controllers
{
    [RoutePrefix("api/Books")]
    public class BooksController : ApiController
    {
        BookStore.Data.BookStoreDB context = new BookStore.Data.BookStoreDB();
       
        // GET: api/Books
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET: api/Books/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public HttpResponseMessage AddBook(HttpRequestMessage request, BookViewModel book)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                Book newBook = new Book();
                newBook.Author = book.Author;
                newBook.Title = book.Title;

                for (int i = 0; i < book.ReeorderAmount; i++)
                {
                    Stock stock = new Stock();
                    stock.Barcode = book.Barcode;
                    stock.Book = newBook;
                    stock.Price = book.Price;
                    stock.Reorder = book.Reorder;
                    stock.ReeorderAmount = book.ReeorderAmount;
                    newBook.Stocks.Add(stock);
                }

                context.Books.Add(newBook);
                context.SaveChanges();
                response = request.CreateResponse<BookViewModel>(HttpStatusCode.Created, book);
            }

            return response;
        }

        [Route("getbook/{id:int}")]
        public HttpResponseMessage GetBook(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            Book book = null;
            Stock stock = null;
            int count = 0;
            using (var newContext = new BookStore.Data.BookStoreDB())
            {
                try
                {
                    book = newContext.Books.Single(w => w.ID == id);

                    stock = newContext.Stocks.Where(w => w.BookID == book.ID).First();

                    count = newContext.Stocks.Count(w => w.BookID == book.ID);
                }
                catch(Exception ex) { }
                
            }

            BookViewModel bookVM = new BookViewModel();

            bookVM.ID = book.ID;
            bookVM.Author = book.Author;
            bookVM.Barcode = stock.Barcode;
            bookVM.NumberOfStocks = count;
            bookVM.Price = stock.Price;
            bookVM.Title = book.Title;
            
            response = response = request.CreateResponse<BookViewModel>(HttpStatusCode.Created, bookVM);

            return response;
        }

        [Route("updatebook")]
        [HttpPost]
        public HttpResponseMessage Update(HttpRequestMessage request, BookViewModel bookVM)
        {
            HttpResponseMessage response = null;
            Book editBook = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                using (var newContext = new BookStoreDB())
                {
                    editBook = newContext.Books.Single(w => w.ID == bookVM.ID);

                    editBook.Author = bookVM.Author;
                    editBook.Title = bookVM.Title;
                    foreach (Stock stock in editBook.Stocks)
                    {
                        stock.Barcode = bookVM.Barcode;
                        stock.BookID = bookVM.ID;
                        stock.Price = bookVM.Price;
                        stock.ReeorderAmount = bookVM.ReeorderAmount;
                        stock.Reorder = bookVM.Reorder;
                    }
                }
            }

            return response;
        }

        // DELETE: api/Books/5
        public void Delete(int id)
        {
        }
    }
}
