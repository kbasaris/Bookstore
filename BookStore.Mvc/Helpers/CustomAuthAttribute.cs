﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace BookStore.Mvc.Helpers
{
    public class CustomAuthAttribute : AuthorizeAttribute
    {
    
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(HttpContext.Current.Session["userId"].Equals(null)){

            }
        }
    }
}