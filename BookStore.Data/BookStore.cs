namespace BookStore.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookStoreDB : DbContext
    {
        public BookStoreDB()
            : base("name=BookStore2")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
