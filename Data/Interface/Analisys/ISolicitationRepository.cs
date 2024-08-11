using Domain;
using Domain.Entities;
using Domain.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface.Analisys
{
    public interface ISolicitationRepository : IBaseRepository<Solicitation>
    {
        public Result<Solicitation> GetSolicitation(string solicitationId);
        public Task<DataTableReturn<Solicitation>> GetSolicitations(int page, int pageSize, string? requesterId, int? solicitationTypeId, int? analisysTypeId, bool? resultsDelivered, DateTime? initialDate, DateTime? finalDate);
    }
}
