using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BookStore.Api
{
    public class Bootstrapper
    {
        public static void Run()
        {
            // Configure Autofac
            AutofacConfig.Initialize(GlobalConfiguration.Configuration);
            //Configure AutoMapper
           // AutoMapperConfiguration.Configure();
        }
    }
}