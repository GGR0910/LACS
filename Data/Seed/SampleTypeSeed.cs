using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seed
{
    public class SampleTypeSeed
    {
        public static List<object> GenerateSeed()
        {
            return new List<object>
            {
                new SampleType { Id = 1, Name = "Polimeric" },
                new SampleType { Id = 2, Name = "Metalic" },
                new SampleType { Id = 3, Name = "Ceramic" },
                new SampleType { Id = 4, Name = "Biologic" },
                new SampleType { Id = 5, Name = "Other" },
            };
        }
    }
}
