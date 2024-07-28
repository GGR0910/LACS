using Domain.Entities;
using LACS_API.DTO.User;

namespace LACS_API.DTO
{
    public class RegisterUserResponseDTO
    {
        public RegisterUserResponseDTO(string userId, string email, string userName, int roleId, string departamentName)
        {
            CreatedUserData = new UserDTO(userId,userName,email, false, roleId, departamentName);
        }
        public UserDTO CreatedUserData { get; set; }
    }
}
