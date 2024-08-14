using Data.Context;
using Data.Interface;
using Domain.Entities;
using Domain.Util;
using Microsoft.IdentityModel.Tokens;
using Environment = Domain.Entities.Environment;

namespace Data.Repository
{
    public class EnvironmentRepository : BaseRepository<Domain.Entities.Environment>, IEnvironmentRepository
    {
        public EnvironmentRepository(DataContext baseContext) : base(baseContext)
        {
        }

        public Domain.Entities.Environment? GetEnvironmentByDocument(string document)
        {
           return _context.Environment.FirstOrDefault(x => x.Document == document);
        }

        public DataTableReturn<Domain.Entities.Environment> GetEnvironments(int page, int pageSize, string? name, string? document, string? countryName, string? departmentName, DateTime? initialDate, DateTime? finalDate)
        {
            IQueryable<Environment> environments = _context.Environment;

            int recordsTotal = environments.Count();

            if (!name.IsNullOrEmpty())
                environments = environments.Where(x => x.Name.Contains(name));

            if (!document.IsNullOrEmpty())
                environments = environments.Where(x => x.Document.Contains(document));

            if (!countryName.IsNullOrEmpty())
                environments = environments.Where(x => x.CountryName.Contains(countryName));

            if (!departmentName.IsNullOrEmpty())
                environments = environments.Where(x => x.DepartmentName.Contains(departmentName));

            if (initialDate != null)
                environments = environments.Where(x => x.CreatedAt >= initialDate);

            if (finalDate != null)
                environments = environments.Where(x => x.CreatedAt <= finalDate);

            environments = environments.OrderBy(u => u.Name).Skip((page - 1) * pageSize).Take(pageSize);

            DataTableReturn<Environment> dataTableReturn = new DataTableReturn<Environment>()
            {
                Data = environments.ToList(),
                RecordsTotal = recordsTotal,
                RecordsFiltered = environments.Count(),
                Page = page
            };

            return dataTableReturn;
        }
    }
}
