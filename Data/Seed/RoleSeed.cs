using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seed
{
    public class RoleSeed
    {
        public static List<object> GenerateSeed()
        {
            return new List<object>
            {
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Analist" },
                new Role { Id = 3, Name = "User" }
            };
        }
    }
}
