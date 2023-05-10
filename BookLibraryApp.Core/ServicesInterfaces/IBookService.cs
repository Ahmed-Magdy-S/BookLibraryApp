using BookLibraryApp.Core.Entities;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace BookLibraryApp.Core.ServicesInterfaces
{
    public interface IBookService
    {
        Task<IReadOnlyList<Book>> GetAllBooksByLibraryId(Guid libraryId);
    }
}
