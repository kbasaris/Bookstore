using BookStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Utilities.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public List<int>UserRoles { get; set; }
    }
}