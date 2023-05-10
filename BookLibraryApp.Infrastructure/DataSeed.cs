using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using BookLibraryApp.Core.Entities;

namespace BookLibraryApp.Infrastructure
{
    public static class DataSeed
    {
        private const string DATA_PATH = "../BookLibraryApp.Infrastructure/Data/SeedData";

        public static void SeedData(ApplicationDbContext dbContext)
        {

            if (!dbContext.Libraries.Any())
            {
                var json = File.ReadAllText($"{DATA_PATH}/libraries.json");
                var entities = JsonSerializer.Deserialize<List<Library>>(json);
                if (entities != null ) dbContext.Libraries.AddRange(entities);

            }
            if (!dbContext.Books.Any())
            {
                var json = File.ReadAllText($"{DATA_PATH}/books.json");
                var entities = JsonSerializer.Deserialize<List<Book>>(json);
                if (entities != null) dbContext.Books.AddRange(entities);

            }

            dbContext.SaveChanges();
        }

    }
}
