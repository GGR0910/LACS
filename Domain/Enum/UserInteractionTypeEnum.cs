using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum UserInteractionTypeEnum
    {
        Login = 1,
        Register = 2,
        Update = 3,
        Delete = 4,
        ChangePassword = 5,
        Logout = 6,
        SubmittedSamples = 7,
        TookSamples = 8,
        CompletedSamples = 9
    }
}
