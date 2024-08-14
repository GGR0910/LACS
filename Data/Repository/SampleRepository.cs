using Data.Context;
using Data.Interface;
using Domain;
using Domain.Entities;
using Domain.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Analisys
{
    public class SampleRepository : BaseRepository<Sample>, ISampleRepository
    {
        public SampleRepository(DataContext baseContext) : base(baseContext)
        {
        }

        public DataTableReturn<Sample> GetSamples(int page, int pageSize, string? requesterId, int? sampleTypeId, int? samplePhisicalStateId, bool? analized, DateTime? initialDate, DateTime? finalDate)
        {
            IQueryable<Sample> samples = _context.Sample
                .Include(s => s.Solicitation)
                .Include(s => s.Analist);


            int recordsTotal = samples.Count();

            if (analized.HasValue)
                samples = samples.Where(s => s.SampleAnalisysDate != null);
            else
                samples = samples.Where(s => s.SampleAnalisysDate == null);

            if (initialDate.HasValue)
                samples = samples.Where(s => s.CreatedAt >= initialDate);

            if (finalDate.HasValue)
                samples = samples.Where(s => s.CreatedAt <= finalDate);

            samples = samples.OrderBy(s => s.SampleAnalisysExpectedDate).Skip((page - 1) * pageSize).Take(pageSize);

            DataTableReturn<Sample> dataTableReturn = new DataTableReturn<Sample>()
            {
                Data = samples.ToList(),
                RecordsTotal = recordsTotal,
                RecordsFiltered = samples.Count(),
                Page = page
            };

            return dataTableReturn;
        }
    }
}
