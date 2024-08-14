using Data.Interface;
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequest)
        {
            Result<Dictionary<string, User>> result = new Result<Dictionary<string, User>>();

            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid login request. Please check your email and password." });

            result = await _application.User.Login(loginRequest.Email, loginRequest.Password);
            User user = result.Return.First().Value;

            if (result.Success)
            {
                _application.SaveChanges();
                return Ok(new LoginResponseDTO(result.Return.First().Key, user));
            }
            else
                return BadRequest(new { message = result.Message });

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserRequestDTO registerRequest)
        {

            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid register request. Please check the data." });

            Result<User> resultRegister = await _application.User.Register(registerRequest.UserName, registerRequest.Email, registerRequest.Password, registerRequest.RoleId, registerRequest.DepartamentName, LoggedUser);
           
            if (resultRegister.Success)
            {
                _application.SaveChanges();
                return Ok(new Result<UserDTO>() { Success = true, Return = new UserDTO(resultRegister.Return)});
            }
            else
                return BadRequest(new { message = resultRegister.Message });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(string userId)
        {
            Result<object> result = new Result<object>();

            if (string.IsNullOrEmpty(userId))
                return BadRequest(new { message = "Invalid user id." });

            result = await _application.User.Delete(userId, LoggedUser);

            if (result.Success)
            {
                _application.SaveChanges();
                return Ok(result);
            }
            else
                return BadRequest(new { message = result.Message });
        }


        [HttpGet]
        public async Task<IActionResult> Details(string userId)
        {
            User user = await _application.User.GetDetails(userId);

            if (user != null)
                return Ok(user);
            else
                return NotFound(new { message = "User not found." });
        }
        
        
        [HttpPost]
        public async Task<IActionResult> UserList(UserPaginationListRequest listRequest) 
        {

            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid edit request. Please check the data." });

            ICollection<UserDTO> users = new List<UserDTO>();
            Result<DataTableReturn<User>> datatableReturnResult = await _application.User.GetUsersAsync(listRequest.Page, listRequest.PageSize, LoggedUser, listRequest.UserName, listRequest.Email, listRequest.RoleId, listRequest.DepartamentName);

            if (datatableReturnResult.Success)
            {
                foreach (var user in datatableReturnResult.Return.Data)
                {
                    users.Add(new UserDTO(user));
                }
            }

            if (datatableReturnResult.Success)
                return Ok(new DataTableReturn<UserDTO>() { RecordsFiltered = datatableReturnResult.Return.RecordsFiltered, RecordsTotal = datatableReturnResult.Return.RecordsTotal, Data = users, Page = datatableReturnResult.Return.Page });
            else
                return BadRequest(new { message = datatableReturnResult.Message });

        }

      
        [HttpPost]
        public async Task<IActionResult> Edit(UserEditRequestDTO editRequest)
        {
            Result<User> result = new Result<User>();

            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid edit request. Please check the data." });

            result = await _application.User.Edit(editRequest.Id, editRequest.UserName, editRequest.Email, editRequest.RoleId, editRequest.DepartamentName, LoggedUser);

            if (result.Success)
            {
                _application.SaveChanges();
                return Ok(new Result<UserDTO>() { Success = true, Return = new UserDTO(result.Return) });
            }
            else
                return BadRequest(new { message = result.Message });
        }
    }
}
