using BookLibraryApp.Core.Entities;
using BookLibraryApp.Core.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookLibraryApp.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole,Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }
    }
}
