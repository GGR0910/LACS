using Domain.Entities;

namespace LACS_API.DTO
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public UserDTO UserInfo { get; set; }

        public LoginResponseDTO(string token, User user)
        {
            Token = token;
            UserInfo = new UserDTO(user);
        }
    }
}
