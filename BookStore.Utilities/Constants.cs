using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Utilities
{
    public static class Constants
    {
        public const string LOGIN_URL = "http://localhost:50057/api/account/authenticate";
        public const string REGISTER_URL = "http://localhost:50057/api/account/register";
        public const string ADD_BOOK_URL = "http://localhost:50057/api/books/add";
        public const string GET_BOOK_URL = "http://localhost:50057/api/books/getbooks";
        public const string GET_BOOK_BY_ID_URL = "http://localhost:50057/api/books/getbyid?";
        public const string EDIT_BOOK = "http://localhost:50057/api/books/edit";
        public const string DELETE_BOOK = "http://localhost:50057/api/books/delete?";
        public const string GET_CART_URL = "http://localhost:50057/api/cart/getcart?";
        public const string ADD_TO_CART_URL = "http://localhost:50057/api/cart/addtocart?itemId=";
        public const string CART_SESSION_KEY = "CartId";
    }
}