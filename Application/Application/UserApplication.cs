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

        public void EndSession(string token)
        {
            _repository.APIJWTSession.EndSession(token);
            _repository.SaveChanges();
        }

        public async Task<APIJWTSession> GetSessionData(string token)
        {
           return await _repository.APIJWTSession.GetSession(token);
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
            }

            return result;
        }

        public async Task<Result<APIJWTSession>> UserLogin(string email, string password)
        {
            Result<APIJWTSession> result = new Result<APIJWTSession>();

            Result<User> loginResult = _repository.UserRepository.GetUserByEmail(email);
            User? user = loginResult.Return;

            if(!loginResult.Success)
                result.Message = loginResult.Message;
            else if (password != user.EncryptedPassword)
                result.Message = "Incorrect password";
            else
            {
                _repository.UserRepository.LoginUser(user);
                result.Return = await _repository.APIJWTSession.StartSession(user);
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
                _repository.UserRepository.Delete(user);
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
