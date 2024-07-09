namespace LACS_API.DTO.User
{
    public class UserDTO
    {
        public UserDTO(string id, string userName, string email, bool isActive)
        {
            Id = id;
            UserName = userName;
            Email = email;
            IsActive=isActive;
        }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
