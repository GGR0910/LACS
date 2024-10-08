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
            Laboratory = new LaboratoryDTO(user.Laboratory);
            CreatedAt = user.CreatedAt;
            UpdatedAt = user.UpdatedAt;
            LastAcess = user.LastAcess;
        }



        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool Deleted { get; set; }
        public int RoleId { get; set; }
        public string DepartamentName { get; set; }
        public LaboratoryDTO Laboratory { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? LastAcess { get; set; }
    }
}
