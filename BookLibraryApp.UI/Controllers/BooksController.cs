using BookLibraryApp.Core.IdentityEntities;
using BookLibraryApp.Core.ServicesInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BookLibraryApp.UI.Controllers
{
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Route("")]
        [Route("[action]")]
        [HttpGet]
        
        public async Task<IActionResult> Index(Guid libraryId)
        {
            var books = await _bookService.GetAllBooksByLibraryId(libraryId);

            return View(books);
        }

    }
}
