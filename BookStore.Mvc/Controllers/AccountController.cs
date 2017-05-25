using BookStore.Utilities.Models;
using System.Net.Http;
using System;
using System.Web.Mvc;
using BookStore.Utilities;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Web;

namespace BookStore.Mvc.Controllers
{

    public class AccountController : Controller
    {
        HttpClient httpClient = new HttpClient();

        public ActionResult Login()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", loginViewModel.Username),
                new KeyValuePair<string, string>("password", loginViewModel.Password)
            });
            //grant_type=password&username=k.basharis@gmail.com&password=Abc@123
            var rslt = httpClient.PostAsync(new Uri(Constants.LOGIN_URL), formContent).Result;
            ViewBag.loginRslt = rslt.IsSuccessStatusCode;
            if (!rslt.IsSuccessStatusCode)
                return View();

            var userInfo = rslt.Content.ReadAsStringAsync().Result;
            JToken token = JObject.Parse(userInfo);
            string accessToken = Convert.ToString(token.SelectToken("access_token"));
            string username = Convert.ToString(token.SelectToken("userName"));
            string roles = Convert.ToString(token.SelectToken("roles"));
            string userId = Convert.ToString(token.SelectToken("userid"));

            HttpCookie aCookie = new HttpCookie("creds");

            aCookie.Values["roles"] = roles;
            aCookie.Values["userid"] = userId;
            aCookie.Values["username"] = username;
            aCookie.Values["accessToken"] = accessToken;
            HttpContext.Response.Cookies.Add(aCookie);

            httpClient.Dispose();

            if (Convert.ToInt32(roles) ==1)
            {
                return RedirectToAction("Index", "Books");
            }
            return RedirectToAction("Home", "Books");

        }

        public ActionResult Register()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Register(RegisterBindingModel loginViewModel)
        {
            var rslt = httpClient.PostAsJsonAsync(new Uri(Constants.REGISTER_URL), loginViewModel).Result;
            ViewBag.loginRslt = rslt.IsSuccessStatusCode;
            if (!rslt.IsSuccessStatusCode)
                return View();

            httpClient.Dispose();

            return RedirectToAction("Login", "Account");
        }

    }
}
