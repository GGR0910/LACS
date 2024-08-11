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
                Deleted = solicitation.Requester.Deleted,
                DepartamentName = solicitation.Requester.DepartamentName
            };
            Samples = solicitation.Samples.Select(s => new SampleListDTO()
            {
                Id = s.Id,
                SampleAnalisysExpectedDate = s.SampleAnalisysExpectedDate,
                SampleAnalisysDate = s.SampleAnalisysDate,
                SampleAnalisysDone = s.SampleAnalisysDone,
                Requester = new UserDTO() { Id = s.Solicitation.RequesterId, UserName = s.Solicitation.Requester.UserName, Email = s.Solicitation.Requester.Email, Deleted = s.Solicitation.Requester.Deleted, DepartamentName= s.Solicitation.Requester.DepartamentName },
                Analist = s.AnalistId.IsNullOrEmpty() ? null : new UserDTO() { Id = s.AnalistId, UserName = s.Analist.UserName, Email = s.Analist.Email, Deleted = s.Analist.Deleted, DepartamentName = s.Analist.DepartamentName }
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
        public virtual ICollection<SampleListDTO> Samples { get; set; }
    }
}
