﻿using BookStore.Utilities.Models;
using System.Net.Http;
using System;
using System.Web.Mvc;
using BookStore.Utilities;

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
            var rslt = httpClient.PostAsJsonAsync(new Uri(Constants.LOGIN_URL), loginViewModel).Result;
            ViewBag.loginRslt = rslt.IsSuccessStatusCode;
            if (!rslt.IsSuccessStatusCode)
                return View();

            var userInfo = rslt.Content.ReadAsAsync<UserInfo>().Result;

            Session.Add("userId", userInfo.UserId);
            Session.Add("username", userInfo.Username);


            foreach (var item in userInfo.UserRoles)
            {
                int i = 1;
                Session.Add("userRole"+i++, userInfo.UserId);
            }
            httpClient.Dispose();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Register(RegistrationViewModel loginViewModel)
        {
            var rslt = httpClient.PostAsJsonAsync(new Uri(Constants.REGISTER_URL), loginViewModel).Result;
            ViewBag.loginRslt = rslt.IsSuccessStatusCode;
            if (!rslt.IsSuccessStatusCode)
                return View();

            var userInfo = rslt.Content.ReadAsAsync<UserInfo>().Result;

            Session.Add("userId", userInfo.UserId);
            Session.Add("username", userInfo.Username);


            foreach (var item in userInfo.UserRoles)
            {
                int i = 1;
                Session.Add("userRole" + i++, userInfo.UserId);
            }
            httpClient.Dispose();
           

            return RedirectToAction("Index", "Home");
        }

    }
}
