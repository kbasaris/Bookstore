using AutoMapper;
using BookStore.Api.Infrastracture.Extensions;
using BookStore.Api.Models;
using BookStore.Data.Entities;
using BookStore.Data.Infrastructure;
using BookStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.Api.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private readonly IEntityBaseRepository<Book> _bookRepository;
        protected readonly IUnitOfWork  _unitOfWork;
        public BooksController(IEntityBaseRepository<Book> bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }
        [Route("getbooks")]
        public IHttpActionResult GetBooks()
        {
            
            return Ok(_bookRepository.All);
        }
        [Route("getbyid")]
        public IHttpActionResult GetBookById(int id)
        {
            return Ok(_bookRepository
                                    .All
                                    .SingleOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add(BookViewModel bookVm)
        {
            if (ModelState.IsValid)
            {
                Book newBook = new Book();
                newBook.UpdateBook(bookVm);

                for (int i = 0; i < bookVm.NumOfStocks; i++)
                {
                    Stock stock = new Stock
                    {
                        Barcode = bookVm.Barcode,
                        ReorderAmount = bookVm.ReorderAmount,
                        Reorder = bookVm.Reorder,
                        Book = newBook
                    };
                }
                _bookRepository.Add(newBook);
                _unitOfWork.Commit();
                bookVm = Mapper.Map<BookViewModel>(newBook);
                return Ok(bookVm);
            }
            return BadRequest(ModelState);
        }
    }
}
