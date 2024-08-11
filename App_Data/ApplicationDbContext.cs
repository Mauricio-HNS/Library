using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<RentedBook> RentedBooks { get; set; }
        public DbSet<Category> Categories { get; set; } // Adicione DbSet para Categories, se necessário
    }
}
