using System.ComponentModel.DataAnnotations;

namespace LACS_API.DTO { 
    public class UserEditRequestDTO
    {
        [Required(ErrorMessage = "User Id Required")]
        public string Id { get; set; }
        [Required(ErrorMessage = "DepartamentName Required")]
        public string DepartamentName { get; set; }
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "RoleId Required")]
        public int RoleId { get; set; }
    }
}
