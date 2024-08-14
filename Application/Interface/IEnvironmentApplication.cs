using Domain;
using Domain.Entities;
using Domain.Util;
using Environment = Domain.Entities.Environment;

namespace Application.Interface
{
    public interface IEnvironmentApplication : IBaseApplication<Environment>
    {
        Task<Result<object>> Delete(string environmentId, User? loggedUser);
        Task<Environment> GetDetails(string environmentId);
        Task<Result<DataTableReturn<Environment>>> GetEnviromentsAsync(int page, int pageSize, User? loggedUser, string? name, string? document, string? countryName, string? departmentName, DateTime? initialDate, DateTime? finalDate);
        Task<Result<Environment>> Register(string name, string document, string departmentName, string laboratoryAdress, string laboratoryEmail, string laboratoryContactInfo, string countryName, string userUserName, string userEmail, Domain.Entities.User? loggedUser);
    }
}
