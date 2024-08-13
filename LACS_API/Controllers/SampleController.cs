using Domain.Entities;
using Domain;
using LACS_API.DTO.Analisys.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Util;
using LACS_API.DTO.Analisys;
using LACS_API.DTO.Analisys.Responses;

namespace LACS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : BaseController
    {
        public SampleController(IConfiguration configuration) : base(configuration)
        {

        }

        [HttpPost("AssignSampleToAnalist")]
        public async Task<IActionResult> AssignSampleToAnalist([FromBody] AssignSampleToAnalistRequestDTO request)
        {

            //Result<object> result = new Result<object>();

            //if (!ModelState.IsValid)
            //    return BadRequest(new { message = "Invalid solicitation request. Please check the data." });
            //if (request.SampleIds.Count() < 1)
            //    return BadRequest(new { message = "No samples located" });

            //result = _application.Sample.AssignSampleToAnalist(request.SampleIds, request.AnalistId, request.LoggedUserId, request.AreSamplesAnalised);

            //if (result.Success)
            //    return Ok();
            //else
            //    return BadRequest(new { message = result.Message });

            return Ok();

        }

        [HttpPost("GetSamples")]
        public async Task<IActionResult> GetSamples(SampleListPaginationRequestDTO request)
        {
            List<SampleListDTO> samples = new List<SampleListDTO>();

            //var datatableReturnResult = await _application.Sample.GetSamplesAsync(request.Page, request.PageSize, request.LoggedUserId, request.RequesterId, request.SampleTypeId, request.SamplePhisicalStateId, request.Analized, request.InitialDate, request.FinalDate);

            //if (datatableReturnResult.Success)
            //{
            //    foreach (var sample in datatableReturnResult.Return.Data)
            //    {
            //        samples.Add(new SampleListDTO(sample));
            //    }
            //}


            //if (datatableReturnResult.Success)
            //    return Ok(new DataTableReturn<SampleListDTO>() { RecordsFiltered = datatableReturnResult.Return.RecordsFiltered, RecordsTotal = datatableReturnResult.Return.RecordsTotal, Data = samples, Page = datatableReturnResult.Return.Page });
            //else
            // return BadRequest(new { message = datatableReturnResult.Message });
            return Ok();
        }

        [HttpPost]
        [Route("MarkSamplesRecieved")]
        public async Task<IActionResult> MarkSamplesRecieved([FromBody] MarkSamplesRecievedRequestDTO request)
        {
            Result<Solicitation> result = new Result<Solicitation>();

            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid request. Please check the data." });

            //result = await _application.Solicitation.MarkSamplesRecieved(request.SolicitationId, );

            if (result.Success)
                return Ok();
            else
                return BadRequest(new { message = result.Message });
        }
    }
}
