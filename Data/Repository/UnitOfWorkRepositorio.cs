using Data.Context;
using Data.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace Data.Repository
{
    public class UnitOfWorkRepositorio : IUnitOfWorkRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public UnitOfWorkRepositorio(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            User = new UserRepository(_context);
            Sample = new SampleRepository(_context);
            Solicitation = new SolicitationRepository(_context);
            Laboratory = new LaboratoryRepository(_context);
            Analisys = new AnalisysRepository(_context);
        }

        #region Repositories
        public IBaseRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new BaseRepository<TEntity>(_context);
        }

        public IUserRepository User { get; private set; }
        public ISampleRepository Sample { get; private set; }
        public ISolicitationRepository Solicitation { get; private set; }
        public ILaboratoryRepository Laboratory { get; private set; }
        public IAnalisysRepository Analisys { get; private set; }

        #endregion


        #region Methods
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    command.Parameters.AddRange(parameters);
                    return command.ExecuteNonQuery();
                }
            }
        }
        public int SaveChanges()
        {
            try
            {
                var obj = new { };
                lock (obj)
                {
                    return _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
