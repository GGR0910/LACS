using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AnalisysFormSubmit : BaseEntity
    {
        public string AnalisysFormId { get; set; }
        public virtual AnalisysForm Form { get; set; }
        public string RequesterId { get; set; }
        public virtual User Requester { get; set; }
        public string SolicitationId { get; set; }
        public virtual Solicitation Solicitation { get; set; }
        public virtual ICollection<AnalisysFormAnswer> Answers { get; set; }
    }
}
