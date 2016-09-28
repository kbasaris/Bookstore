using BookStore.Data.Entities;
using BookStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.Api.Controllers
{
   // [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private readonly IEntityBaseRepository<Book> _bookRepository;
        public BooksController(IEntityBaseRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
      //  [Route("books")]
        public IHttpActionResult GetBooks()
        {
            
            return Ok(_bookRepository.All);
        }
        [HttpPost]
        public IHttpActionResult GetBookById(int id)
        {
            return Ok(_bookRepository
                                    .All
                                    .SingleOrDefault(x => x.Id == id));
        }
    }
}
