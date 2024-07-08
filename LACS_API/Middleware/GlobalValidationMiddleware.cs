using Application.Application;
using Application.Interface;
using Domain.Entities;
using Domain;
using LACS_API.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.IdentityModel.Tokens;

namespace LACS_API.Middleware
{
    public class GlobalValidationMiddleware
    {
        protected IUnitOfWorkApplication _application;
        protected IConfiguration _configuration;

        public GlobalValidationMiddleware(IConfiguration configuration)
        {
            _configuration = configuration;
            _application= new UnitOfWorkApplication(configuration);
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Method.ToUpperInvariant() == "POST") // Check for POST requests
            {
                if (context.Request.HasFormContentType) // Check if request has form data
                {
                    if (context.Request.Form.TryGetValue("model", out var modelString)) // Extract model data
                    {
                        if (!string.IsNullOrEmpty(modelString)) // Check if model data is not empty
                        {
                            var model = JsonConvert.DeserializeObject<BaseRequestDTO>(modelString); // Deserialize model data

                            APIJWTSession? session = _application.User.GetSessionData(model.JWTKey).Result;
                            string returnMessage = string.Empty;

                            if (session == null || session.UserId != model.LoggedUserId)
                                returnMessage = "Invalid token";
                            else if (session.DateLimitToUse < DateTime.Now)
                            {
                                returnMessage = "Token expired";
                                _application.User.EndSession(model.JWTKey);
                            }


                            if (!returnMessage.IsNullOrEmpty()) // Check validation results
                            {
                                context.Response.StatusCode = 400;
                                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { returnMessage })); // Return JSON with errors
                                return; 
                            }
                        }
                    }
                }
            }

            await next(context); 
        }
    }
}

