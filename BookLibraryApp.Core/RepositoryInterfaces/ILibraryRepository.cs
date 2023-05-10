using BookLibraryApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibraryApp.Core.RepositoryInterfaces
{
    public interface ILibraryRepository
    {
        Task<IReadOnlyList<Library>> GetAllLibraries();
    }
}
