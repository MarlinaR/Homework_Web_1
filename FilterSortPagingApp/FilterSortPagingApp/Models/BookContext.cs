using Microsoft.EntityFrameworkCore;

namespace FilterSortPagingApp.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookKind> BookKinds { get; set; }
        public BookContext(DbContextOptions options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}