using Application.Interface;
using Data.Interface;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class AnalisysApplication : BaseApplication<Analisys>, IAnalisysApplication
    {
        public AnalisysApplication(IUnitOfWorkRepository repository, IConfiguration configuration) : base(repository, configuration)
        {
        }
    }
}
