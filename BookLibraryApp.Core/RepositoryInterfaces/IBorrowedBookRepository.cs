using BookLibraryApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibraryApp.Core.RepositoryInterfaces
{
    public interface IBorrowedBookRepository
    {
        Task<IReadOnlyList<BorrowedBook>> GetAllBorrowedBooksByBookId(Guid bookId);
    }
}
