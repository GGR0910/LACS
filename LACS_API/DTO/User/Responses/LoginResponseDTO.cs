namespace LACS_API.DTO.User.Responses
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public UserDTO UserInfo { get; set; }

        public LoginResponseDTO(string token, string userId, string userName, string userEmail)
        {
            Token = token;
            UserInfo = new UserDTO(userId, userName, userEmail, false);
        }
    }
}
