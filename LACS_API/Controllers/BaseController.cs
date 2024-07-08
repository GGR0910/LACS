using Application.Application;
using Application.Interface;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LACS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IUnitOfWorkApplication _application;
        protected IConfiguration _configuration;

        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
            _application= new UnitOfWorkApplication(configuration);
        }
    }
}
