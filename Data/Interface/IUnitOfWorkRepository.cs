
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
        ISampleRepository SampleRepository { get; }
        ISolicitationRepository SolicitationRepository { get; }
        ILaboratoryRepository LaboratoryRepository { get; }

        #endregion

    }
}
