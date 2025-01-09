using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum QuestionTypeEnum
    {
        Integer = 1,
        Text = 2,
        Boolean = 3,
        Date = 4,
        Time = 5,
        DateTime = 6,
        Decimal = 7,
        Select = 8
    }
}
