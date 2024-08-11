using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seed
{
    public class AnalisysFormQuestionTypeSeed
    {
        public static List<object> GenerateSeed()
        {
            return new List<object>
            {
                new AnalisysFormQuestionType { Id = 1, Name = "integer" },
                new AnalisysFormQuestionType { Id = 2, Name = "text" },
                new AnalisysFormQuestionType { Id = 3, Name = "boolean" },
                new AnalisysFormQuestionType { Id = 4, Name = "date" },
                new AnalisysFormQuestionType { Id = 5, Name = "time" },
                new AnalisysFormQuestionType { Id = 6, Name = "datetime" },
                new AnalisysFormQuestionType { Id = 7, Name = "decimal" },
                new AnalisysFormQuestionType { Id = 8, Name = "select" }
            };
        }
    }
}
