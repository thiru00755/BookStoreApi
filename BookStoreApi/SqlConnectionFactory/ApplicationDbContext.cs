using BookStoreApi.Model;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

namespace BookStoreApi.SqlConnectionFactory
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
    }
}

