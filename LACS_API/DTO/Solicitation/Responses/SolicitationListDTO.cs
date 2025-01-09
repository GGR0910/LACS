using Domain.Entities;

namespace LACS_API.DTO
{
    public class SolicitationListDTO
    {
        public SolicitationListDTO(Solicitation solicitation)
        {
            Id = solicitation.Id;
            DesiredDeadline = solicitation.DesiredDeadline;
            SamplesReceivedDate = solicitation.SamplesReceivedDate;
            ExpectedCompletionDate = solicitation.ExpectedCompletionDate;
            CompletionDate = solicitation.CompletionDate;
            ResultsDelivered = solicitation.ResultsDelivered;
            SampleAmount = solicitation.SampleAmount;
        }

        public string Id { get; set; }
        public UserDTO Requester { get; set; }
        public int AnalisysTypeId { get; set; }
        public DateTime DesiredDeadline { get; set; }
        public bool DesireToAccompanyAnalysis { get; set; }
        public DateTime? SamplesReceivedDate { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public bool ResultsDelivered { get; set; }
        public int SampleAmount { get; set; }
        public virtual ICollection<SampleListDTO> Samples { get; set; }
    }
}
