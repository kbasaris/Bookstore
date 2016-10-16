using BookStore.Mvc.Helpers;
using BookStore.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Mvc.Controllers
{
    public class BooksController : Controller
    {
        HttpClient httpClient = new HttpClient();
        // GET: Books
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(BookViewModel bookVm)
        {
            if (ModelState.IsValid)
            {
                var rslt = await httpClient.PostAsJsonAsync(new Uri(Constants.ADD_BOOK_URL), bookVm);
                var book = await rslt.Content.ReadAsAsync<BookViewModel>();
                httpClient.Dispose();

                return View(book);
            }
            return View();
        }
    }
}