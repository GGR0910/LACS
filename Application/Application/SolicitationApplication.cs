using Application.Interface;
using Data.Interface;
using Domain;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class SolicitationApplication : BaseApplication<Solicitation>, ISolicitationApplication
    {
        public SolicitationApplication(IUnitOfWorkRepository repository, IConfiguration configuration) : base(repository, configuration)
        {
        }

        public Task<Result<Solicitation>> RegisterSolicitation(string requesterId, int soliciationTypeId, string samplesDescription, string analysisGoalDescription, int analisysTypeId, string? desiredMagnefication, bool needsRecobriment, string? recobrimentMaterial, string? specialPrecautions, DateTime desiredDeadline, string deliveryLocation, bool desireToAccompanyAnalysis, string? observations, int sampleAmount, int sampleTypeId, int samplePhisicalStateId)
        {
            Result<Solicitation> result = new Result<Solicitation>();
            User? requester = _repository.UserRepository.GetById(requesterId);

            if (requester == null)
                result.Message = "Requester not found.";
            else if (!Enum.IsDefined(typeof(SolicitationType), soliciationTypeId))
                result.Message = "Invalid solicitation type.";
            else if (!Enum.IsDefined(typeof(AnalisysType), analisysTypeId))
                result.Message = "Invalid analisys type.";
            else if (desiredDeadline < DateTime.Now)
                result.Message = "Invalid desired deadline.";
            else
            {
                Solicitation solicitation = new Solicitation(requesterId, soliciationTypeId, samplesDescription, analysisGoalDescription, 
                    analisysTypeId, desiredMagnefication, needsRecobriment, recobrimentMaterial, specialPrecautions, 
                    desiredDeadline, deliveryLocation, desireToAccompanyAnalysis, observations);
                
                foreach (var sample in Enumerable.Range(0, sampleAmount))
                    solicitation.Samples.Add(new Sample(solicitation.Id, sampleTypeId, samplePhisicalStateId, requesterId));

                DefineExpectedDeliverDate(ref solicitation);
            }
        }

        private void DefineExpectedDeliverDate(ref Solicitation solicitation)
        {
            var solicitations = _repository.SolicitationRepository.GetAll();
            var lastSolicitation = solicitations.Where(s => s.CompletionDate == null).OrderByDescending(s => s.ExpectedCompletionDate).FirstOrDefault();
            
            
        }
    }
}
