using Domain;
using Domain.Entities;
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
    }
}
