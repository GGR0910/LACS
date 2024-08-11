using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Solicitation : BaseEntity
    {
        public Solicitation()
        {
            
        }
        public Solicitation(string requesterId, int solicitationTypeId,DateTime desiredDeadLine, string analisysId) : base(requesterId) 
        {
            SoliciationTypeId = solicitationTypeId;
            DesiredDeadline = desiredDeadLine;
            Samples = new List<Sample>();
            ResultsDelivered = false;
            AnalisysId = analisysId;
        }
        //Basic solicitation information
        public int SoliciationTypeId { get; set; }
        public virtual SolicitationType SolicitationType { get; set; }
        public DateTime DesiredDeadline { get; set; }
        public DateTime? SamplesReceivedDate { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public bool ResultsDelivered { get; set; }
        public int SampleAmount { get { return Samples.Count(); } }
        public virtual ICollection<Sample> Samples { get; set; }

        //Specific solicitation information
        public string AnalisysId { get; set; }
        public virtual Analisys Analisys { get; set; }
        public virtual AnalisysFormSubmit AnalisysFormSubmit { get; set; }
    }
}
