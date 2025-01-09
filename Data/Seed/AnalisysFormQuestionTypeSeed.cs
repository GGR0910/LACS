using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seed
{
    public class FormQuestionTypeSeed
    {
        public static List<object> GenerateSeed()
        {
            return new List<object>
            {
                new FormQuestionType { Id = 1, Name = "integer" },
                new FormQuestionType { Id = 2, Name = "text" },
                new FormQuestionType { Id = 3, Name = "boolean" },
                new FormQuestionType { Id = 4, Name = "date" },
                new FormQuestionType { Id = 5, Name = "time" },
                new FormQuestionType { Id = 6, Name = "datetime" },
                new FormQuestionType { Id = 7, Name = "decimal" },
                new FormQuestionType { Id = 8, Name = "select" }
            };
        }
    }
}
