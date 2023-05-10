using BookLibraryApp.Core.Entities;
using BookLibraryApp.Core.IdentityEntities;
using BookLibraryApp.Core.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApp.Infrastructure.Repositories
{
    public class BorrowedBookRepository  : IBorrowedBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BorrowedBookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<BorrowedBook>> GetAllBorrowedBooksByBookId(Guid bookId)
        {
            return await _dbContext.BorrowedBooks.Where(x=>x.BookId == bookId).ToListAsync();
        }
    }
}
