using Application.Interface;
using Data.Interface;
using Domain;
using Domain.Entities;
using Domain.Enum;
using Domain.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Application
{
    public class UserLaboratoryApplication : BaseApplication<UserLaboratory>, IUserLaboratoryApplication
    {
        public UserLaboratoryApplication(IUnitOfWorkRepository repository, IConfiguration configuration) : base(repository, configuration)
        {
        }

        public async Task<Result<object>> ChangeStatus(string userId, User loggedUser)
        {
            Result<object> result = new Result<object>();
            User? user = _repository.User.GetUserById(userId);

            if (!loggedUser.CurrentUserLaboratory!.IsAdmin)
            {
                result.Message = "Not authorized";
                return result;
            }

            if (user == null)
            {
                result.Message = "User not found";
                return result;
            }

            UserLaboratory? userLaboratory = user.UserLaboratories.FirstOrDefault(x => x.LaboratoryId == loggedUser.CurrentUserLaboratory.LaboratoryId);
            if (userLaboratory == null)
                result.Message = "User do not belongs to laboratory";
            else
            {
                userLaboratory.ChangeStatus(loggedUser.CurrentUserLaboratory.Id);
                loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.CurrentUserLaboratory.Id, (int)UserInteractionTypeEnum.DeleteStatuschanged, $"User changed status to {userLaboratory.Deleted}", userLaboratory.Id, loggedUser.CurrentUserLaboratory.LaboratoryId));

                _repository.User.Update(user);

                result.Success = true;
                _repository.SaveChanges();
            }

            return result;
        }

        public async Task<Result<UserLaboratory>> Edit(string id, string userName, string email, int roleId, string departamentName, User loggedUser)
        {
            Result<UserLaboratory> result = new Result<UserLaboratory>();
            User? user = _repository.User.GetById(id);
            UserLaboratory? userLaboratory = user!.UserLaboratories.FirstOrDefault(x => x.LaboratoryId == loggedUser.CurrentUserLaboratory.LaboratoryId && !x.Deleted);

            if (!loggedUser.CurrentUserLaboratory!.IsAdmin)
            {
                result.Message = "Not authorized";
                return result;
            }

            if (userName == "SystemUser")
            {
                result.Message = "User name not allowed";
                return result;
            }
            
            else if (user == null)
            {
                result.Message = "User not found";
                return result;
            }

            if (userLaboratory == null)
                result.Message = "User not found in this laboratory";
            else
            {
                userLaboratory.Edit(userName, roleId, departamentName, loggedUser.CurrentUserLaboratory.Id);
                loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.CurrentUserLaboratory.Id, (int)UserInteractionTypeEnum.Update, "User Edited", user.Id, loggedUser.CurrentUserLaboratory.LaboratoryId));
                _repository.User.Update(user);

                result.Success = true;
                result.Return = userLaboratory;
                _repository.SaveChanges();
            }

            return result;
        }

        public async Task<Result<UserLaboratory>> GetDetails(string userId)
        {
            Result<UserLaboratory> result = new Result<UserLaboratory>();
            UserLaboratory? userLaboratory = await _repository.UserLaboratory.GetUserLaboratory(userId);

            if (userLaboratory == null)
                result.Message = "User not found on laboratory";
            else
            {
                result.Success = true;
                result.Return = userLaboratory;
            }

            return result;
        }

        public async Task<Result<DataTableReturn<UserLaboratory>>> GetUsers(int page, int pageLength, User loggedUser, string? userName, string? email, int? roleId, string? departamentName)
        {
            Result<DataTableReturn<UserLaboratory>> result = new Result<DataTableReturn<UserLaboratory>>();
            if (loggedUser?.CurrentUserLaboratory!.RoleId == (int)RolesEnum.User)
                result.Message = "Not authorized";
            else
            {
                result.Return = await _repository.UserLaboratory.GetUsers(page, pageLength, loggedUser.CurrentUserLaboratory!.LaboratoryId, userName, email, roleId, departamentName);
                result.Success = true;
            }

            return result;
        }

        public async Task<Result<UserLaboratory>> Register(string userName, string email, int roleId, string departamentName, string document ,User loggedUser)
        {
            User? user = _repository.User.GetUserByEmail(email);
            UserLaboratory? userLaboratory = null;
            Result<UserLaboratory> result = new Result<UserLaboratory>();

            if (!loggedUser.CurrentUserLaboratory!.IsAdmin || loggedUser.UserName != "SystemUser")
            {
                result.Message = "Not Authorized";
                return result;
            }

            if (!Enum.IsDefined(typeof(RolesEnum), roleId))
            {
                result.Message = "Invalid Role";
                return result;
            }

            if (departamentName.IsNullOrEmpty())
                departamentName = loggedUser.CurrentUserLaboratory.Laboratory.DefaultDepartamentName;

            if (user != null)
            {
                userLaboratory = user.UserLaboratories.FirstOrDefault(x => x.LaboratoryId == loggedUser.CurrentUserLaboratory.LaboratoryId);
                if (userLaboratory == null)
                {
                    user.UserLaboratories.Add(new UserLaboratory(loggedUser.CurrentUserLaboratory.Id, roleId, user.Id, loggedUser.CurrentUserLaboratory.LaboratoryId, false, userName, departamentName));
                    _repository.User.Update(user);
                }
                else
                {
                    if (userLaboratory.Deleted)
                    {
                        userLaboratory!.ChangeStatus(loggedUser.CurrentUserLaboratory.Id);
                        loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.CurrentUserLaboratory.Id, (int)UserInteractionTypeEnum.Update, "Gave acess again", userLaboratory.Id, loggedUser.CurrentUserLaboratory.LaboratoryId));
                        _repository.UserLaboratory.Update(userLaboratory);
                        _repository.User.Update(loggedUser);
                    }
                }
            }
            else
            {

                user = new User(loggedUser.CurrentUserLaboratory.Id, userName, email, loggedUser.CurrentUserLaboratory.Laboratory.DefaultPassword,document);
                userLaboratory = new UserLaboratory(loggedUser.CurrentUserLaboratory.Id, roleId, user.Id, loggedUser.CurrentUserLaboratory.LaboratoryId, true, userName, departamentName);

                loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.CurrentUserLaboratory.Id, (int)UserInteractionTypeEnum.Register, $"Registred new User", user.Id, loggedUser.CurrentUserLaboratory.LaboratoryId));
                _repository.User.Add(user);
                _repository.UserLaboratory.Add(userLaboratory);

            }

            //Enviar email de adição do usuário ao ambiente 


            if (string.IsNullOrEmpty(result.Message))
            {
                result.Success = true;
                result.Return = userLaboratory!;
                _repository.SaveChanges();
            }
            return result;
        }
    }
}
