using Data.Context;
using Data.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserLaboratoryRepository : BaseRepository<UserLaboratory>, IUserLaboratoryRepository
    {
        public UserLaboratoryRepository(DataContext baseContext) : base(baseContext)
        {
        }
    }
}
