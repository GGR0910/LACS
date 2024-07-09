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
    public class UserApplication : BaseApplication<User>, IUserApplication
    {
        public UserApplication(IUnitOfWorkRepository repository, IConfiguration configuration) : base(repository, configuration)
        {
        }

        public Task<User> GetUserData(string userId)
        {
            return Task.FromResult(_repository.UserRepository.GetById(userId));
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            return Task.FromResult(_repository.UserRepository.GetAll());
        }

        public async Task<Result<User>> RegisterUser(string userName, string email, string password, string creatorId)
        {
            User? user = _repository.UserRepository.GetUserByEmail(email).Return;
            Result<User> result = new Result<User>();

            if (user != null)
                result.Message = "E-mail already registred";
            else
            {
                user = new User(creatorId, userName, email, password);
                _repository.UserRepository.Add(user);
                _repository.SaveChanges();
                result.Success = true;
                result.Return = user;
            }

            return result;
        }

        public async Task<Result<Dictionary<string, User>>> UserLogin(string email, string password)
        {
            Result<Dictionary<string, User>> result = new Result<Dictionary<string, User>>();

            Result<User> loginResult = _repository.UserRepository.GetUserByEmail(email);
            User? user = loginResult.Return;

            if(!loginResult.Success)
                result.Message = loginResult.Message;
            else if (password != user.EncryptedPassword)
                result.Message = "Incorrect password";
            else
            {
                _repository.UserRepository.LoginUser(user);
                string token = GenerateJwtToken(user);
                result.Return = new Dictionary<string, User> { { token, user } };
                result.Success = true;
                _repository.SaveChanges();
            }

            return result;
        }

        Task<Result<User>> IUserApplication.DeleteUser(string userId)
        {
            Result<User> result = new Result<User>();
            User? user = _repository.UserRepository.GetById(userId);
            if (user != null)
            {
                user.Deleted = true;
                _repository.UserRepository.Update(user);
                result.Success = true;
                _repository.SaveChanges();
            }
            else
            {
                result.Success = false;
                result.Message = "User not found";
            }
            return Task.FromResult(result);
        }
    }
}
