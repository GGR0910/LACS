﻿using Application.Interface;
using Data.Context;
using Data.Interface;
using Data.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class UnitOfWorkApplication : IUnitOfWorkApplication, IDisposable
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWorkRepository _repository;

        public UnitOfWorkApplication(IConfiguration configuration)
        {
            _configuration = configuration;
            _context = new DataContext(_configuration);
            _repository = new UnitOfWorkRepositorio(_context, _configuration);

            Solicitation = new SolicitationApplication(_repository, _configuration);
            User = new UserApplication(_repository, _configuration);
            Sample = new SampleApplication(_repository, _configuration);
            Environment = new EnvironmentApplication(_repository, _configuration);
        }

        public IUserApplication User { get; private set; }
        public ISampleApplication Sample { get; private set; }
        public ISolicitationApplication Solicitation { get; private set; }
        public IEnvironmentApplication Environment { get; private set; }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public int SaveChanges()
        {
            return _repository.SaveChanges();
        }
    }
}
