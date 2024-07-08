using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IAPIJWTSessionRepository : IBaseRepository<APIJWTSession>
    {
        Task<APIJWTSession> StartSession(User user);
        Task<APIJWTSession> GetSession(string token);
        void EndSession(string token);
    }
}
