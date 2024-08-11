using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AnalisysForm : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }

        public string AnalisysId { get; set; }
        public virtual Analisys Analisys { get; set; }
        public virtual IEnumerable<AnalisysFormQuestion> Questions { get; set; }
        public virtual IEnumerable<AnalisysFormSubmit> Submissions { get; set; }

    }
}
