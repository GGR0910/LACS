using Domain.Entities;
using Domain.Util;
using Domain;
using LACS_API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LACS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaboratoryController : BaseController
    {
        public LaboratoryController(IConfiguration configuration) : base(configuration)
        {
        }

        [HttpGet]
        [Route("GetDetails/{laboratoryId}")]
        public async Task<IActionResult> GetDetails(string laboratoryId)
        {
            if (Guid.TryParse(laboratoryId, out Guid laboratoryGuidId))
            {
                Result<Laboratory> result = await _application.Laboratory.GetDetails(laboratoryId);

                if(result.Success)
                    return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterLaboratoryDTO request)
        {
            Result<Laboratory> result = await _application.Laboratory.Register();

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        [Route("GetLaboratorys")]
        public async Task<IActionResult> GetLaboratorys(GetLaboratorysPaginableDTORequest request)
        {
            Result<DataTableReturn<Laboratory>> result = await _application.Laboratory.GetLaboratorysAsync();

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(EditLaboratoryDTORequest request)
        {
            if (Guid.TryParse(request.Id, out Guid userIdGuid))
            {
                Result<Laboratory> result = await _application.Laboratory.Edit();

                if (result.Success)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest();
        }
    }
}
