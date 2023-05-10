using BookLibraryApp.Core.Entities;
using BookLibraryApp.Core.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibraryApp.Infrastructure.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LibraryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Library>> GetAllLibraries()
        {
            return await _dbContext.Libraries.ToListAsync();
        }
    }
}
