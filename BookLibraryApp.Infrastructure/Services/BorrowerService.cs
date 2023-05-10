using BookLibraryApp.Core.RepositoryInterfaces;
using BookLibraryApp.Core.ServicesInterfaces;
using System;
using System.Threading.Tasks;

namespace BookLibraryApp.Infrastructure.Services
{
    public class BorrowerService : IBorrowerService
    {
        private readonly IBorrowerRepository _borrowerRepository;

        public BorrowerService (IBorrowerRepository borrowerRepository)
        {
            _borrowerRepository = borrowerRepository;
        }

        public async Task<string> BorrowBookFromLibrary(Guid bookId, Guid borrowerId)
        {
            return await _borrowerRepository.BorrowBookFromLibrary(bookId, borrowerId);
        }

        public async Task<string> ReturnBookToLibrary(Guid bookId, Guid borrowerId)
        {
            return await _borrowerRepository.ReturnBookToLibrary(bookId, borrowerId);
        }
    }
}
