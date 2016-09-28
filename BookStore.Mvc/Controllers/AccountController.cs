﻿using BookStore.Mvc.Models;
using System.Net.Http;
using BookStore.Mvc.Helpers;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System;
using System.Web.Http;
using System.Web.Mvc;

namespace BookStore.Mvc.Controllers
{
   
    public class AccountController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            HttpClient httpClient = new HttpClient();
            var rslt = httpClient.PostAsJsonAsync(new Uri(Constants.LOGIN_URL), loginViewModel).Result;
            httpClient.Dispose();
            if(!rslt.IsSuccessStatusCode)
                return View();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Register(RegistrationViewModel loginViewModel)
        {
            HttpClient httpClient = new HttpClient();
            var rslt = httpClient.PostAsJsonAsync(new Uri(Constants.REGISTER_URL), loginViewModel).Result;
            var scess = rslt.IsSuccessStatusCode;
            httpClient.Dispose();
            if (!rslt.IsSuccessStatusCode)
                return View();

            return RedirectToAction("Index", "Home");
        }

    }
}
