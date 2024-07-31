using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sample : BaseEntity
    {
        public Sample()
        {
            
        }
        public Sample(string solicitationId, int sampleTypeId, int samplePhisicalStateId, string requesterId) : base(requesterId)
        {
            SolicitationId = solicitationId;
            SampleTypeId = sampleTypeId;
            SamplePhisicalStateId = samplePhisicalStateId;
            SampleAnalisysExpectedDate = new DateTime();
        }
        public string SolicitationId { get; set; }
        public virtual Solicitation Solicitation { get; set; }
        public int SampleTypeId { get; set; }
        public virtual SampleType SampleType { get; set; }
        public int SamplePhisicalStateId { get; set; }
        public virtual SamplePhisicalState SamplePhisicalState { get; set; }
        public DateTime SampleAnalisysExpectedDate { get; set; }
        public DateTime? SampleAnalisysDate { get; set; }
        public bool SampleAnalisysDone { get; set; }
        public string? SampleAnalysisResult { get; set; }
        public string? AnalistyId { get; set; }
        public virtual User Analisty { get; set; }
    }
}
