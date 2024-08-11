using Application.Interface;
using Azure;
using Data.Interface;
using Domain;
using Domain.Entities;
using Domain.Enum;
using Domain.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class SampleApplication : BaseApplication<Sample>, ISampleApplication
    {
        public SampleApplication(IUnitOfWorkRepository repository, IConfiguration configuration) : base(repository, configuration)
        {
        }

        public Result<object> AssignSampleToAnalist(List<string> SampleIds, string AnalistId, string LoggedUserId, bool AreSamplesAnalized)
        {
            Result<object> result = new Result<object>();
            User? loggedUser = _repository.UserRepository.GetById(LoggedUserId);
            User? analist = _repository.UserRepository.GetById(AnalistId);

            if (loggedUser == null)
                result.Message = "User not found";
            else if (loggedUser.RoleId == (int)RolesEnum.User)
                result.Message += "User does not have permission to assign samples";
            else if (analist == null)
                result.Message += "Analist not found";
            else
            {
                foreach (var sampleId in SampleIds)
                {
                    Sample? sample = _repository.SampleRepository.GetById(sampleId);
                    if(sample == null)
                    {
                        result.Message += $"Sample {sampleId} not found";
                        break;
                    }

                    if (AreSamplesAnalized)
                    {
                        if (!sample.SampleAnalisysDone)
                        {
                            sample.SampleAnalisysDone = true;
                            sample.SampleAnalisysDate = DateTime.Now.Date != sample.SampleAnalisysExpectedDate.Date? DateTime.Now : sample.SampleAnalisysExpectedDate;
                        }
                    }
                    sample.Analist = analist;
                    analist.Samples.Add(sample);
                }


                if (result.Message.IsNullOrEmpty()) { 
                    _repository.UserRepository.Update(analist);
                    _repository.SaveChanges();
                    result.Success = true;
                }
            }

            return result;
        }

        public  Task<Result<DataTableReturn<Sample>>> GetSamplesAsync(int page, int pageSize, string loggedUserId, string? requesterId, int? sampleTypeId, int? samplePhisicalStateId, bool? analized, DateTime? initialDate, DateTime? finalDate)
        {
            Result<DataTableReturn<Sample>> result = new Result<DataTableReturn<Sample>>();
            User? user = _repository.UserRepository.GetById(loggedUserId);

            if (user == null)
                result.Message = "User not found.";
            if (user?.RoleId == (int)RolesEnum.User)
                result.Message = "User not authorized to get samples.";
            else
            {
                result.Return =  _repository.SampleRepository.GetSamples(page, pageSize, requesterId, sampleTypeId, samplePhisicalStateId, analized, initialDate, finalDate);
                result.Success = true;
            }

            return Task.FromResult(result);
        }

    }
}
