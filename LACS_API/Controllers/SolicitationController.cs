using Domain;
using Domain.Entities;
using LACS_API.DTO.Analisys.Requests;
using LACS_API.DTO.Analisys.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> RegisterSolicitation([FromBody] AnalisysSolicitationRequestDTO request)
        {
            Result<Solicitation> result = new Result<Solicitation>();

            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid solicitation request. Please check the data." });

            result = await _application.Solicitation.RegisterSolicitation(request.RequesterId, request.SoliciationTypeId, request.SamplesDescription, request.AnalysisGoalDescription, request.AnalisysTypeId, request.DesiredMagnefication,
                request.NeedsRecobriment, request.RecobrimentMaterial, request.SpecialPrecautions, request.DesiredDeadline, request.DeliveryLocation, request.DesireToAccompanyAnalysis, request.Observations, request.SampleAmaunt);

            if (result.Success)
                return Ok(new AnalisysSolicitationResponseDTO());
            else
                return BadRequest(new { message = result.Message });
        }
    }
}
