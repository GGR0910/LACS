using Data.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IUserLaboratoryRepository : IBaseRepository<UserLaboratory>
    {
        UserLaboratory? GetUserLaboratory(string userLaboratoryId);
    }
}
