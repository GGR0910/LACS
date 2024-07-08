using Application.Interface;
using Data.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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

    }
}
