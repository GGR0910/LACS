using Domain;
using Domain.Entities;
using Domain.Util;
using Laboratory = Domain.Entities.Laboratory;

namespace Application.Interface
{
    public interface ILaboratoryApplication : IBaseApplication<Laboratory>
    {
        Task<Result<object>> Delete(string environmentId, User? loggedUser);
        Task<Result<Laboratory>> Edit(string name, string laboratoryAdress, string laboratoryContactInfo, string laboratoryEmail, string departmentName, string countryName, User loggedUser);
        Task<Result<Laboratory>> GetDetails(string environmentId);
        Task<Result<DataTableReturn<Laboratory>>> GetLaboratorysAsync(int page, int pageSize, User? loggedUser, string? name, string? document, string? countryName, string? departmentName, DateTime? initialDate, DateTime? finalDate);
        Task<Result<Laboratory>> Register(string name, string responsibleDocument, string departmentName, string laboratoryAdress, string laboratoryEmail, string laboratoryContactInfo, string countryName, string userUserName, string userEmail, string userDocument, string laboratoryDocument, User loggedUser);
    }
}
