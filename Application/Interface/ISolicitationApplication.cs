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
    public interface ISolicitationApplication : IBaseApplication<Solicitation>
    {
        public Task<Result<Solicitation>> RegisterSolicitation(string requesterId, int soliciationTypeId, string samplesDescription, string analysisGoalDescription, int analisysTypeId, string? desiredMagnefication, bool needsRecobriment, string? recobrimentMaterial, string? specialPrecautions, DateTime desiredDeadline, string deliveryLocation, bool desireToAccompanyAnalysis, string? observations, int sampleAmount, int sampleTypeId, int samplePhisicalStateId);
        public Task<Result<Solicitation>> MarkSamplesRecieved(string solicitationId, string loggedUserId);
        public Task<Result<Solicitation>> GetSolicitationDetails(string solicitationId);
        public Task<Result<DataTableReturn<Solicitation>>> GetSolicitations(int page, int pageSize, string loggedUserId,string requesterId, int? solicitationTypeId, int? analisysTypeId, bool? resultsDelivered, DateTime? initialDate, DateTime? finalDate);

    }
}
