using BookLibraryApp.Core.ServicesInterfaces;
using BookLibraryApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibraryApp.UI.Extensions
{
    public static class AppServices
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<ILibraryService, LibraryService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBorrowedBookService, BorrowedBookService>();
            services.AddScoped<IBorrowerService, BorrowerService>();
        }
    }
}
