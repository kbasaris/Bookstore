using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Mvc.Helpers
{
    public static class Constants
    {
        public const string LOGIN_URL = "http://localhost:50057/api/account/authenticate";
        public const string REGISTER_URL = "http://localhost:50057/api/account/register";
        public const string ADD_BOOK_URL = "http://localhost:50057/api/books/add";
        public const string GET_BOOK_URL = "http://localhost:50057/api/books/getbooks";
        public const string GET_BOOK_BY_ID_URL = "http://localhost:50057/api/books/getbyid?";
    }
}