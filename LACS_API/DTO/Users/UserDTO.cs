﻿

using Domain.Entities;

namespace LACS_API.DTO
{
    public class UserDTO
    {
        public UserDTO(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Deleted= user.Deleted;
            RoleId=user.RoleId;
            DepartamentName=user.DepartamentName;
        }



        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool Deleted { get; set; }
        public int? RoleId { get; set; }
        public string DepartamentName { get; set; }
    }
}
