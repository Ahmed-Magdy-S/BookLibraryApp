using BookLibraryApp.Core.Entities;
using BookLibraryApp.Core.IdentityEntities;
using BookLibraryApp.Core.RepositoryInterfaces;
using BookLibraryApp.Core.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibraryApp.Infrastructure.Services
{
    public class BorrowedBookService : IBorrowedBookService
    {
        private readonly IBorrowedBookRepository _borrowedBookRepository;

        public BorrowedBookService (IBorrowedBookRepository borrowedBookRepository)
        {
            _borrowedBookRepository = borrowedBookRepository;
        }

        public async Task<IReadOnlyList<BorrowedBook>> GetAllBorrowedBooksByBookId(Guid bookId)
        {
            return await _borrowedBookRepository.GetAllBorrowedBooksByBookId(bookId);
        }
    }
}
