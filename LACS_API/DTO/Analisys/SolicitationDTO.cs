using Domain.Entities;
using LACS_API.DTO.Analisys.Responses;
using LACS_API.DTO.EnumDTOs;
using Microsoft.IdentityModel.Tokens;

namespace LACS_API.DTO.Analisys
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
            DesireToAccompanyAnalysis = solicitation.DesireToAccompanyAnalysis;
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
            SamplesDescription = solicitation.SamplesDescription;
            AnalysisGoalDescription = solicitation.AnalysisGoalDescription;
            AnalisysType = new AnalisysTypeDTO() 
            {
                Id = solicitation.AnalisysType.Id,
                Name = solicitation.AnalisysType.Name
            };
            DesiredMagnefication = solicitation.DesiredMagnefication;
            NeedsRecobriment = solicitation.NeedsRecobriment;
            RecobrimentMaterial = solicitation.RecobrimentMaterial;
            SpecialPrecautions = solicitation.SpecialPrecautions;
            DeliveryLocation = solicitation.DeliveryLocation;
            Observations = solicitation.Observations;
            SampleAmount = solicitation.SampleAmount;
            Requester = new UserDTO()
            {
                Id = solicitation.Requester.Id,
                UserName = solicitation.Requester.UserName,
                Email = solicitation.Requester.Email,
                IsActive = solicitation.Requester.Deleted,
                DepartamentName = solicitation.Requester.DepartamentName
            };
            Samples = solicitation.Samples.Select(s => new SampleDTO()
            {
                Id = s.Id,
                SampleAnalisysExpectedDate = s.SampleAnalisysExpectedDate,
                SampleAnalisysDate = s.SampleAnalisysDate,
                SampleAnalisysDone = s.SampleAnalisysDone,
                SampleAnalysisResult = s.SampleAnalysisResult,
                SamplePhisicalState = new SamplePhisicalStateDTO()
                {
                    Id = s.SamplePhisicalState.Id,
                    Name = s.SamplePhisicalState.Name
                },
                SampleType = new SampleTypeDTO()
                {
                    Id = s.SampleType.Id,
                    Name = s.SampleType.Name
                },
                Analisty = s.AnalistyId.IsNullOrEmpty() ? null : new UserDTO() { Id = s.AnalistyId, UserName = s.Analisty.UserName }
            }).ToList();
        }
        public string Id { get; set; }
        public  UserDTO Requester { get; set; }
        public  SolicitationTypeDTO SolicitationType { get; set; }
        public string SamplesDescription { get; set; }
        public string AnalysisGoalDescription { get; set; }
        public  AnalisysTypeDTO AnalisysType { get; set; }
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
