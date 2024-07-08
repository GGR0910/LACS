using Data.Context;
using Data.Interface;
using Domain;
using Domain.Entities;
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

        public Result<User> GetUserByEmail(string email)
        {
            Result<User> result = new Result<User>();
            
            User? user = _context.Users.FirstOrDefault(u => u.Email == email && !u.Deleted);
            if(user == null)
                result.Message = "User not found";
            else
            {
                result.Success = true;
                result.Return = user;
            }

            return result;
        }

        public void LoginUser(User user)
        {
            user.LastAcess = DateTime.Now;
            Update(user);
        }
    }
}
