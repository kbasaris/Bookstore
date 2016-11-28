using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BookStore.Data.Entities;

namespace BookStore.Data
{
    public partial class BookStoreDB : DbContext
    {
        public BookStoreDB()
            : base("name=BookStore2")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Item> Stocks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
