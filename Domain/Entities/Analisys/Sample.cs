
namespace Domain.Entities
{
    public class Sample : BaseEntity
    {
        public Sample()
        {
            
        }
        public Sample(string solicitationId, string requesterId) : base(requesterId)
        {
            SolicitationId = solicitationId;
            SampleAnalisysExpectedDate = new DateTime();
        }
        public string SolicitationId { get; set; }
        public virtual Solicitation Solicitation { get; set; }
        public DateTime SampleAnalisysExpectedDate { get; set; }
        public DateTime? SampleAnalisysDate { get; set; }
        public bool SampleAnalisysDone { get; set; }
        public string? SampleName { get; set; }
        public string? SampleDescription { get; set; }
        public string? SampleResult { get; set; }
        public string? AnalistId { get; set; }
        public virtual User Analist { get; set; }
    }
}
