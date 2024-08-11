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
    public interface ISampleApplication : IBaseApplication<Sample>
    {
        public Result<object> AssignSampleToAnalist(List<string> SampleIds, string AnalistId, string LoggedUserId, bool AreSamplesAnalized);
        public Task<Result<DataTableReturn<Sample>>> GetSamplesAsync(int page, int pageSize, string loggedUserId, string? requesterId, int? sampleTypeId, int? samplePhisicalStateId, bool? analized, DateTime? initialDate, DateTime? finalDate);
    }
}
