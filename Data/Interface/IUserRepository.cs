using Domain;
using Domain.Entities;
using Domain.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User? GetUserByEmail(string email);
        DataTableReturn<User> GetUsers(int page, int pageLength, string environmentId, string? userName, string? email, int? roleId, string? departamentName);
        void LoginUser(User user);
    }
}
