using Domain.Entities;
using Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Contexts;

public class BookContext : DbContext
{
    public BookContext(){}

    public BookContext(DbContextOptions options) : base(options) { }

    public DbSet<BookEntity> Book {get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookMapping());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
}