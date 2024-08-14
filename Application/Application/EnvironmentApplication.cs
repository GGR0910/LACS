using Application.Interface;
using Data.Interface;
using Domain;
using Domain.Entities;
using Domain.Enum;
using Domain.Util;
using Microsoft.Extensions.Configuration;
using Environment = Domain.Entities.Environment;

namespace Application.Application
{
    public class EnvironmentApplication : BaseApplication<Domain.Entities.Environment>, IEnvironmentApplication
    {
        public EnvironmentApplication(IUnitOfWorkRepository repository, IConfiguration configuration) : base(repository, configuration)
        {
        }

        public Task<Result<Environment>> Register(string name, string document, string departmentName, string laboratoryAdress, string laboratoryEmail, string laboratoryContactInfo, string countryName, string userUserName, string userEmail, User? loggedUser)
        {
            Environment? environment = _repository.EnvironmentRepository.GetEnvironmentByDocument(document);
            User? startUser = _repository.UserRepository.GetUserByEmail(userEmail);
            Result<Environment> result = new Result<Environment>();

            if (loggedUser.RoleId != (int)RolesEnum.SuperAdmin)
                result.Message = "User not authorized to register new users";
            else if (environment != null)
                result.Message = "Environment already registred";
            else if (startUser != null)
                result.Message = "User already exists";
            else
            {
                environment = new Environment(loggedUser.Id, name, document, laboratoryAdress, laboratoryContactInfo, laboratoryEmail, departmentName, countryName, userUserName);  
                startUser = new User(loggedUser.Id,userUserName, userEmail, "BAH", departmentName,(int)RolesEnum.Admin, environment.Id);

                _repository.UserRepository.Add(startUser);
                _repository.EnvironmentRepository.Add(environment);

                //Enviar email de confirmação e de boas vindas pro usuário

                result.Success = true;
                result.Return = environment;
            }

            return Task.FromResult(result);
        }

        public Task<Environment> GetDetails(string environmentId)
        { 
            return Task.FromResult(_repository.EnvironmentRepository.GetById(environmentId));
        }

        public Task<Result<object>> Delete(string environmentId, User? loggedUser)
        {
            Result<object> result = new Result<object>();
            Environment? environment = _repository.EnvironmentRepository.GetById(environmentId);

            if (loggedUser.RoleId != (int)RolesEnum.SuperAdmin)
                result.Message = "User not authorized to delete environments";
            else if (environment == null)
                result.Message = "Environment not found";
            else
            {
                environment.Delete(loggedUser.Id);
                _repository.EnvironmentRepository.Update(environment);

                result.Success = true;
            }

            return Task.FromResult(result);
        }

        public Task<Result<DataTableReturn<Environment>>> GetEnviromentsAsync(int page, int pageSize, User? loggedUser, string? name, string? document, string? countryName, string? departmentName, DateTime? initialDate, DateTime? finalDate)
        {
            Result<DataTableReturn<Environment>> result = new Result<DataTableReturn<Environment>>();
            
            if (loggedUser?.RoleId == (int)RolesEnum.User)
                result.Message = "User not authorized to get users.";
            else
            {
                result.Return = _repository.EnvironmentRepository.GetEnvironments(page, pageSize, name, document, countryName, departmentName, initialDate, finalDate);
                result.Success = true;
            }

            return Task.FromResult(result);
        }
    }
}
