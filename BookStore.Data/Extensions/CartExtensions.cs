using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookStore.Data.Extensions
{
    public static class CartExtensions
    {
        public const string CartSessionKey = "CartId";
        public static string GetCartId(string sessionKey)
        {
            string guid = sessionKey;
            if (string.IsNullOrEmpty(guid))
            {
                    Guid tempCartId = Guid.NewGuid();
                    guid = tempCartId.ToString();
            }
            return guid;
        }
    }
}
