using Domain;
using Domain.Entities;
using Domain.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUserApplication : IBaseApplication<User>
    {
        Task<Result<Dictionary<string, User>>> Login(string email, string password);
        Task<Result<User>> Register(string userName, string email, string password, int roleId, string departamentName, User loggedUser);
        Task<Result<object>> Delete(string userId, User loggedUser);
        Task<User> GetDetails(string userId);
        Task<Result<DataTableReturn<User>>> GetUsersAsync(int page, int pageLength, User loggedUser, string? userName, string? email, int? roleId, string? departamentName);
        Task<Result<User>> Edit(string id, string userName, string email, int roleId, string departamentName, User loggedUser);
    }
}
