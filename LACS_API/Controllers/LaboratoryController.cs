using Domain.Entities;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Domain.Util;
using LACS_API.DTO;

namespace LACS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratoryController : BaseController
    {
        public LaboratoryController(IConfiguration configuration) : base(configuration)
        {

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterLaboratoryRequestDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid edit request. Please check the data." });

            Result<Laboratory> resultRegister = await _application.Laboratory.Register(request.Name, request.ResponsibleDocument, request.DepartmentName, request.LaboratoryAdress, request.LaboratoryEmail, 
                request.LaboratoryContactInfo, request.CountryName, request.UserUserName, request.UserEmail, LoggedUser);
            if (resultRegister.Success)
            {
                _application.SaveChanges();
                return Ok(new Result<LaboratoryDTO>() { Success = true, Return = new LaboratoryDTO(resultRegister.Return) });
            }
            else
                return BadRequest(new { message = resultRegister.Message });
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateLaboratoryRequestDTO request)
        {
            Result<Laboratory> result = new Result<Laboratory>();

            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid edit request. Please check the data." });

            result = await _application.Laboratory.Edit(request.Name, request.LaboratoryAdress, request.LaboratoryContactInfo, request.LaboratoryEmail, request.DepartmentName, request.CountryName, LoggedUser);

            if (result.Success)
            {
                _application.SaveChanges();
                return Ok(new Result<LaboratoryDTO>() { Success = true, Return = new LaboratoryDTO(result.Return) });
            }
            else
                return BadRequest(new { message = result.Message });
        }

        [HttpGet("Details")]
        public async Task<IActionResult> Details(string LaboratoryId)
        {
            Laboratory Laboratory = await _application.Laboratory.GetDetails(LaboratoryId);

            if (Laboratory != null)
                return Ok(new LaboratoryDTO(Laboratory));
            else
                return NotFound(new { message = "Laboratory not found." });
        }

        [HttpPost("List")]
        public async Task<IActionResult> List(LaboratoryListRequestDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid edit request. Please check the data." });

            ICollection<LaboratoryDTO> Laboratorys = new List<LaboratoryDTO>();
            Result<DataTableReturn<Laboratory>> datatableReturnResult = await _application.Laboratory.GetLaboratorysAsync(request.Page, request.PageSize, LoggedUser, request.Name, request.Document, request.CountryName, request.DepartmentName, request.InitialDate, request.FinalDate);

            if (datatableReturnResult.Success)
            {
                foreach (var Laboratory in datatableReturnResult.Return.Data)
                {
                    Laboratorys.Add(new LaboratoryDTO(Laboratory));
                }
            }

            if (datatableReturnResult.Success)
                return Ok(new DataTableReturn<LaboratoryDTO>() { RecordsFiltered = datatableReturnResult.Return.RecordsFiltered, RecordsTotal = datatableReturnResult.Return.RecordsTotal, Data = Laboratorys, Page = datatableReturnResult.Return.Page });
            else
                return BadRequest(new { message = datatableReturnResult.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string LaboratoryId)
        {
            Result<object> result = new Result<object>();

            if (string.IsNullOrEmpty(LaboratoryId))
                return BadRequest(new { message = "Invalid Laboratory id." });

            result = await _application.Laboratory.Delete(LaboratoryId, LoggedUser);

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
