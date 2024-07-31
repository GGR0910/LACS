using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace LACS_API.DTO.Analisys.Responses
{
    public class SolicitationListDTO
    {
        public SolicitationListDTO(Solicitation solicitation)
        {
            Id = solicitation.Id;
            DesiredDeadline = solicitation.DesiredDeadline;
            DesireToAccompanyAnalysis = solicitation.DesireToAccompanyAnalysis;
            SamplesReceivedDate = solicitation.SamplesReceivedDate;
            ExpectedCompletionDate = solicitation.ExpectedCompletionDate;
            CompletionDate = solicitation.CompletionDate;
            ResultsDelivered = solicitation.ResultsDelivered;
            SampleAmount = solicitation.SampleAmount;
            AnalisysTypeId = solicitation.AnalisysTypeId;
            Requester = new UserDTO()
            {
                Id = solicitation.Requester.Id,
                UserName = solicitation.Requester.UserName,
                Email = solicitation.Requester.Email,
                IsActive = solicitation.Requester.Deleted,
                DepartamentName = solicitation.Requester.DepartamentName
            };
            Samples = solicitation.Samples.Select(s => new SolicitationListSampleDTO()
            {
                Id = s.Id,
                SampleAnalisysExpectedDate = s.SampleAnalisysExpectedDate,
                SampleAnalisysDate = s.SampleAnalisysDate,
                SampleAnalisysDone = s.SampleAnalisysDone,
                Analisty = s.AnalistyId.IsNullOrEmpty() ? null : new UserDTO() { Id = s.AnalistyId, UserName = s.Analisty.UserName }
            }).ToList();
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
        public virtual ICollection<SolicitationListSampleDTO> Samples { get; set; }
    }

    public class SolicitationListSampleDTO
    {
        public string Id { get; set; }
        public DateTime SampleAnalisysExpectedDate { get; set; }
        public DateTime? SampleAnalisysDate { get; set; }
        public bool SampleAnalisysDone { get; set; }
        public UserDTO Analisty { get; set; }
    }
}
