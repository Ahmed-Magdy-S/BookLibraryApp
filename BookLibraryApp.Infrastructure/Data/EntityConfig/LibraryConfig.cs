using BookLibraryApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibraryApp.Infrastructure.Data.EntityConfig
{
    public class LibraryConfig : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();

            builder.HasMany<Book>().WithOne().HasForeignKey(x=>x.LibraryId).HasPrincipalKey(x=>x.Id).IsRequired();

        }
    }
}
