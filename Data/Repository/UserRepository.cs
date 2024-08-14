using Data.Context;
using Data.Interface;
using Domain;
using Domain.Entities;
using Domain.Enum;
using Domain.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext baseContext) : base(baseContext)
        {
        }

        public User? GetUserByEmail(string email) 
        { 
            return _context.Users.FirstOrDefault(u => u.Email == email && !u.Deleted);
        }

        public DataTableReturn<User> GetUsers(int page, int pageLength, string laboratoryId, string? userName, string? email, int? roleId, string? departamentName)
        {
            IQueryable<User> users = _context.Users.Where(u => u.LaboratoryId == laboratoryId && !u.Deleted);

            int recordsTotal = users.Count();

            if (!userName.IsNullOrEmpty())
                users = users.Where(u => u.UserName.Contains(userName));
            
            if (!email.IsNullOrEmpty())
                users = users.Where(u => u.Email.Contains(email));

            if (roleId.HasValue)
                users = users.Where(u => u.RoleId == roleId);

            if (!departamentName.IsNullOrEmpty())
                users = users.Where(u => u.DepartamentName.Contains(departamentName));

            users = users.OrderBy(u => u.UserName).Skip((page - 1) * pageLength).Take(pageLength);

            DataTableReturn<User> dataTableReturn = new DataTableReturn<User>()
            {
                Data = users.ToList(),
                RecordsTotal = recordsTotal,
                RecordsFiltered = users.Count(),
                Page = page
            };

            return dataTableReturn;
        }

        public void LoginUser(User user)
        {
            user.UserInteractions.Add(new UserInteraction(user.Id, (int)UserInteractionTypeEnum.Login, "User Logged", user.Id, user.LaboratoryId));

            user.LastAcess = DateTime.Now;
            Update(user);
        }
    }
}
