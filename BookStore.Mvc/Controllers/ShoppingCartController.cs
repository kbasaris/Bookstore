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
        
        }
        HttpClient httpClient = new HttpClient();
        // GET: ShoppingCart
        public async Task<ActionResult> Index()
        {
            var token = Session["accesstoken"];
            var userId = Session["userid"];
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + Convert.ToString(token));
            var rslt = await httpClient.GetAsync(new Uri(string.Format("{0}userId={1}",Constants.GET_CART_URL,userId)));

            if (!rslt.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Error");
            }

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
            var token = Session["accesstoken"];
            var userId = Session["userid"];
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + Convert.ToString(token));
            var rslt = await httpClient.PostAsJsonAsync(new Uri($"{Constants.ADD_TO_CART_URL}{bookId}&userId={userId}"),Convert.ToString(bookId));

            if (!rslt.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Error");
            }

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
            var token = Session["accesstoken"];
            var userId = Session["userid"];
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + Convert.ToString(token));
            var rslt = await httpClient.PostAsJsonAsync(new Uri($"{Constants.REMOVE_FROM_CART_URL}{cartItemId}&userId={userId}"), Convert.ToString(cartItemId));

            if (!rslt.IsSuccessStatusCode)
            {
                return new JsonResult { Data = "Error" };
            }
            var cart = await rslt.Content.ReadAsAsync<RemoveFromCartDto>();

            return new JsonResult { Data = cart };
        }
    }
}