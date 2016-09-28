using BookStore.Authentication.Utilities;
using System.Collections.Generic;
using BookStore.Data.Entities;

namespace BookStore.Authentication
{
    public interface IMembershipService
    {
        MembershipContext ValidateUser(string username, string password);
        User CreateUser(string username, string email, string password, int[] roles);
        User GetUser(int userId);
        List<Role> GetUserRoles(string username);
    }
}
