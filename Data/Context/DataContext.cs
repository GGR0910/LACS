﻿using Data.Configuration;
using Data.Seed;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

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
            #endregion

            base.OnModelCreating(modelBuilder);
            Seed(modelBuilder);
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            #region Seeds
            modelBuilder.Entity<Role>().HasData(RoleSeed.GenerateSeed());
            modelBuilder.Entity<UserInteractionType>().HasData(UserInteractionTypeSeed.GenerateSeed());
            #endregion

            GerarBaseAdmin(modelBuilder);
        }

        public void GerarBaseAdmin(ModelBuilder modelBuilder)
        {
            User adminUser = new User(Guid.NewGuid().ToString(),"SystemUser","ggr0910@hotmail.com","Gogoll90@", 1);
            adminUser.EmailConfirmed = true;

            modelBuilder.Entity<User>().HasData(adminUser);
        }
    }
}
