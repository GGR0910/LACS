using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seed
{
    public class SolicitationTypeSeed
    {
        public static List<object> GenerateSeed()
        {
            return new List<object>
            {
                new SolicitationType { Id = 1, Name = "Academic" },
                new SolicitationType { Id = 2, Name = "ServicePrestation" }
            };
        }
    }
}
