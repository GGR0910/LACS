using Application.Interface;
using Data.Interface;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class BaseApplication<T> : IBaseApplication<T> where T : class
    {
        protected readonly IUnitOfWorkRepository _repository;
        protected readonly IConfiguration _configuration;

        public BaseApplication(IUnitOfWorkRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        protected string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["AppSettings:Issuer"],
                audience: _configuration["AppSettings:Audience"],
                expires: DateTime.UtcNow.AddHours(3), // Set an appropriate token expiration time
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
