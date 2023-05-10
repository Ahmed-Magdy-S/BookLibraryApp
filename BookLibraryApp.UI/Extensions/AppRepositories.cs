using BookLibraryApp.Core.RepositoryInterfaces;
using BookLibraryApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibraryApp.UI.Extensions
{
    public static class AppRepositories
    {
        public static void AddAppRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBorrowedBookRepository, BorrowedBookRepository>();
            services.AddScoped<IBorrowerRepository, BorrowerRepository>();
        }
    }
}
