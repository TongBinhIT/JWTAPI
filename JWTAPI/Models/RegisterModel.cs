using System.ComponentModel.DataAnnotations;

namespace JWTAPI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Full Name is required")]
        public string? Fullname { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}