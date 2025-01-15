using Domain.Entities;
using Domain.Util;
using Domain;
using LACS_API.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LACS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLaboratoryController : BaseController
    {
        public UserLaboratoryController(IConfiguration configuration) : base(configuration)
        {
        }

        [HttpGet]
        [Route("GetDetails/{userId}")]
        public async Task<IActionResult> GetDetails(string userId)
        {
            if (Guid.TryParse(userId, out Guid userIdGuid))
            {
                Result<User> result = await _application.User.GetDetails(userId);
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterUserDTORequest request)
        {
            Result<UserLaboratory> result = await _application.UserLaboratory.Register(request.UserName, request.Email, request.RoleId, request.DepartamentName, request.UserDocument , LoggedUser);

            if (result.Success)
                return Ok(result);

            return Ok(result);
        }

        [HttpPost]
        [Route("ChangeStatus/{userId}")]
        public async Task<IActionResult> ChangeStatus(string userId)
        {

            if (Guid.TryParse(userId, out Guid userIdGuid))
            {
                Result<object> result = await _application.UserLaboratory.ChangeStatus(userId, LoggedUser);

                if (result.Success)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers(GetUsersPaginableDTORequest request)
        {
            Result<DataTableReturn<UserLaboratory>> result = await _application.UserLaboratory.GetUsers(request.Page, request.PageSize, LoggedUser, request.UserName, request.Email, request.RoleId, request.DepartamentName);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(EditUserDTORequest request)
        {
            if (Guid.TryParse(request.Id, out Guid userIdGuid))
            {
                Result<UserLaboratory> result = await _application.UserLaboratory.Edit(request.Id, request.UserName, request.Email, request.RoleId, request.DepartamentName, LoggedUser);

                if (result.Success)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest();
        }
    }
}
