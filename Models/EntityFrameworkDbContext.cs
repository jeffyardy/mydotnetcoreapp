using Microsoft.EntityFrameworkCore;
namespace MyDotNewCoreApp.Models
{
    public class EntityFrameworkDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=BLR-AA201433;Database=CRUD;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}