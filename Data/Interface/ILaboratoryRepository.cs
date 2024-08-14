using Domain.Entities;
using Domain.Util;
using Laboratory = Domain.Entities.Laboratory;

namespace Data.Interface
{
    public interface ILaboratoryRepository : IBaseRepository<Laboratory>
    {
        Laboratory? GetLaboratoryByDocument(string document);
        DataTableReturn<Laboratory> GetLaboratorys(int page, int pageSize, string? name, string? document, string? countryName, string? departmentName, DateTime? initialDate, DateTime? finalDate);
    }
}
