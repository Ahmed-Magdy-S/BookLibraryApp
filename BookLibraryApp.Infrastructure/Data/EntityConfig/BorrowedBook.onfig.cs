using BookLibraryApp.Core.Entities;
using BookLibraryApp.Core.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibraryApp.Infrastructure.Data.EntityConfig
{
    public class BorrowedBookConfig : IEntityTypeConfiguration<BorrowedBook>
    {
        public void Configure(EntityTypeBuilder<BorrowedBook> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<Book>().WithMany().HasForeignKey(x => x.BookId).HasPrincipalKey(x=>x.Id).IsRequired();
            builder.HasOne<AppUser>().WithMany().HasForeignKey(x=>x.BorrowerId).HasPrincipalKey(x=>x.Id).IsRequired();
        }
    }
}
