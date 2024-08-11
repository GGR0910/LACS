using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AnalisysFormQuestion : BaseEntity
    {
        public string Question { get; set; }
        public string AnalisysFormId { get; set; }
        public virtual AnalisysForm AnalisysForm { get; set; }
        public int QuestionTypeId { get; set; }
        public virtual AnalisysFormQuestionType QuestionType { get; set; }
        public bool HasOptions { get; set; }
        public int Order { get; set; }
        public virtual ICollection<AnalisysFormQuestionOption> Options { get; set; }
        public virtual ICollection<AnalisysFormAnswer> Answers { get; set; }
    }
}
