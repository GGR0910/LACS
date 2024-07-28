﻿using Data.Context;
using Data.Interface.Analisys;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Analisys
{
    public class SampleRepository : BaseRepository<Sample>, ISampleRepository
    {
        public SampleRepository(DataContext baseContext) : base(baseContext)
        {
        }
    }
}
