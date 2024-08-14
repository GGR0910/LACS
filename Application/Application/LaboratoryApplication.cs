using Application.Interface;
using Data.Interface;
using Domain;
using Domain.Entities;
using Domain.Enum;
using Domain.Util;
using Microsoft.Extensions.Configuration;
using Laboratory = Domain.Entities.Laboratory;

namespace Application.Application
{
    public class LaboratoryApplication : BaseApplication<Domain.Entities.Laboratory>, ILaboratoryApplication
    {
        public LaboratoryApplication(IUnitOfWorkRepository repository, IConfiguration configuration) : base(repository, configuration)
        {
        }

        public Task<Result<Laboratory>> Register(string name, string responsibleDocument, string departmentName, string laboratoryAdress, string laboratoryEmail, string laboratoryContactInfo, string countryName, string userUserName, string userEmail, User? loggedUser)
        {
            User? startUser = _repository.UserRepository.GetUserByEmail(userEmail);
            Result<Laboratory> result = new Result<Laboratory>();

            if (loggedUser.RoleId != (int)RolesEnum.SuperAdmin)
                result.Message = "User not authorized to register new laboratory";
            else if (startUser != null)
                result.Message = "User already exists";
            else
            {
                Laboratory? laboratory = new Laboratory(loggedUser.Id, name, responsibleDocument, laboratoryAdress, laboratoryContactInfo, laboratoryEmail, departmentName, countryName, userUserName);  
                startUser = new User(loggedUser.Id,userUserName, userEmail, "BAH", departmentName,(int)RolesEnum.Admin, laboratory.Id);
                loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.Id, (int)UserInteractionTypeEnum.Update, "Laboratory Edited", laboratory.Id, loggedUser.LaboratoryId));
                
                _repository.UserRepository.Add(startUser);
                _repository.LaboratoryRepository.Add(laboratory);

                //Enviar email de confirmação e de boas vindas pro usuário

                result.Success = true;
                result.Return = laboratory;
            }

            return Task.FromResult(result);
        }

        public Task<Laboratory> GetDetails(string environmentId)
        { 
            return Task.FromResult(_repository.LaboratoryRepository.GetById(environmentId));
        }

        public Task<Result<object>> Delete(string environmentId, User? loggedUser)
        {
            Result<object> result = new Result<object>();
            Laboratory? laboratory = _repository.LaboratoryRepository.GetById(environmentId);

            if (loggedUser.RoleId != (int)RolesEnum.SuperAdmin)
                result.Message = "User not authorized to delete environments";
            else if (laboratory == null)
                result.Message = "Environment not found";
            else
            {
                laboratory.Delete(loggedUser.Id);
                loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.Id, (int)UserInteractionTypeEnum.Update, "Laboratory deleted", laboratory.Id, loggedUser.LaboratoryId));
                _repository.LaboratoryRepository.Update(laboratory);

                result.Success = true;
            }

            return Task.FromResult(result);
        }

        public Task<Result<DataTableReturn<Laboratory>>> GetLaboratorysAsync(int page, int pageSize, User? loggedUser, string? name, string? document, string? countryName, string? departmentName, DateTime? initialDate, DateTime? finalDate)
        {
            Result<DataTableReturn<Laboratory>> result = new Result<DataTableReturn<Laboratory>>();
            
            if (loggedUser?.RoleId == (int)RolesEnum.User)
                result.Message = "User not authorized to get users.";
            else
            {
                result.Return = _repository.LaboratoryRepository.GetLaboratorys(page, pageSize, name, document, countryName, departmentName, initialDate, finalDate);
                result.Success = true;
            }

            return Task.FromResult(result);
        }

        public Task<Result<Laboratory>> Edit(string name, string laboratoryAdress, string laboratoryContactInfo, string laboratoryEmail, string departmentName, string countryName, User loggedUser)
        {
            Result<Laboratory> result = new Result<Laboratory>();

            if (!loggedUser.IsAdmin)
                result.Message = "User not authorized to edit users";
            else
            {
                Laboratory? laboratory = _repository.LaboratoryRepository.GetById(loggedUser.LaboratoryId);
                if (laboratory == null)
                    result.Message = "User not found";
                else
                {
                    laboratory.Edit(name,laboratoryAdress, laboratoryContactInfo, laboratoryEmail, departmentName, countryName, loggedUser.Id);
                    loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.Id, (int)UserInteractionTypeEnum.Update, "Laboratory Edited", laboratory.Id, loggedUser.LaboratoryId));
                    _repository.LaboratoryRepository.Update(laboratory);
                    result.Success = true;
                    result.Return = laboratory;
                }
            }
            return Task.FromResult(result);
        }
    }
}
