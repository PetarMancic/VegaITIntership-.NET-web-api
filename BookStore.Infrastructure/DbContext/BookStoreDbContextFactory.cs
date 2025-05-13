using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookStore.Infrastructure.DbContext
{
    internal class BookStoreDbContextFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
    {
        public BookStoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookStoreDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BookStoreDB;Username=postgres;Password=Praktikant123!");

            return new BookStoreDbContext(optionsBuilder.Options);
        }
    }
}
