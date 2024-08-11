using Domain;
using Domain.Entities;
using Domain.Util;
using LACS_API.DTO;
using LACS_API.DTO.Analisys;
using LACS_API.DTO.Analisys.Requests;
using LACS_API.DTO.Analisys.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace LACS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitationController : BaseController
    {
        public SolicitationController(IConfiguration configuration) : base(configuration)
        {
        }

        [HttpPost]
        [Route("GetSolicitations")]
        public async Task<IActionResult> GetSolicitations([FromBody] SolicitationListPaginationRequestDTO request)
        {
            Result<DataTableReturn<SolicitationListDTO>> result = new Result<DataTableReturn<SolicitationListDTO>>();

            var datatableReturnResult = await _application.Solicitation.GetSolicitations(request.Page, request.PageSize, request.LoggedUserId, request.RequesterId, request.SolicitationTypeId, request.AnalisysTypeId, request.ResultsDelivered, request.InitialDate, request.FinalDate);
            List<SolicitationListDTO> solicitations = new List<SolicitationListDTO>();

            if (datatableReturnResult.Success)
            {
                foreach (var solicitation in datatableReturnResult.Return.Data)
                {
                    solicitations.Add(new SolicitationListDTO(solicitation));
                }

                return Ok(new DataTableReturn<SolicitationListDTO>() { RecordsFiltered = datatableReturnResult.Return.RecordsFiltered, RecordsTotal = datatableReturnResult.Return.RecordsTotal, Data = solicitations, Page = datatableReturnResult.Return.Page });
            }
            else
                return BadRequest(new { message = result.Message });
        }


        [HttpGet]
        [Route("SolicitationDetails")]
        public async Task<IActionResult> SolicitationDetails(string solicitationId)
        {
            Result<Solicitation> result = new Result<Solicitation>();

            if (string.IsNullOrEmpty(solicitationId))
                return BadRequest(new { message = "Invalid solicitation id." });

            result = await _application.Solicitation.GetSolicitationDetails(solicitationId);

            if (result.Success)
                return Ok(new SolicitationDTO(result.Return));
            else
                return BadRequest(new { message = result.Message });
        }
    }
}
