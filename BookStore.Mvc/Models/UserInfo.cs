using System.Collections.Generic;

namespace BookStore.Mvc.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public List<int>UserRoles { get; set; }
    }
}