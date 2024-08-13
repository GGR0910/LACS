using Application.Application;
using Application.Interface;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LACS_API.Controllers
{
    //Antes de subir por o Authorize, tirar o api explorer e tirar o loggedUser do construtor
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        protected IUnitOfWorkApplication _application;
        protected IConfiguration _configuration;
        protected User? LoggedUser;

        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
            _application = new UnitOfWorkApplication(configuration);
            LoggedUser = _application.User.GetDetails("c7af4e3e-ff58-4f65-a942-9f5461d65b09").Result;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
                return;

            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenString = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var token = tokenHandler.ReadJwtToken(tokenString);
                var userIdClaim = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData);
                LoggedUser = userIdClaim != null ? _application.User.GetDetails(userIdClaim.Value).Result : null;
            }
        }
    }
}
