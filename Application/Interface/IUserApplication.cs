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
        Task<Result<User>> GetDetails(string userId);
        Task<Result<DataTableReturn<User>>> GetUsers(int page, int pageLength, User loggedUser, string? userName, string? email, int? roleId);
    }
}
