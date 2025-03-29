using InventarioWepExterna.Models;
using Microsoft.EntityFrameworkCore;
namespace InventarioWepExterna.Server.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
