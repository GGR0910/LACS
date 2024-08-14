using Domain;
using Domain.Entities;
using Domain.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ISampleRepository : IBaseRepository<Sample>
    {
        public DataTableReturn<Sample> GetSamples(int page, int pageSize, string? requesterId, int? sampleTypeId, int? samplePhisicalStateId, bool? analized, DateTime? initialDate, DateTime? finalDate);
    }
}
