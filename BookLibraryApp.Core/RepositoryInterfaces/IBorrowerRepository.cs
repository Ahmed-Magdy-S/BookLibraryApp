using BookLibraryApp.Core.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibraryApp.Core.RepositoryInterfaces
{
    public interface IBorrowerRepository
    {
        Task<IReadOnlyList<AppUser>> GetAllBorrowersByBookId(Guid bookId);
        Task<string> BorrowBookFromLibrary(Guid bookId, Guid borrowerId);
        Task<string> ReturnBookToLibrary(Guid bookId, Guid borrowerId);

    }
}
