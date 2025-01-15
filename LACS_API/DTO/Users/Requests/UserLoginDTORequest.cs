using System.ComponentModel.DataAnnotations;

namespace LACS_API.DTO
{
    public class UserLoginDTORequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
