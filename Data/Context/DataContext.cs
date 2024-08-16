using Data.Configuration;
using Data.Seed;
using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Laboratory = Domain.Entities.Laboratory;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Dbset
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInteractionType> UserInteractionType { get; set; }
        public DbSet<UserInteraction> UserInteractions { get; set; }
        public DbSet<SolicitationType> SolicitationTypes { get; set; }
        public DbSet<Sample> Sample { get; set; }
        public DbSet<Solicitation> Solicitation { get; set; }
        public DbSet<Laboratory> Laboratory { get; set; }
        public DbSet<Analisys> Analisys { get; set; }
        public DbSet<AnalisysForm> AnalisysForm { get; set; }
        public DbSet<AnalisysFormQuestion> AnalisysFormQuestion { get; set; }
        public DbSet<AnalisysFormQuestionType> AnalisysFormQuestionType { get; set; }
        public DbSet<AnalisysFormQuestionOption> AnalisysFormQuestionOption { get; set; }
        public DbSet<AnalisysFormAnswer> AnalisysFormAnswer { get; set; }
        public DbSet<AnalisysFormSubmit> AnalisysFormSubmit { get; set; }
        public DbSet<UserLaboratory> UserLaboratory { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>()
                .HavePrecision(18, 6);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configurations
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserInteractionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserInteractionConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitationConfiguration());
            modelBuilder.ApplyConfiguration(new SampleConfiguration());
            modelBuilder.ApplyConfiguration(new LaboratoryConfiguration());
            modelBuilder.ApplyConfiguration(new AnalisysConfiguration());
            modelBuilder.ApplyConfiguration(new AnalisysFormConfiguration());
            modelBuilder.ApplyConfiguration(new AnalisysFormQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new AnalisysFormQuestionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnalisysFormQuestionOptionConfiguration());
            modelBuilder.ApplyConfiguration(new AnalisysFormAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new AnalisysFormSubmitConfiguration());
            modelBuilder.ApplyConfiguration(new UserLaboratoryConfiguration());
            #endregion

            base.OnModelCreating(modelBuilder);
            Seed(modelBuilder);
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            #region Seeds
            modelBuilder.Entity<Role>().HasData(RoleSeed.GenerateSeed());
            modelBuilder.Entity<UserInteractionType>().HasData(UserInteractionTypeSeed.GenerateSeed());
            modelBuilder.Entity<SolicitationType>().HasData(SolicitationTypeSeed.GenerateSeed());   
            modelBuilder.Entity<AnalisysFormQuestionType>().HasData(AnalisysFormQuestionTypeSeed.GenerateSeed());
            #endregion

            GerarBaseAdmin(modelBuilder);
        }

        public void GerarBaseAdmin(ModelBuilder modelBuilder)
        {
            
            User adminUser = new User()
            {
                Id = "c7af4e3e-ff58-4f65-a942-9f5461d65b09",
                UserName = "SystemUser",
                Email = "ggr0910@hotmail.com",
                EncryptedPassword = "Gogoll90@",
                DepartamentName = "System",
                EmailConfirmed = true,
                CreatedAt = DateTime.Now,
            };
            modelBuilder.Entity<User>().HasData(adminUser);
        }
    }
}
