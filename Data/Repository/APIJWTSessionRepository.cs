using Data.Context;
using Data.Interface;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class APIJWTSessionRepository : BaseRepository<APIJWTSession>, IAPIJWTSessionRepository
    {
        public APIJWTSessionRepository(DataContext baseContext) : base(baseContext)
        {
        }

        public void EndSession(string token)
        {
            APIJWTSession session = _context.APIJWTSession.First(s => s.JWTKeyUsed == token && !s.Deleted);
            session.Deleted = true;
            _context.APIJWTSession.Update(session);
        }

        public Task<APIJWTSession> GetSession(string token)
        {
           return Task.FromResult(_context.APIJWTSession.First(s => s.JWTKeyUsed == token && !s.Deleted));
        }

        public Task<APIJWTSession> StartSession(User user)
        {
            APIJWTSession session = new APIJWTSession(user.Id, user, Guid.NewGuid().ToString());
            _context.APIJWTSession.Add(session);
            
            return Task.FromResult(session);
        }

    }
}
