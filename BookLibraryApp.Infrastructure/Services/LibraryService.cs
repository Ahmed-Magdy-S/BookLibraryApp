using BookLibraryApp.Core.Entities;
using BookLibraryApp.Core.RepositoryInterfaces;
using BookLibraryApp.Core.ServicesInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibraryApp.Infrastructure.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public async Task<IReadOnlyList<Library>> GetAllLibraries()
        {
            return await _libraryRepository.GetAllLibraries();
        }
    }
}
