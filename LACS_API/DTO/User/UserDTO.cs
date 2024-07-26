namespace LACS_API.DTO.User
{
    public class UserDTO
    {
        public UserDTO(string id, string userName, string email, bool isActive, int roleId)
        {
            Id = id;
            UserName = userName;
            Email = email;
            IsActive=isActive;
            RoleId=roleId;
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
    }
}
