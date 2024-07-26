using Data.Interface;
using Domain;
using Domain.Entities;
using LACS_API.DTO;
using LACS_API.DTO.User;
using LACS_API.DTO.User.Requests;
using LACS_API.DTO.User.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LACS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IConfiguration configuration) : base(configuration)
        {
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("UserLogin")]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequest)
        {
            Result<Dictionary<string,User>> result = new Result<Dictionary<string, User>>();

            if(!ModelState.IsValid)
                return BadRequest(new { message = "Invalid login request. Please check your email and password." });

            result = await _application.User.UserLogin(loginRequest.Email, loginRequest.Password);
            User user =  result.Return.First().Value;

            if (result.Success)
                return Ok(new LoginResponseDTO(result.Return.First().Key, user.Id, user.UserName, user.Email, user.RoleId));
            else
                return BadRequest(new { message = result.Message });
            
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterUserRequestDTO registerRequest)
        {
            Result<User> result = new Result<User>();

            if(!ModelState.IsValid)
                return BadRequest(new { message = "Invalid register request. Please check the data." });

            result = await _application.User.RegisterUser(registerRequest.UserName, registerRequest.Email, registerRequest.Password, registerRequest.LoggedUserId, registerRequest.RoleId);
            User user = result.Return;

            if(result.Success)
                return Ok(new RegisterUserResponseDTO(user.Id, user.Email, user.UserName, user.RoleId));
            else
                return BadRequest(new { message = result.Message });
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            IEnumerable<User> users = await _application.User.GetUsers();

            List<UserDTO> usersDto = new List<UserDTO>();
            foreach (var user in users)
            {
                usersDto.Add(new UserDTO(user.Id, user.UserName, user.Email, user.Deleted, user.RoleId));   
            }

            if (users.Any())
                return Ok(usersDto);
            else
                return NotFound(new { message = "No users found." });
        }
        
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string userId, string creatorId)
        {
            Result<User> result = new Result<User>();

            if(string.IsNullOrEmpty(userId))
                return BadRequest(new { message = "Invalid user id." });

            result = await _application.User.DeleteUser(userId, creatorId);
            User user = result.Return;

            if(result.Success)
                return Ok();
            else
                return BadRequest(new { message = result.Message });
        }

        [HttpGet]
        [Route("GetUserData")]
        public async Task<IActionResult> GetUserData(string userId)
        {
            User user = await _application.User.GetUserData(userId);

            if(user != null)
                return Ok(user);
            else
                return NotFound(new { message = "User not found." });
        }
    }
}
