using System.ComponentModel.DataAnnotations;

namespace LACS_API.DTO
{
    public class EditUserDTORequest
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Range(1, 4)]
        public int RoleId { get; set; }
        [Required]
        public string DepartamentName { get; set; }
    }
}
