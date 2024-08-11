using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities { 
    public class AnalisysFormAnswer: BaseEntity
    {

        public string Answer { get; set; }
        public string QuestionId { get; set; }
        public virtual AnalisysFormQuestion Question { get; set; }
        public string AnalisysFormSubmitId { get; set; }
        public virtual AnalisysFormSubmit Submission { get; set; }

    }
}
