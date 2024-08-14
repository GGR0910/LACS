using Data.Context;
using Data.Interface;
using Data.Repository.Analisys;
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
            UserRepository = new UserRepository(_context);
            SampleRepository = new SampleRepository(_context);
            SolicitationRepository = new SolicitationRepository(_context);
            LaboratoryRepository = new LaboratoryRepository(_context);
        }

        #region Repositories
        public IBaseRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new BaseRepository<TEntity>(_context);
        }

        public IUserRepository UserRepository { get; private set; }
        public ISampleRepository SampleRepository { get; private set; }
        public ISolicitationRepository SolicitationRepository { get; private set; }
        public ILaboratoryRepository LaboratoryRepository { get; private set; }

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
