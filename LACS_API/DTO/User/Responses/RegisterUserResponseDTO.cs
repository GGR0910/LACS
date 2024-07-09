using Domain.Entities;
using LACS_API.DTO.User;

namespace LACS_API.DTO
{
    public class RegisterUserResponseDTO
    {
        public RegisterUserResponseDTO(string userId, string email, string userName)
        {
            CreatedUserData = new UserDTO(userId,userName,email, false);
        }
        public UserDTO CreatedUserData { get; set; }
    }
}
