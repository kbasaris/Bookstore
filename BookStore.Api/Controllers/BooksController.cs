using BookStore.Api.Infrastracture;
using BookStore.Api.Mappings;
using BookStore.Utilities.Models;
using BookStore.Data.Entities;
using BookStore.Data.Infrastructure;
using BookStore.Data.Repositories;
using System.IO;
using System.Linq;
using System.Web.Http;
using BookStore.Api.Infrastracture.Extensions;
using System;

namespace BookStore.Api.Controllers
{
    [RoutePrefix("api/books")]
    [Authorize]
    public class BooksController : ApiController
    {
        private CustomMappings _customMappings = new CustomMappings();
        private readonly IEntityBaseRepository<Book> _bookRepository;
        private readonly IEntityBaseRepository<Item> _itemRepository;
        protected readonly IUnitOfWork  _unitOfWork;
        

        public BooksController(IEntityBaseRepository<Book> bookRepository, IEntityBaseRepository<Item> itemRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }
        [Route("getbooks")]
        public IHttpActionResult GetBooks()
        {

            var bookVm = _customMappings.MapToIEnumerableOfBookVm(_bookRepository.All);
            return Ok(bookVm);
        }
        [Route("getbyid")]
        public IHttpActionResult GetBookById(int id)
        {
            var book = _bookRepository.All.SingleOrDefault(x => x.Id == id);
            var bookVm = _customMappings.MapTobookVm(book);
            return Ok(bookVm);
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add(BookViewModel bookVm)
        {
            if (ModelState.IsValid)
            {
                var item = _customMappings.MapToItem(bookVm);
                Book newBook = item.Book;
                string pathForUpload =Path.Combine(System.Web.HttpContext.Current.Server.MapPath(Constants.UPLOAD_PATH), bookVm.ImageName);
                newBook.Image = pathForUpload;
                File.WriteAllBytes(pathForUpload, Convert.FromBase64String(bookVm.ImageBase64));

                for (var i = 0; i<= bookVm.NumOfStocks;i++)
                {
                    var newItem = new Item {
                        Book = newBook,
                        BookID = newBook.Id,
                        NumOfStocks = bookVm.NumOfStocks,
                        Price = bookVm.Price,
                        Reorder = bookVm.Reorder,
                        ReorderAmount = bookVm.ReorderAmount };

                    newBook.Stocks.Add(newItem);
                }
                _bookRepository.Add(newBook);


                _unitOfWork.Commit();

                return Ok(bookVm);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("edit")]
        public IHttpActionResult Edit(BookViewModel bookVm)
        {
            if (ModelState.IsValid)
            {
                var book = _bookRepository.GetSingle(bookVm.BookId);
                string pathForUpload = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(Constants.UPLOAD_PATH), bookVm.ImageName);
                bookVm.ImageUrl = pathForUpload;
                File.WriteAllBytes(pathForUpload, Convert.FromBase64String(bookVm.ImageBase64));
                book.UpdateBook(bookVm);
                _bookRepository.Edit(book);


                var newBookVm = _customMappings.MapTobookVm(book);

                newBookVm.Image = string.IsNullOrEmpty(bookVm.ImageUrl) ? null : File.ReadAllBytes(bookVm.ImageUrl);
                _unitOfWork.Commit();
                return Ok(newBookVm);
            }
            return BadRequest(ModelState);
        }


        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var item = _itemRepository.GetSingle(id);
                _itemRepository.Delete(item);
                _unitOfWork.Commit();
                return Ok();
            }
            return BadRequest(ModelState);
        }

    }
}
