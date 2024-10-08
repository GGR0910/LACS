﻿using System.ComponentModel.DataAnnotations;

namespace LACS_API.DTO
{
    public class RegisterUserRequestDTO : BaseRequestDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Range(1, 4, ErrorMessage = "Invalid RoleId")]
        public int RoleId { get; set; }
        [Required]
        public string DepartamentName { get; set; }
    }
}
