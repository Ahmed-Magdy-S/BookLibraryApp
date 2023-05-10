using System;
using System.Threading.Tasks;

namespace BookLibraryApp.Core.ServicesInterfaces
{
    public interface IBorrowerService
    {
        Task<string> BorrowBookFromLibrary(Guid bookId, Guid borrowerId);
        Task<string> ReturnBookToLibrary(Guid bookId, Guid borrowerId);
    }
}
