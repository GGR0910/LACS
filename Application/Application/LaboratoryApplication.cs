using Application.Interface;
using Data.Interface;
using Domain;
using Domain.Entities;
using Domain.Enum;
using Domain.Util;
using Microsoft.Extensions.Configuration;
using Laboratory = Domain.Entities.Laboratory;

namespace Application.Application
{
    public class LaboratoryApplication : BaseApplication<Domain.Entities.Laboratory>, ILaboratoryApplication
    {
        public LaboratoryApplication(IUnitOfWorkRepository repository, IConfiguration configuration) : base(repository, configuration)
        {
        }

    }
}
