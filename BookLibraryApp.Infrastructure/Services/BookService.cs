using BookLibraryApp.Core.Entities;
using BookLibraryApp.Core.RepositoryInterfaces;
using BookLibraryApp.Core.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibraryApp.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IReadOnlyList<Book>> GetAllBooksByLibraryId(Guid libraryId)
        {
            return await _bookRepository.GetAllBooksByLibraryId(libraryId);
        }
    }
}
