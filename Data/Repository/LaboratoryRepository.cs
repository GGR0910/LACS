using Data.Context;
using Data.Interface;
using Domain.Entities;
using Domain.Util;
using Microsoft.IdentityModel.Tokens;
using Laboratory = Domain.Entities.Laboratory;

namespace Data.Repository
{
    public class LaboratoryRepository : BaseRepository<Domain.Entities.Laboratory>, ILaboratoryRepository
    {
        public LaboratoryRepository(DataContext baseContext) : base(baseContext)
        {
        }

        public Domain.Entities.Laboratory? GetLaboratoryByDocument(string document)
        {
           return _context.Laboratory.FirstOrDefault(x => x.ResponsibleDocument == document);
        }

        public DataTableReturn<Domain.Entities.Laboratory> GetLaboratorys(int page, int pageSize, string? name, string? document, string? countryName, string? departmentName, DateTime? initialDate, DateTime? finalDate)
        {
            IQueryable<Laboratory> Laboratorys = _context.Laboratory;

            int recordsTotal = Laboratorys.Count();

            if (!name.IsNullOrEmpty())
                Laboratorys = Laboratorys.Where(x => x.Name.Contains(name));

            if (!document.IsNullOrEmpty())
                Laboratorys = Laboratorys.Where(x => x.ResponsibleDocument.Contains(document));

            if (!countryName.IsNullOrEmpty())
                Laboratorys = Laboratorys.Where(x => x.CountryName.Contains(countryName));

            if (!departmentName.IsNullOrEmpty())
                Laboratorys = Laboratorys.Where(x => x.DepartmentName.Contains(departmentName));

            if (initialDate != null)
                Laboratorys = Laboratorys.Where(x => x.CreatedAt >= initialDate);

            if (finalDate != null)
                Laboratorys = Laboratorys.Where(x => x.CreatedAt <= finalDate);

            Laboratorys = Laboratorys.OrderBy(u => u.Name).Skip((page - 1) * pageSize).Take(pageSize);

            DataTableReturn<Laboratory> dataTableReturn = new DataTableReturn<Laboratory>()
            {
                Data = Laboratorys.ToList(),
                RecordsTotal = recordsTotal,
                RecordsFiltered = Laboratorys.Count(),
                Page = page
            };

            return dataTableReturn;
        }
    }
}
