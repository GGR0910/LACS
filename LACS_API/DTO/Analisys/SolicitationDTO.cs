using Domain.Entities;

namespace LACS_API.DTO.Analisys
{
    public class SolicitationDTO
    {
        public SolicitationDTO()
        {
            
        }
        public SolicitationDTO(UserDTO requester, SolicitationType solicitationType, AnalisysType analisysType, List<SampleDTO> samples, string samplesDescription, string analysisGoalDescription,
            string? desiredMagnefication, bool needsRecobriment, string? recobrimentMaterial, string? specialPrecautions
           , DateTime desiredDeadLine, string deliveryLocation, bool desireToAccompanyAnalisys, string? observations)
        {
            Requester = requester;
            SolicitationType = solicitationType;
            AnalisysType = analisysType;
            SamplesDescription = samplesDescription;
            AnalysisGoalDescription = analysisGoalDescription;
            DesiredMagnefication = desiredMagnefication;
            NeedsRecobriment = needsRecobriment;
            RecobrimentMaterial = recobrimentMaterial;
            SpecialPrecautions = specialPrecautions;
            DesiredDeadline = desiredDeadLine;
            DeliveryLocation = deliveryLocation;
            DesireToAccompanyAnalysis = desireToAccompanyAnalisys;
            Observations = observations;
            Samples = samples;
            ResultsDelivered = false;
        }
        public string Id { get; set; }
        public  UserDTO Requester { get; set; }
        public  SolicitationType SolicitationType { get; set; }
        public string SamplesDescription { get; set; }
        public string AnalysisGoalDescription { get; set; }
        public  AnalisysType AnalisysType { get; set; }
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
