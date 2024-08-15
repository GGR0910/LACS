using Domain.Entities;
using LACS_API.DTO.Analisys.Responses;
using LACS_API.DTO.EnumDTOs;
using LACS_API.DTO.Sample;
using Microsoft.IdentityModel.Tokens;

namespace LACS_API.DTO.Solicitation
{
    public class SolicitationDTO
    {
        public SolicitationDTO()
        {

        }
        public SolicitationDTO(Solicitation solicitation)
        {
            Id = solicitation.Id;
            DesiredDeadline = solicitation.DesiredDeadline;

            SamplesReceivedDate = solicitation.SamplesReceivedDate;
            ExpectedCompletionDate = solicitation.ExpectedCompletionDate;
            CompletionDate = solicitation.CompletionDate;
            ResultsDelivered = solicitation.ResultsDelivered;
            SampleAmount = solicitation.SampleAmount;
            SolicitationType = new SolicitationTypeDTO()
            {
                Id = solicitation.SolicitationType.Id,
                Name = solicitation.SolicitationType.Name
            };

        }
        public string Id { get; set; }
        public UserDTO Requester { get; set; }
        public SolicitationTypeDTO SolicitationType { get; set; }
        public string SamplesDescription { get; set; }
        public string AnalysisGoalDescription { get; set; }
        public AnalisysTypeDTO AnalisysType { get; set; }
        public string? DesiredMagnefication { get; set; }
        public bool NeedsRecobriment { get; set; }
        public string? RecobrimentMaterial { get; set; }
        public string? SpecialPrecautions { get; set; }
        public DateTime DesiredDeadline { get; set; }
        public string DeliveryLocation { get; set; }
        public bool DesireToAccompanyAnalysis { get; set; }
        public string? Observations { get; set; }
        public DateTime? SamplesReceivedDate { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public bool ResultsDelivered { get; set; }
        public int SampleAmount { get; set; }
        public virtual ICollection<SampleDTO> Samples { get; set; }
    }
}
