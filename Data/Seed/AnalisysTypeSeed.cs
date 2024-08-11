using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seed
{
    public class AnalisysTypeSeed
    {
        public static List<object> GenerateSeed()
        {
            return new List<object>
            {
                new AnalisysType { Id = 1, Name = "Morfological_SE" },
                new AnalisysType { Id = 2, Name = "ZContrast_BSE" },
                new AnalisysType { Id = 3, Name = "Composition_EDS" }
            };
        }
    }
}
