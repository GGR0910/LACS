using Domain;
using Domain.Entities;
using Domain.Util;
using LACS_API.DTO;
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

        [HttpGet]
        [Route("GetDetails/{userId}")]
        public async Task<IActionResult> GetDetails(string userId)
        {
            if(Guid.TryParse(userId, out Guid userIdGuid))
            {
                Result<User> result = await _application.User.GetDetails(userId);
                return Ok(result);
            }
            
            return BadRequest();
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDTORequest request)
        {
            Result<Dictionary<string,User>> result = await _application.User.Login(request.Email, request.Password);

            //Checar o que vou precisar do usuário no login e criar um dto response pra isso, retornar a key e os dados do usuário

            if (result.Success)
                return Ok(result.Return.First().Key);

            return BadRequest(result);
        }

        [HttpPost]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers(GetUsersPaginableDTORequest request)
        {
            Result<DataTableReturn<User>> result = await _application.User.GetUsers(request.Page,request.PageSize,LoggedUser,request.UserName,request.Email,request.RoleId);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
