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

        public Task<User> GetDetails(string userId)
        {
            return Task.FromResult(_repository.User.GetById(userId));
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            return Task.FromResult(_repository.User.GetAll());
        }

        public async Task<Result<User>> Register(string userName, string email, string password, int roleId, string departamentName, User loggedUser)
        {
            User? user = _repository.User.GetUserByEmail(email);
            Result<User> result = new Result<User>();

            if(!loggedUser.IsAdmin)
                result.Message = "User not authorized to register new users";
            else if (user != null)
                result.Message = "E-mail already registred";
            else
            {
                user = new User(loggedUser.Id, userName, email, password,departamentName, roleId, loggedUser.LaboratoryId);
                UserInteraction interaction = new UserInteraction(loggedUser.Id, (int)UserInteractionTypeEnum.Register, $"Registred new User",user.Id, loggedUser.LaboratoryId);
                loggedUser.UserInteractions.Add(interaction);
                _repository.User.Add(user);

                //Enviar email de confirmação e de boas vindas pro usuário

                result.Success = true;
                result.Return = user;
            }

            return result;
        }

        public async Task<Result<Dictionary<string, User>>> Login(string email, string password)
        {
            Result<Dictionary<string, User>> result = new Result<Dictionary<string, User>>();

            User? user = _repository.User.GetUserByEmail(email);

            if(user == null)
                result.Message = "User not found";
            else if (password != user.EncryptedPassword)
                result.Message = "Incorrect password";
            else if(!user.EmailConfirmed || user.Deleted)
                result.Message = "User not authorized to login";
            else
            {

                _repository.User.LoginUser(user);
                string token = GenerateJwtToken(user);
                result.Return = new Dictionary<string, User> { { token, user } };
                result.Success = true;
            }

            return result;
        }

        public Task<Result<object>> Delete(string userId, User loggedUser)
        {
            Result<object> result = new Result<object>();
            User? user = _repository.User.GetById(userId);

            if(!loggedUser.IsAdmin)
                result.Message = "User not authorized to delete users";
            else if (user == null)
                result.Message = "User not found";
            else
            {
                user.Delete(loggedUser.Id);
                loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.Id, (int)UserInteractionTypeEnum.Delete, "User Deleted", user.Id, loggedUser.LaboratoryId));
                _repository.User.Update(user);

                result.Success = true;
            }
           
            return Task.FromResult(result);
        }

        public Task<Result<DataTableReturn<User>>> GetUsersAsync(int page, int pageLength, User loggedUser, string? userName, string? email, int? roleId, string? departamentName)
        {
            Result<DataTableReturn<User>> result = new Result<DataTableReturn<User>>();            
            if (loggedUser?.RoleId == (int)RolesEnum.User)
                result.Message = "User not authorized to get users.";
            else
            {
                result.Return = _repository.User.GetUsers(page, pageLength, loggedUser.LaboratoryId ,userName, email, roleId, departamentName);
                result.Success = true;
            }

            return Task.FromResult(result);
        }

        public Task<Result<User>> Edit(string id, string userName, string email, int roleId, string departamentName, User loggedUser)
        {
            Result<User> result = new Result<User>();
            if(!loggedUser.IsAdmin)
                result.Message = "User not authorized to edit users";
            else
            {
                User? user = _repository.User.GetById(id);
                if (user == null)
                    result.Message = "User not found";
                else
                {
                    user.Edit(userName, email, roleId, departamentName, loggedUser.Id);
                    loggedUser.UserInteractions.Add(new UserInteraction(loggedUser.Id, (int)UserInteractionTypeEnum.Update, "User Edited", user.Id, loggedUser.LaboratoryId));
                    _repository.User.Update(user);
                    result.Success = true;
                    result.Return = user;
                }
            }
            return Task.FromResult(result);
        }
    }
}
