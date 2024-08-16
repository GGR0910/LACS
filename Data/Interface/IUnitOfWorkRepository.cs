
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
        IUserRepository User { get; }
        ISampleRepository Sample { get; }
        ISolicitationRepository Solicitation { get; }
        ILaboratoryRepository Laboratory{ get; }
        IAnalisysRepository Analisys { get; }
        IUserLaboratoryRepository UserLaboratory { get; }

        #endregion

    }
}
