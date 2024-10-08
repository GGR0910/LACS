﻿using Application.Interface;
using Application.Util;
using Data.Interface;
using Domain;
using Domain.Entities;
using Domain.Enum;
using Domain.Util;
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
            User? requester = _repository.User.GetById(requesterId);

            if (requester == null)
                result.Message = "Requester not found.";
            else if (!Enum.IsDefined(typeof(SolicitationTypeEnum), soliciationTypeId))
                result.Message = "Invalid solicitation type.";
            else if (!Enum.IsDefined(typeof(AnalisysTypeEnum), analisysTypeId))
                result.Message = "Invalid analisys type.";
            else if (desiredDeadline < DateTime.Now)
                result.Message = "Invalid desired deadline.";
            else
            {
                Solicitation solicitation = new Solicitation(requesterId, soliciationTypeId, desiredDeadline, "");
                
                foreach (var sample in Enumerable.Range(0, sampleAmount))
                    solicitation.Samples.Add(new Sample(solicitation.Id, requesterId));

                _repository.Solicitation.Add(solicitation);
                _repository.SaveChanges();
                result.Return = solicitation;
                result.Success = true;

                //Mandar email para solicitante indicando que a solicitação foi registrada com sucesso e informando que aguarda a confirmação do recebimento das amostras
            }

            return Task.FromResult(result);
        }
 
        public Task<Result<Solicitation>> MarkSamplesRecieved(string solicitationId, string loggedUserId)
        {
            Result<Solicitation> result = new Result<Solicitation>();
            User? user = _repository.User.GetById(loggedUserId);
            result = _repository.Solicitation.GetSolicitation(solicitationId);

            if(!result.Success)
                result.Message = "Solicitation not found.";
            else if (user == null)
                result.Message += "User not found.";
            else if(user?.RoleId == (int)RolesEnum.User)
                result.Message += "User not authorized to mark samples as received.";
            else
            {
                Solicitation solicitation = result.Return;
                solicitation.SamplesReceivedDate = DateTime.Now;
                DefineExpectedDeliverDate(ref solicitation);
                solicitation.ExpectedCompletionDate = solicitation.Samples.Max(s => s.SampleAnalisysExpectedDate).AddDays(1);
                solicitation.Update(loggedUserId);

                _repository.Solicitation.Update(solicitation);
                _repository.SaveChanges();
                result.Success = true;

                //Mandar email para o solicitante indicando que as amostras foram recebidas e informando a data prevista para entrega dos resultados
            }
            
            return Task.FromResult(result);
        }

        private void DefineExpectedDeliverDate(ref Solicitation solicitation)
        {
            IEnumerable<Sample> samples = _repository.Sample.GetAll();
            List<IGrouping<DateTime, Sample>> samplesNotAnalyzedByDate = samples.Where(s => !s.SampleAnalisysDone && s.SampleAnalisysDate == null).GroupBy(x => x.SampleAnalisysExpectedDate).OrderByDescending(x => x.Key).ToList();

            if (samplesNotAnalyzedByDate.Any())
            {
                IGrouping<DateTime, Sample> lastGroupByDate = samplesNotAnalyzedByDate.First();
                if (lastGroupByDate.Count() < 3)
                {
                    int amountToFill = 3 - lastGroupByDate.Count();
                    List<Sample> samplesToInsertOnLastGroup = solicitation.Samples.Take(amountToFill).ToList();

                    foreach (var sample in samplesToInsertOnLastGroup)
                    {
                        sample.SampleAnalisysExpectedDate = lastGroupByDate.Key;
                    }
                }
                AssignExpectedAnalisysDate(ref solicitation, samplesNotAnalyzedByDate.First().Key);
            }
            else
                AssignExpectedAnalisysDate(ref solicitation);

        }

        private void AssignExpectedAnalisysDate(ref Solicitation solicitation, DateTime lastOccupiedDay = new DateTime())
        {
            DateTime nextWorkingDay;
            if (lastOccupiedDay == new DateTime())
                lastOccupiedDay = DateTime.Now;

            int counter = 0;

            nextWorkingDay = DateUtil.GetNextWorkingDay(lastOccupiedDay);
            foreach (var sample in solicitation.Samples.Where(s => s.SampleAnalisysExpectedDate == new DateTime()))
            {
                if (counter == 3)
                {
                    lastOccupiedDay = nextWorkingDay;
                    nextWorkingDay = DateUtil.GetNextWorkingDay(lastOccupiedDay);
                    counter = 0;
                }
                sample.SampleAnalisysExpectedDate = nextWorkingDay;
                counter++;
            }
        }

        public async Task<Result<DataTableReturn<Solicitation>>> GetSolicitations(int page, int pageSize, string loggedUserId, string? requesterId, int? solicitationTypeId, int? analisysTypeId, bool? resultsDelivered, DateTime? initialDate, DateTime? finalDate)
        {
            Result<DataTableReturn<Solicitation>> result = new Result<DataTableReturn<Solicitation>>();
            User? user = _repository.User.GetById(loggedUserId);

            if (user == null)
                result.Message = "User not found.";
            if (user?.RoleId == (int)RolesEnum.User)
                result.Message = "User not authorized to mark samples as received.";
            else
            {
                //result.Return = await _repository.Solicitation.GetSolicitations(page, pageSize, requesterId, solicitationTypeId, analisysTypeId, resultsDelivered, initialDate, finalDate);
                result.Success = true;
            }

            return result;
        }

        public Task<Result<Solicitation>> GetSolicitationDetails(string solicitationId)
        {
            //return Task.FromResult(_repository.Solicitation.GetSolicitation(solicitationId));
            throw new NotImplementedException();
        }
    }
}
