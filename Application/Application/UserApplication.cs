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
                result.Message = "Not authorized";
                return result;
            }

            _repository.User.LoginUser(user);
            string token = GenerateJwtToken(user);
            result.Return = new Dictionary<string, User> { { token, user } };
            result.Success = true;

            return result;
        }

        public async Task<Result<DataTableReturn<User>>> GetUsers(int page, int pageLength, User loggedUser, string? userName, string? email, int? roleId)
        {
            Result<DataTableReturn<User>> result = new Result<DataTableReturn<User>>();
            if (loggedUser?.CurrentUserLaboratory!.RoleId == (int)RolesEnum.User)
                result.Message = "Not authorized";
            else
            {
                result.Return = await _repository.User.GetUsers(page, pageLength, loggedUser.CurrentUserLaboratory!.LaboratoryId, userName, email, roleId);
                result.Success = true;
            }

            return result;
        }

    }
}
