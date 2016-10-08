using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Mvc.Helpers
{
    public class Helper
    {
        public static void IsAuthorized()
        {
            if (HttpContext.Current.Session["userId"] == null)
            {
                HttpContext.Current.Response.Redirect("/account/login");
            }
        }
    }
}