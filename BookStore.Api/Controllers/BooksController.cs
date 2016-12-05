using AutoMapper;
using BookStore.Api.Infrastracture;
using BookStore.Api.Mappings;
using BookStore.Utilities.Models;
using BookStore.Data.Entities;
using BookStore.Data.Infrastructure;
using BookStore.Data.Repositories;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using BookStore.Api.Infrastracture.Extensions;

namespace BookStore.Api.Controllers
{
    [RoutePrefix("api/books")]
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
            var bookVm = _customMappings.MapToIEnumerableOfBookVm(_itemRepository.All);
            return Ok(bookVm);
        }
        [Route("getbyid")]
        public IHttpActionResult GetBookById(int id)
        {
            var item = _itemRepository.All.SingleOrDefault(x => x.Id == id);
            var bookVm = _customMappings.MapTobookVm(item);
            return Ok(bookVm);
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add(BookViewModel itemVm)
        {
            if (ModelState.IsValid)
            {
                var item = _customMappings.MapToItem(itemVm);
                Book newBook = item.Book;
                string pathForUpload =Path.Combine(System.Web.HttpContext.Current.Server.MapPath(Constants.UPLOAD_PATH), itemVm.ImageName);
                newBook.Image = pathForUpload;
                File.WriteAllBytes(pathForUpload, itemVm.Image);
                _itemRepository.Add(item);
                _unitOfWork.Commit();

                return Ok(itemVm);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("edit")]
        public IHttpActionResult Edit(BookViewModel bookVm)
        {
            if (ModelState.IsValid)
            {
                var item = _itemRepository.GetSingle(bookVm.Id);
                item.UpdateItem(bookVm);
                _itemRepository.Edit(item);
                var newBookVm = _customMappings.MapTobookVm(item);
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
