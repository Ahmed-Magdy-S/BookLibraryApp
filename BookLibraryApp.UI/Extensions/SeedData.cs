using BookLibraryApp.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BookLibraryApp.UI.Extensions
{
    public static class SeedData
    {
        public static void EnsureDataSeeding(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Startup>>();

            try
            {
                ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                DataSeed.SeedData(dbContext);
                logger.LogInformation("DB has been seeded successfully");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Cannot make DB migrations");
            }
        }
    }
}
