using Domain;
using Domain.Entities;
using LACS_API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LACS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmitionController : BaseController
    {
        public SubmitionController(IConfiguration configuration) : base(configuration)
        {
        }

        public IActionResult CreateSubmition(SubmitionDTO submitionDTO)
        {
            Result<Solicitation> result = _application.Solicitation.CreateSolicitation(submitionDTO.FormId, LoggedUser.Id);

            if (result.Success)
                return Ok(CreateSubmitionResponse.SerializeToReturn(result.Return));
                
            return BadRequest(result);
        }
    }
}
