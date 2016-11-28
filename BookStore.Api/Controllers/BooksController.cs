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
        private readonly IEntityBaseRepository<Item> _itemRepository;
        protected readonly IUnitOfWork  _unitOfWork;
        

        public BooksController(IEntityBaseRepository<Book> bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }
        [Route("getbooks")]
        public IHttpActionResult GetBooks()
        {
            var bookVm = Mapper.Map<IEnumerable<Item>, IEnumerable<BookViewModel>>(_itemRepository.All);
            return Ok(bookVm);
        }
        [Route("getbyid")]
        public IHttpActionResult GetBookById(int id)
        {
            var book = _bookRepository.All.SingleOrDefault(x => x.Id == id);
            var bookVm = Mapper.Map<Book,BookViewModel>(book);
            return Ok(bookVm);
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add(BookViewModel bookVm)
        {
            if (ModelState.IsValid)
            {
                Book newBook = new Book();
                newBook.UpdateBook(bookVm);
                ;
                Item stock = new Item
                    {
                        BookID = bookVm.Id,
                        ReorderAmount = bookVm.ReorderAmount,
                        Reorder = bookVm.Reorder,
                        Book = newBook,
                        Price = bookVm.Price,
                        NumOfStocks = bookVm.NumOfStocks
                    };
                _bookRepository.Add(newBook);
                
                _unitOfWork.Commit();
                
                bookVm = Mapper.Map<BookViewModel>(newBook);
                return Ok(bookVm);
            }
            return BadRequest(ModelState);
        }
    }
}
