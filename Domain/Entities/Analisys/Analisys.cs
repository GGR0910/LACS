using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Analisys: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AmountDonePerDay { get; set; }
        public string LaboratoryId { get; set; }
        public virtual Laboratory Laboratory { get; set; }
        public string SampleDeliverObservations { get; set; }
        public virtual AnalisysForm AnalisysForm { get; set; }
        public virtual IEnumerable<Solicitation> Solicitations { get; set; }

    }
}
