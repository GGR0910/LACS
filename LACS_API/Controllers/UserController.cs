using Data.Interface;
using Domain;
using Domain.Entities;
using LACS_API.DTO;
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
        [HttpGet]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequest)
        {
            Result<APIJWTSession> result = new Result<APIJWTSession>();

            if(!ModelState.IsValid)
                return BadRequest(new { message = "Invalid login request. Please check your email and password." });

            result = await _application.User.UserLogin(loginRequest.Email, loginRequest.Password);
            
            if(result.Success)
                return Ok(new LoginResponseDTO { Token = result.Return.JWTKeyUsed, ValidUntil = result.Return.DateLimitToUse.ToString() });
            else
                return BadRequest(new { message = result.Message });
            
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserRequestDTO registerRequest)
        {
            Result<User> result = new Result<User>();

            if(!ModelState.IsValid)
                return BadRequest(new { message = "Invalid register request. Please check the data." });

            result = await _application.User.RegisterUser(registerRequest.UserName, registerRequest.Email, registerRequest.Password, registerRequest.LoggedUserId);
            
            if(result.Success)
                return Ok(new { message = "User registered successfully." });
            else
                return BadRequest(new { message = result.Message });
        }
    }
}
