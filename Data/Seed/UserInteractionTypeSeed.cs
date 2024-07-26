using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seed
{
    public class UserInteractionTypeSeed
    {
        public static List<object> GenerateSeed()
        {
            return new List<object>
            {
                new UserInteractionType { Id = 1, Name = "Login" },
                new UserInteractionType { Id = 2, Name = "Register" },
                new UserInteractionType { Id = 3, Name = "Update" },
                new UserInteractionType { Id = 4, Name = "Delete" },
                new UserInteractionType { Id = 5, Name = "ChangePassword" },
                new UserInteractionType { Id = 6, Name = "Logout" },
                new UserInteractionType { Id = 7, Name = "SubmittedSamples" },
                new UserInteractionType { Id = 8, Name = "TookSamples" },
                new UserInteractionType { Id = 9, Name = "CompletedSamples" }
            };
        }
    }
}
