using BookLibraryApp.Core.Entities;
using BookLibraryApp.Core.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApp.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Book>> GetAllBooksByLibraryId(Guid libraryId)
        {
            return await _dbContext.Books.Where(x => x.LibraryId == libraryId).ToListAsync();
        }



    }
}
