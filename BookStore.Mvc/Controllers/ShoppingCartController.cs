using BookStore.Data.Entities;
using BookStore.Mvc.Helpers;
using BookStore.Utilities;
using BookStore.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Mvc.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ShoppingCartController()
        {
            Helper.IsAuthorized();
        }
        HttpClient httpClient = new HttpClient();
        // GET: ShoppingCart
        public async Task<ActionResult> Index()
        {
            var rslt = await httpClient.GetAsync(new Uri(Constants.GET_CART_URL));
            var cart = await rslt.Content.ReadAsAsync<ShoppingCartListDto>();
            HttpCookie aCookie = Response.Cookies.Get("cart");
            
            if (aCookie != null)
            {
                aCookie.Values["CartItems"] = Convert.ToString(cart.Count);
            }
            else
            {
                aCookie = new HttpCookie("cart");
                aCookie.Values["CartItems"] = Convert.ToString(cart.Count);
            }
            return View(cart);
        }

        public async Task<ActionResult> AddToCart(int bookId)
        {
            var rslt = await httpClient.PostAsJsonAsync(new Uri($"{Constants.ADD_TO_CART_URL}{bookId}"),Convert.ToString(bookId));
            var cart = await rslt.Content.ReadAsAsync<ShoppingCartListDto>();

           HttpCookie aCookie = Response.Cookies.Get("cart");
           if (aCookie != null)
            {
                aCookie.Values["CartItems"] = Convert.ToString(cart.Count);
            }
            else
            {
                aCookie = new HttpCookie("cart");
                aCookie.Values["CartItems"] = Convert.ToString(cart.Count);
            }
           
            return RedirectToAction("Home","Books");
        }

        public async Task<JsonResult> RemoveFromCart(int cartItemId)
        {
            var rslt = await httpClient.PostAsJsonAsync(new Uri($"{Constants.REMOVE_FROM_CART_URL}{cartItemId}"), Convert.ToString(cartItemId));
            var cart = await rslt.Content.ReadAsAsync<RemoveFromCartDto>();

            return new JsonResult { Data = cart };
        }
    }
}