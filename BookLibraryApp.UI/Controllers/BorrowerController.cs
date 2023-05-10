using BookLibraryApp.Core.DTO;
using BookLibraryApp.Core.IdentityEntities;
using BookLibraryApp.Core.ServicesInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BookLibraryApp.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowerController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<BorrowerController> _logger;
        private readonly IBorrowerService _borrowerService;

        public BorrowerController(IBorrowerService borrowerService, UserManager<AppUser> userManager, ILogger<BorrowerController> logger)
        {
            _logger = logger;
            _userManager = userManager;
            _borrowerService = borrowerService;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> BorrowBook(BookDto bookDto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) _logger.LogError("cannot get current user");
            _logger.LogInformation("User successfully authenticated");
            _logger.LogInformation($"FromController bookId: {bookDto.BookId}");
            _logger.LogInformation($"FromController userId: {user.Id}");

            try
            {
                string result = await _borrowerService.BorrowBookFromLibrary(bookDto.BookId, user.Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> ReturnBook(BookDto bookDto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) _logger.LogError("cannot get current user");
            _logger.LogInformation("User successfully authenticated");
            try
            {
                string result = await _borrowerService.ReturnBookToLibrary(bookDto.BookId, user.Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

    }
}
