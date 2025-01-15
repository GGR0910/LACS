using Data.Context;
using Data.Interface;
using Domain.Entities;
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
    public class UserLaboratoryRepository : BaseRepository<UserLaboratory>, IUserLaboratoryRepository
    {
        public UserLaboratoryRepository(DataContext baseContext) : base(baseContext)
        {
        }

        public async Task<UserLaboratory?> GetUserLaboratory(string userLaboratoryId)
        {
            return await _context.UserLaboratory.Include(x => x.Laboratory).Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == userLaboratoryId);
        }

        public async Task<DataTableReturn<UserLaboratory>> GetUsers(int page, int pageLength, string laboratoryId, string? userName, string? email, int? roleId, string? departamentName)
        {
            IQueryable<UserLaboratory> users = _context.UserLaboratory.Where(u => u.Id == laboratoryId && !u.Deleted).Include(x => x.User);

            int recordsTotal = users.Count();

            if (!userName.IsNullOrEmpty())
                users = users.Where(u => u.LaboratoryId.Contains(userName));

            if (!email.IsNullOrEmpty())
                users = users.Where(u => u.User.Email.Contains(email));

            if (roleId.HasValue)
                users = users.Where(u => u.RoleId == roleId);

            if (!departamentName.IsNullOrEmpty())
                users = users.Where(u => u.SectorName.Contains(departamentName));

            users = users.OrderBy(u => u.LabUserName).Skip((page - 1) * pageLength).Take(pageLength);

            DataTableReturn<UserLaboratory> dataTableReturn = new DataTableReturn<UserLaboratory>()
            {
                Data = users.ToList(),
                RecordsTotal = recordsTotal,
                RecordsFiltered = users.Count(),
                Page = page
            };

            return dataTableReturn;
        }
    }
}
