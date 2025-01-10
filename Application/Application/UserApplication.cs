using Application.Interface;
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
    public class UserApplication : BaseApplication<User>, IUserApplication
    {
        public UserApplication(IUnitOfWorkRepository repository, IConfiguration configuration) : base(repository, configuration)
        {
        }

        public Task<Result<User>> GetDetails(string userId)
        {
            Result<User> result = new Result<User>();
            User? user = _repository.User.GetUserById(userId);

            if(user == null)
                result.Message = "User not found";
            else
            {
                result.Success = true;
                result.Return = user;
            }

            return Task.FromResult(result);
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            return Task.FromResult(_repository.User.GetAll());
        }

        public async Task<Result<User>> Register(string userName, string email, string password, int roleId, string departamentName, User loggedUser)
        {
            User? user = _repository.User.GetUserByEmail(email);
            Result<User> result = new Result<User>();

            if (!loggedUser.CurrentUserLaboratory!.IsAdmin || userName != "SystemUser")
            {
                result.Message = "User not authorized to register new users";
                return result;
            }

            if (!Enum.IsDefined(typeof(RolesEnum), roleId))
            {
                result.Message = "Invalid Role";
                return result;
            }
               
            if (user != null)
            {
                if(user.Deleted)
                    user.ChangeStatus(loggedUser.CurrentUserLaboratory.Id);

                UserLaboratory? userLaboratory = user.UserLaboratories.FirstOrDefault(x => x.LaboratoryId == loggedUser.CurrentUserLaboratory.LaboratoryId);
                if (userLaboratory == null)
                {
                    user.UserLaboratories.Add(new UserLaboratory(loggedUser.CurrentUserLaboratory.Id, roleId, user.Id, loggedUser.CurrentUserLaboratory.LaboratoryId, false));
                    _repository.User.Update(user);
                }
                else
                {
                    if (userLaboratory.Deleted)
                    {
                        userLaboratory!.UnDelete(loggedUser.CurrentUserLaboratory.Id);
                        loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.CurrentUserLaboratory.Id, (int)UserInteractionTypeEnum.Update, "Gave acess again", userLaboratory.Id, loggedUser.CurrentUserLaboratory.LaboratoryId));
                        _repository.UserLaboratory.Update(userLaboratory);
                        _repository.User.Update(loggedUser);
                    }
                }
            }
            else
            {
                user = new User(loggedUser.CurrentUserLaboratory.Id, userName, email, password, departamentName);
                UserLaboratory userLaboratory = new UserLaboratory(loggedUser.CurrentUserLaboratory.Id, roleId, user.Id, loggedUser.CurrentUserLaboratory.LaboratoryId, true);

                loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.CurrentUserLaboratory.Id, (int)UserInteractionTypeEnum.Register, $"Registred new User", user.Id, loggedUser.CurrentUserLaboratory.LaboratoryId));
                _repository.User.Add(user);
                _repository.UserLaboratory.Add(userLaboratory);
                
            }

            //Enviar email de adição do usuário ao ambiente 


            if (string.IsNullOrEmpty(result.Message))
            {
                result.Success = true;
                result.Return = user;
            }
            return result;
        }

        public async Task<Result<Dictionary<string, User>>> Login(string email, string password)
        {
            Result<Dictionary<string, User>> result = new Result<Dictionary<string, User>>();

            User? user = _repository.User.GetUserByEmail(email);

            if (user == null)
            {
                result.Message = "User not found";
                return result;
            }
                
            if (password != user.EncryptedPassword)
            {
                result.Message = "Incorrect password";
                return result;
            }

            if (!user.EmailConfirmed || user.Deleted)
            {
                result.Message = "User not authorized to login";
                return result;
            }

            _repository.User.LoginUser(user);
            string token = GenerateJwtToken(user);
            result.Return = new Dictionary<string, User> { { token, user } };
            result.Success = true;

            return result;
        }

        public async Task<Result<object>> Delete(string userId, User loggedUser)
        {
            Result<object> result = new Result<object>();
            User? user = _repository.User.GetUserById(userId);

            if (!loggedUser.CurrentUserLaboratory!.IsAdmin)
            {
                result.Message = "User not authorized to delete users";
                return result;
            }
                
            if (user == null)
            {
                result.Message = "User not found";
                return result;
            }

            UserLaboratory? userLaboratory = user.UserLaboratories.FirstOrDefault(x => x.LaboratoryId == loggedUser.CurrentUserLaboratory.LaboratoryId);
            if (userLaboratory == null)
                result.Message = "User not found in this laboratory";
            else
            {
                userLaboratory.ChangeStatus(loggedUser.CurrentUserLaboratory.Id);
                loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.CurrentUserLaboratory.Id, (int)UserInteractionTypeEnum.Delete, "User Deleted", userLaboratory.Id, loggedUser.CurrentUserLaboratory.LaboratoryId));

                _repository.User.Update(user);
                result.Success = true;
            }

            return result;
        }

        public async Task<Result<DataTableReturn<User>>> GetUsersAsync(int page, int pageLength, User loggedUser, string? userName, string? email, int? roleId, string? departamentName)
        {
            Result<DataTableReturn<User>> result = new Result<DataTableReturn<User>>();
            if (loggedUser?.CurrentUserLaboratory!.RoleId == (int)RolesEnum.User)
                result.Message = "User not authorized to get users.";
            else
            {
                result.Return = await _repository.User.GetUsers(page, pageLength, loggedUser.CurrentUserLaboratory!.LaboratoryId, userName, email, roleId, departamentName);
                result.Success = true;
            }

            return result;
        }

        public async Task<Result<User>> Edit(string id, string userName, string email, int roleId, string departamentName, User loggedUser)
        {
            Result<User> result = new Result<User>();
            User? user = _repository.User.GetById(id);

            if (!loggedUser.CurrentUserLaboratory!.IsAdmin)
            {
                result.Message = "User not authorized to edit users";
                return result;
            }
                
            else if (user == null)
            {
                result.Message = "User not found";
                return result;
            }

            if (!user.UserLaboratories.Any(x => x.LaboratoryId == loggedUser.CurrentUserLaboratory.LaboratoryId && !x.Deleted))
                result.Message = "User not found in this laboratory";
            else
            {
                user.Edit(userName, email, roleId, departamentName, loggedUser.CurrentUserLaboratory.Id);
                loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.CurrentUserLaboratory.Id, (int)UserInteractionTypeEnum.Update, "User Edited", user.Id, loggedUser.CurrentUserLaboratory.LaboratoryId));
                _repository.User.Update(user);
                result.Success = true;
                result.Return = user;
            }

            return result;
        }

    }
}
