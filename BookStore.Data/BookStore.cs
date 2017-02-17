using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BookStore.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public partial class BookStoreDB : IdentityDbContext<ApplicationUser>
    {
        public BookStoreDB()
            : base("name=BookStore2", throwIfV1Schema: false)
        {
        }
        public static BookStoreDB Create()
        {
            return new BookStoreDB();
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Item> Stocks { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
