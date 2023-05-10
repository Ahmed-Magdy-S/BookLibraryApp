using BookLibraryApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibraryApp.Core.ServicesInterfaces
{
    public interface ILibraryService
    {
        Task<IReadOnlyList<Library>> GetAllLibraries();
    }
}
