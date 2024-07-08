using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IUnitOfWorkRepository
    {

        #region Methods
        int SaveChanges();
        void Dispose();
        int ExecuteSqlCommand(string sql, params object[] parameters);
        #endregion

        #region Interfaces

        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : class;
        IUserRepository UserRepository { get; }
        IAPIJWTSessionRepository APIJWTSession { get; }

        #endregion

    }
}
