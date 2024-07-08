using Data.Context;
using Data.Interface;
using Data.Repository;
using LACS_API.Middleware;
using Microsoft.EntityFrameworkCore;


namespace LACS_API
{
    public class StartUp
    {
        public IConfiguration Configuration { get; }
        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepositorio>();

            services.AddScoped<GlobalValidationMiddleware>();
        }
    }
}
