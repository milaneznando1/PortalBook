using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping;

public class BookMapping : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.ToTable("Book");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("ID_BOOK");
        builder.Property(u => u.BookName).HasColumnName("BOOK_NAME");
        builder.Property(u => u.BookAuthor).HasColumnName("BOOK_AUTHOR");
        builder.Property(u => u.BookResume).HasColumnName("BOOK_RESUME");
        builder.Property(u => u.PublicationDate).HasColumnName("PUBLICATION_DATE");
    }
}