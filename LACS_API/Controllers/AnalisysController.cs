using LACS_API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LACS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalisysController : BaseController
    {
        public AnalisysController(IConfiguration configuration) : base(configuration)
        {
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterAnalisysRequestDTO request)
        //{

        //} 
    }
}
