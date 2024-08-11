using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AnalisysFormQuestionOption : BaseEntity
    {
        public string Option { get; set; }
        public string OptionName { get; set; }
        public bool Enabled { get; set; }
        public string QuestionId { get; set; }
        public virtual AnalisysFormQuestion Question { get; set; }
    }
}
