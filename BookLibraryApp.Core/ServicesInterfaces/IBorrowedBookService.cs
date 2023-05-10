using BookLibraryApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using BookLibraryApp.Core.IdentityEntities;

namespace BookLibraryApp.Core.ServicesInterfaces
{
    public interface IBorrowedBookService
    {
        Task<IReadOnlyList<BorrowedBook>> GetAllBorrowedBooksByBookId(Guid bookId);
    }
}
