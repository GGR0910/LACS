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
    public class EnvironmentController : BaseController
    {
        public EnvironmentController(IConfiguration configuration) : base(configuration)
        {

        }

    }
}
