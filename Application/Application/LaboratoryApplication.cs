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
            User? startUser = _repository.User.GetUserByEmail(userEmail);
            Result<Laboratory> result = new Result<Laboratory>();


            if (loggedUser.UserName != "SystemUser")
                result.Message = "User not authorized to register new laboratory";
            else if(userUserName == "SystemUser")
                result.Message = "User name not allowed";
            else 
            {
                if (startUser == null)
                {
                    startUser = new User(null, userUserName, userEmail, "BAH", departmentName);
                    _repository.User.Add(startUser);
                }

                Laboratory? laboratory = new Laboratory(name, responsibleDocument, laboratoryAdress, laboratoryContactInfo, laboratoryEmail, departmentName, countryName, userUserName);
                _repository.Laboratory.Add(laboratory);

                //Enviar email de confirmação e de boas vindas pro usuário
                _repository.SaveChanges();

                UserLaboratory userLaboratory = new UserLaboratory(null, (int)RolesEnum.Admin, startUser.Id, laboratory.Id);
                _repository.UserLaboratory.Add(userLaboratory);

                startUser.CurrentUserLaboratory = startUser.UserLaboratories.First();
                _repository.User.Update(startUser);

                result.Success = true;
                result.Return = laboratory;

            }

            return Task.FromResult(result);
        }

        public Task<Laboratory> GetDetails(string environmentId)
        { 
            return Task.FromResult(_repository.Laboratory.GetById(environmentId));
        }

        public Task<Result<object>> Delete(string environmentId, User? loggedUser)
        {
            Result<object> result = new Result<object>();
            Laboratory? laboratory = _repository.Laboratory.GetById(environmentId);
            
            if(loggedUser.UserName != "SystemUser")
                result.Message = "User not authorized to delete laboratorys";
            else if (laboratory == null)
                result.Message = "Environment not found";
            else
            {
                laboratory.Delete();
                _repository.Laboratory.Update(laboratory);

                result.Success = true;
            }

            return Task.FromResult(result);
        }

        public Task<Result<DataTableReturn<Laboratory>>> GetLaboratorysAsync(int page, int pageSize, User? loggedUser, string? name, string? document, string? countryName, string? departmentName, DateTime? initialDate, DateTime? finalDate)
        {
            Result<DataTableReturn<Laboratory>> result = new Result<DataTableReturn<Laboratory>>();

            result.Return = _repository.Laboratory.GetLaboratorys(page, pageSize, name, document, countryName, departmentName, initialDate, finalDate);
            result.Success = true;

            return Task.FromResult(result);
        }

        public Task<Result<Laboratory>> Edit(string name, string laboratoryAdress, string laboratoryContactInfo, string laboratoryEmail, string departmentName, string countryName, User loggedUser)
        {
            Result<Laboratory> result = new Result<Laboratory>();

            if (!loggedUser.CurrentUserLaboratory.IsAdmin)
                result.Message = "User not authorized to edit users";
            else
            {
                Laboratory? laboratory = _repository.Laboratory.GetById(loggedUser.CurrentUserLaboratory.LaboratoryId);
                if (laboratory == null)
                    result.Message = "Laboratory not found";
                else
                {
                    laboratory.Edit(name,laboratoryAdress, laboratoryContactInfo, laboratoryEmail, departmentName, countryName, loggedUser.CurrentUserLaboratoryId);
                    loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.Id, (int)UserInteractionTypeEnum.Update, "Laboratory Edited", laboratory.Id));
                    _repository.Laboratory.Update(laboratory);
                    result.Success = true;
                    result.Return = laboratory;
                }
            }
            return Task.FromResult(result);
        }
    }
}
