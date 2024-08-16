using Data.Context;
using Data.Interface;
using Domain;
using Domain.Entities;
using Domain.Enum;
using Domain.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext baseContext) : base(baseContext)
        {
        }

        public User? GetUserByEmail(string email) 
        { 
            return _context.Users.Include(x => x.UserLaboratories).Include(x => x.CurrentUserLaboratory).FirstOrDefault(u => u.Email == email);
        }

        public User? GetUserById(string id)
        {
            return _context.Users.Include(x => x.UserLaboratories).Include(x => x.CurrentUserLaboratory).FirstOrDefault(u => u.Id == id);
        }

        public DataTableReturn<User> GetUsers(int page, int pageLength, string laboratoryId, string? userName, string? email, int? roleId, string? departamentName)
        {
            IQueryable<User> users = _context.Users.Where(u => u.UserLaboratories.Any(x => x.LaboratoryId == laboratoryId) && !u.Deleted).Include(x => x.CurrentUserLaboratory).Include(x => x.UserLaboratories);

            int recordsTotal = users.Count();

            if (!userName.IsNullOrEmpty())
                users = users.Where(u => u.UserName.Contains(userName));
            
            if (!email.IsNullOrEmpty())
                users = users.Where(u => u.Email.Contains(email));

            if (roleId.HasValue)
                users = users.Where(u => u.UserLaboratories.Any(x => x.RoleId == roleId));

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
            user.LastAcess = DateTime.Now;
            Update(user);
        }
    }
}
