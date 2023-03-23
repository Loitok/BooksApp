using BooksApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }

    }
}
