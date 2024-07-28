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
        Task<Result<Dictionary<string, User>>> UserLogin(string email, string password);
        Task<Result<User>> RegisterUser(string userName, string email, string password, string creatorId, int roleId, string departamentName);
        Task<Result<User>> DeleteUser(string userId, string creatorId);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserData(string userId);
    }
}
