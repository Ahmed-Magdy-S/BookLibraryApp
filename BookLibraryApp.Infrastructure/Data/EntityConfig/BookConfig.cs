using BookLibraryApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibraryApp.Infrastructure.Data.EntityConfig
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x=>x.Title).IsRequired();
            builder.Property(x=>x.Quantity).IsRequired().IsConcurrencyToken();

            builder.HasOne<Library>().WithMany().HasForeignKey(x=>x.LibraryId).HasPrincipalKey(x=>x.Id).IsRequired();
            builder.HasMany<BorrowedBook>().WithOne().HasForeignKey(x=>x.BookId).HasPrincipalKey(x=>x.Id).IsRequired();
        }
    }
}
