using Domain.Entities;
using Domain;
using LACS_API.DTO.Analisys.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Util;
using LACS_API.DTO.Analisys;
using LACS_API.DTO.Analisys.Responses;
using LACS_API.DTO;
using Microsoft.AspNetCore.Identity.Data;
using Environment = Domain.Entities.Environment;

namespace LACS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : BaseController
    {
        public EnvironmentController(IConfiguration configuration) : base(configuration)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterEnvironmentRequestDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid edit request. Please check the data." });

            Result<Environment> resultRegister = await _application.Environment.Register(request.Name, request.Document, request.DepartmentName, request.LaboratoryAdress, request.LaboratoryEmail, 
                request.LaboratoryContactInfo, request.CountryName, request.UserUserName, request.UserEmail, LoggedUser);
            if (resultRegister.Success)
            {
                _application.SaveChanges();
                return Ok(new Result<EnvironmentDTO>() { Success = true, Return = new EnvironmentDTO(resultRegister.Return) });
            }
            else
                return BadRequest(new { message = resultRegister.Message });
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateEnvironmentRequestDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid edit request. Please check the data." });
        }

        [HttpGet]
        public async Task<IActionResult> Details(string environmentId)
        {
            Environment environment = await _application.Environment.GetDetails(environmentId);

            if (environment != null)
                return Ok(new EnvironmentDTO(environment));
            else
                return NotFound(new { message = "Environment not found." });
        }

        [HttpPost]
        public async Task<IActionResult> List(EnvironmentListRequestDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid edit request. Please check the data." });

            ICollection<EnvironmentDTO> environments = new List<EnvironmentDTO>();
            Result<DataTableReturn<Environment>> datatableReturnResult = await _application.Environment.GetEnviromentsAsync(request.Page, request.PageSize, LoggedUser, request.Name, request.Document, request.CountryName, request.DepartmentName, request.InitialDate, request.FinalDate);

            if (datatableReturnResult.Success)
            {
                foreach (var environment in datatableReturnResult.Return.Data)
                {
                    environments.Add(new EnvironmentDTO(environment));
                }
            }

            if (datatableReturnResult.Success)
                return Ok(new DataTableReturn<EnvironmentDTO>() { RecordsFiltered = datatableReturnResult.Return.RecordsFiltered, RecordsTotal = datatableReturnResult.Return.RecordsTotal, Data = environments, Page = datatableReturnResult.Return.Page });
            else
                return BadRequest(new { message = datatableReturnResult.Message });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string environmentId)
        {
            Result<object> result = new Result<object>();

            if (string.IsNullOrEmpty(environmentId))
                return BadRequest(new { message = "Invalid environment id." });

            result = await _application.Environment.Delete(environmentId, LoggedUser);

            if (result.Success)
            {
                _application.SaveChanges();
                return Ok(result);
            }
            else
                return BadRequest(new { message = result.Message });

        }

    }
}
