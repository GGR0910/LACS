using Domain;
using Domain.Entities;
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
        [Route("RegisterSolicitation")]
        public async Task<IActionResult> RegisterSolicitation([FromBody] AnalisysSolicitationRequestDTO request)
        {
            Result<Solicitation> result = new Result<Solicitation>();

            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid solicitation request. Please check the data." });

            result = await _application.Solicitation.RegisterSolicitation(request.RequesterId, request.SoliciationTypeId, request.SamplesDescription, request.AnalysisGoalDescription, request.AnalisysTypeId, request.DesiredMagnefication,
                request.NeedsRecobriment, request.RecobrimentMaterial, request.SpecialPrecautions, request.DesiredDeadline, request.DeliveryLocation, request.DesireToAccompanyAnalysis, request.Observations, 
                request.SampleAmaunt,request.SampleTypeId,request.SamplePhisicalStateId);

            if (result.Success)
                return Ok();
            else
                return BadRequest(new { message = result.Message });
        }

        [HttpGet]
        [Route("GetSolicitations")]
        public async Task<IActionResult> GetSolicitations(string requesterId)
        {
            Result<List<Solicitation>> result = new Result<List<Solicitation>>();

            result = await _application.Solicitation.GetSolicitations(requesterId);
            List<SolicitationListDTO> solicitations = new List<SolicitationListDTO>();
            foreach (var solicitation in result.Return)
            {
                solicitations.Add(new SolicitationListDTO(solicitation));
            }

            if (result.Success)
                return Ok(new { solicitations = solicitations });
            else
                return BadRequest(new { message = result.Message });
        }

        [HttpPost]
        [Route("MarkSamplesRecieved")]
        public async Task<IActionResult> MarkSamplesRecieved([FromBody] MarkSamplesRecievedRequestDTO request)
        {
            Result<object> result = new Result<object>();

            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid request. Please check the data." });

            result = await _application.Solicitation.MarkSamplesRecieved(request.SolicitationId, request.LoggedUserId);

            if (result.Success)
                return Ok();
            else
                return BadRequest(new { message = result.Message });
        }
    }
}
