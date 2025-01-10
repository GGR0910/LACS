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


    }
}
