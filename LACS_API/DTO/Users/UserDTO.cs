

namespace LACS_API.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
            
        }
        public UserDTO(string id, string userName, string email, bool isActive, int roleId, string departamentName)
        {
            Id = id;
            UserName = userName;
            Email = email;
            IsActive=isActive;
            RoleId=roleId;
            DepartamentName=departamentName;
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int? RoleId { get; set; }
        public string DepartamentName { get; set; }
    }
}
