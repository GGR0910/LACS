﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seed
{
    public class SamplePhisicalStateSeed
    {
        public static List<object> GenerateSeed()
        {
            return new List<object>
            {
                new SampleType { Id = 1, Name = "Dust" },
                new SampleType { Id = 2, Name = "Pieces" },
                new SampleType { Id = 3, Name = "Film" },
                new SampleType { Id = 4, Name = "Other" }
            };
        }
    }
}
