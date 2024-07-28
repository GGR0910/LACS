using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LACS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : BaseController
    {
        public SampleController(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
