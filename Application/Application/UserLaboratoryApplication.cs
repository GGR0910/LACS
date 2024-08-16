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
    public class UserLaboratoryApplication : BaseApplication<UserLaboratory>, IUserLaboratoryApplication
    {
        public UserLaboratoryApplication(IUnitOfWorkRepository repository, IConfiguration configuration) : base(repository, configuration)
        {
        }

        public Task<UserLaboratory> GetDetails(string userLaboratoryId)
        {
            return Task.FromResult(_repository.UserLaboratory.GetUserLaboratory(userLaboratoryId));
        }
    }
}
