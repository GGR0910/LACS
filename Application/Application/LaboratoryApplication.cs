using Application.Interface;
using Data.Interface;
using Domain;
using Domain.Entities;
using Domain.Enum;
using Domain.Util;
using Microsoft.Extensions.Configuration;

namespace Application.Application
{
    public class LaboratoryApplication : BaseApplication<Domain.Entities.Laboratory>, ILaboratoryApplication
    {
        public LaboratoryApplication(IUnitOfWorkRepository repository, IConfiguration configuration) : base(repository, configuration)
        {
        }

        public async Task<Result<Laboratory>> Register(string name, string responsibleDocument, string departmentName, string laboratoryAdress, string laboratoryEmail, string laboratoryContactInfo, string countryName, string userUserName, string userEmail, string userDocument, string laboratoryDocument, User loggedUser)
        {
            User? startUser = _repository.User.GetUserByEmail(userEmail);
            Result<Laboratory> result = new Result<Laboratory>();
            Laboratory? laboratory = _repository.Laboratory.GetLaboratoryByDocument(responsibleDocument);

            //Falta por validação de documentos

            if(laboratory != null)
            {
                result.Message = "Laboratory already registered";
                return result;
            }

            if (loggedUser.UserName != "SystemUser")
            {
                result.Message = "User not authorized to register new laboratory";
                return result;
            }
                
            if (userUserName == "SystemUser")
            {
                result.Message = "User name not allowed";
                return result;
            }

            if (startUser == null)
            {
                startUser = new User(null, userUserName, userEmail, "BAH", userDocument);
                _repository.User.Add(startUser);
            }

            laboratory = new Laboratory(name, responsibleDocument, laboratoryAdress, laboratoryContactInfo, laboratoryEmail, countryName, userUserName, laboratoryDocument);
            UserLaboratory userLaboratory = new UserLaboratory(null, (int)RolesEnum.Admin, startUser.Id, laboratory.Id, true, "Owner",startUser.UserName);

            _repository.Laboratory.Add(laboratory);
            _repository.UserLaboratory.Add(userLaboratory);

            loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.Id, (int)UserInteractionTypeEnum.Register, "Laboratory created", laboratory.Id));

            //Enviar email de confirmação e de boas vindas pro usuário
            result.Success = true;
            result.Return = laboratory;

            _repository.SaveChanges();

            return result;
        }
        public async Task<Result<Laboratory>> GetDetails(string environmentId)
        {
            Result<Laboratory> result = new Result<Laboratory>();
            Laboratory? laboratory =  _repository.Laboratory.GetById(environmentId);

            if (laboratory == null)
                result.Message = "Laboratory not found";
            else
            {
                result.Success = true;
                result.Return = laboratory;
            }

            return result;
        }

        public async Task<Result<object>> Delete(string environmentId, User? loggedUser)
        {
            Result<object> result = new Result<object>();
            Laboratory? laboratory = _repository.Laboratory.GetById(environmentId);

            if (loggedUser.UserName != "SystemUser")
            {
                result.Message = "User not authorized";
                return result;
            }

            if (laboratory == null)
            {
                result.Message = "Laboratory not found";
                return result;
            }

            laboratory.ChangeStatus(null);
            laboratory.UserLaboratories.ToList().ForEach(x => x.ChangeStatus(null));
            _repository.Laboratory.Update(laboratory);

            loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.Id, (int)UserInteractionTypeEnum.Update, "Laboratory Deleted", laboratory.Id));

            result.Success = true;
            _repository.SaveChanges();
            return result;
        }
        

        public async Task<Result<DataTableReturn<Laboratory>>> GetLaboratorysAsync(int page, int pageSize, User? loggedUser, string? name, string? document, string? countryName, string? departmentName, DateTime? initialDate, DateTime? finalDate)
        {
            Result<DataTableReturn<Laboratory>> result = new Result<DataTableReturn<Laboratory>>();
            result.Return = _repository.Laboratory.GetLaboratorys(page, pageSize, name, document, countryName, departmentName, initialDate, finalDate);
            result.Success = true;
            return result;
        }

        public async Task<Result<Laboratory>> Edit(string name, string laboratoryAdress, string laboratoryContactInfo, string laboratoryEmail, string departmentName, string countryName, User loggedUser)
        {
            Result<Laboratory> result = new Result<Laboratory>();
            if (!loggedUser.CurrentUserLaboratory.IsAdmin)
            {
                result.Message = "User not authorized to edit users";
                return result;
            }
            else
            {
                Laboratory? laboratory = _repository.Laboratory.GetById(loggedUser.CurrentUserLaboratory.LaboratoryId);
                if (laboratory == null)
                    result.Message = "Laboratory not found";
                else
                {
                    laboratory.Edit(name, laboratoryAdress, laboratoryContactInfo, laboratoryEmail, countryName, loggedUser.CurrentUserLaboratory.Id);

                    loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.Id, (int)UserInteractionTypeEnum.Update, "Laboratory Edited", laboratory.Id));
                    _repository.Laboratory.Update(laboratory);

                    result.Success = true;
                    result.Return = laboratory;
                    _repository.SaveChanges();
                }
            }
            return result;
        }
    }
}
