using System.ComponentModel.DataAnnotations;

namespace BookLibraryApp.Core.DTO
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Please provid username")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Please provid password")]
        public string? Password { get; set; }
    }
}
