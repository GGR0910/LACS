using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AnalystAnalisysResponsible : BaseEntity
    {
        public string AnalystId { get; set; }
        public virtual User Analyst { get; set; }
        public string AnalisysId { get; set; }
        public virtual Analisys Analisys { get; set; }
        //Só pode ter uma análise que o analista é principal
        public bool IsMain { get; set; }
    }
}
