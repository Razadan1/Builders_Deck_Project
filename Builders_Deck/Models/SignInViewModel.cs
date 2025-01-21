using System.ComponentModel.DataAnnotations;

namespace Builders_Deck.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public required string Username { get; set; }
        [Required(ErrorMessage = "Input a password")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
