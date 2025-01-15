using System.ComponentModel.DataAnnotations;

namespace LACS_API.DTO
{
    public class RegisterUserDTORequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(1, 3)]
        public int RoleId { get; set; }
        [Required]
        [StringLength(14, MinimumLength = 11)]
        public string UserDocument { get; set; }
        public string? DepartamentName { get; set; }
    }
}
