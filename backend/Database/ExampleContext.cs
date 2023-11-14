using ExampleBackend.Model;
using Microsoft.EntityFrameworkCore;

namespace ExampleBackend.Database;

public class ExampleContext : DbContext
{
    public ExampleContext(DbContextOptions<ExampleContext> options) : base(options) {  }

    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().Property(book => book.Id).ValueGeneratedOnAdd();
    }
}