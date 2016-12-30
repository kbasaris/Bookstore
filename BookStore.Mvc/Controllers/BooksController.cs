﻿using BookStore.Mvc.Helpers;
using BookStore.Utilities;
using BookStore.Utilities.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BookStore.Mvc.Controllers
{
    public class BooksController : Controller
    {
        HttpClient httpClient = new HttpClient();
        // GET: Books
        public async Task<ActionResult> Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;
            var rslt = await httpClient.GetAsync(new Uri(Constants.GET_BOOK_URL));
            var books = await rslt.Content.ReadAsAsync<IEnumerable<BookViewModel>>();
            var pagedListBook = books.ToPagedList(pageNumber, pageSize);
            foreach (var book in books)
            {
                book.ImageBase64 = book.Image != null? @Convert.ToBase64String(book.Image) : "";
            }
           
            return View(pagedListBook);
        }

        public async Task<ActionResult> Home(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;
            var rslt = await httpClient.GetAsync(new Uri(Constants.GET_BOOK_URL));
            var books = await rslt.Content.ReadAsAsync<IEnumerable<BookViewModel>>();
            var pagedListBook = books.ToPagedList(pageNumber, pageSize);
            foreach (var book in books)
            {
                book.ImageBase64 = book.Image != null ? @Convert.ToBase64String(book.Image) : "";
            }

            return View(pagedListBook);
        }
        [HttpPost]
        public async Task<JsonResult> SendRating(RateViewModel rateVm)
        { 

            var rslt = await httpClient.GetAsync(new Uri($"{Constants.GET_BOOK_BY_ID_URL}id={rateVm.BookId}"));
            var book = await rslt.Content.ReadAsAsync<BookViewModel>();

            HttpCookie cookie = new HttpCookie(Convert.ToString(book.BookId), "true");
            Response.Cookies.Add(cookie);

            return new JsonResult();
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(BookViewModel bookVm,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream target = new MemoryStream();
                    file.InputStream.CopyTo(target);
                    bookVm.Image = target.ToArray();
                    bookVm.ImageName = file.FileName;
                }
                var rslt = await httpClient.PostAsJsonAsync(new Uri(Constants.ADD_BOOK_URL), bookVm);
                var book = await rslt.Content.ReadAsAsync<BookViewModel>();
                httpClient.Dispose();

                return View(book);
            }
            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var rslt = await httpClient.GetAsync(new Uri($"{Constants.GET_BOOK_BY_ID_URL}id={id}"));
            var book = await rslt.Content.ReadAsAsync<BookViewModel>();
            if (book.Image != null)
            {
                book.ImageBase64 = @Convert.ToBase64String(book.Image);
            }
            return View(book);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(BookViewModel bookVm,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream target = new MemoryStream();
                    file.InputStream.CopyTo(target);
                    bookVm.Image = target.ToArray();
                    bookVm.ImageName = file.FileName;
                }

                var rslt = await httpClient.PostAsJsonAsync(new Uri(Constants.EDIT_BOOK), bookVm);
                var newBookVm = await rslt.Content.ReadAsAsync<BookViewModel>();
                httpClient.Dispose();

                return RedirectToAction("Index", "Books");
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var rslt = await httpClient.DeleteAsync(new Uri($"{Constants.DELETE_BOOK}id={id}"));
            var newBookVm = await rslt.Content.ReadAsAsync<BookViewModel>();
            httpClient.Dispose();

            return RedirectToAction("Index","Books");
        }

        [HttpPost]
        public async Task<JsonResult> ShowImage(byte[] imageData)
        {
            return new JsonResult { Data = imageData };
        }

    }
}