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
            
        }
        public string SolicitationId { get; set; }
        public virtual Solicitation Solicitation { get; set; }
        public int SampleTypeId { get; set; }
        public virtual SampleType SampleType { get; set; }
        public int SamplePhisicalStateId { get; set; }
        public virtual SamplePhisicalState SamplePhisicalState { get; set; }
        public DateTime? SampleAnalysisStartDate { get; set; }
        public DateTime? SampleAnalysisEndDate { get; set; }
        public string? SampleAnalysisResult { get; set; }
        public string? AnalistyId { get; set; }
        public virtual User Analisty { get; set; }
    }
}
