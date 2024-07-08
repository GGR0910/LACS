using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUserApplication : IBaseApplication<User>
    {
        Task<Result<APIJWTSession>> UserLogin(string email, string password);
        Task<APIJWTSession> GetSessionData(string token);
        void EndSession(string token);
        Task<Result<User>> RegisterUser(string userName, string email, string password, string creatorId);
        Task<Result<User>> DeleteUser(string userId);
    }
}
