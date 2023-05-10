using BookLibraryApp.Core.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookLibraryApp.UI.Controllers
{
    [Route("/")]
    [Route("[controller]")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILibraryService _libraryService;
        public HomeController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public async Task<IActionResult>  Index()
        {
            var libraries = await _libraryService.GetAllLibraries();

            return View(libraries);
        }
    }
}
