using Domain.Entities;
using Domain.Util;
using Environment = Domain.Entities.Environment;

namespace Data.Interface
{
    public interface IEnvironmentRepository : IBaseRepository<Environment>
    {
        Environment? GetEnvironmentByDocument(string document);
        DataTableReturn<Environment> GetEnvironments(int page, int pageSize, string? name, string? document, string? countryName, string? departmentName, DateTime? initialDate, DateTime? finalDate);
    }
}
