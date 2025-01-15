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
    public interface IUserLaboratoryApplication : IBaseApplication<UserLaboratory>
    {
        Task<Result<UserLaboratory>> Register(string userName, string email, int roleId, string departamentName, string document ,User loggedUser);
        Task<Result<object>> ChangeStatus(string userId, User loggedUser);
        Task<Result<UserLaboratory>> GetDetails(string userId);
        Task<Result<DataTableReturn<UserLaboratory>>> GetUsers(int page, int pageLength, User loggedUser, string? userName, string? email, int? roleId, string? departamentName);
        Task<Result<UserLaboratory>> Edit(string id, string userName, string email, int roleId, string departamentName, User loggedUser);
    }
}
