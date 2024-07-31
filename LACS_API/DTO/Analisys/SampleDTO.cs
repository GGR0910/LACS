using Domain.Entities;

namespace LACS_API.DTO.Analisys
{
    public class SampleDTO
    {
        public SampleDTO()
        {
            
        }
        public SampleDTO(SampleType sampleType, SamplePhisicalState samplePhisicalState, UserDTO analyst, int sampleTypeId, int samplePhisicalStateId, string requesterId) 
        {
            SampleType = sampleType;
            SamplePhisicalState = samplePhisicalState;
            Analisty = analyst;
            SampleAnalisysExpectedDate = new DateTime();
        }
        public string Id { get; set; }
        public SampleType SampleType { get; set; }
        public SamplePhisicalState SamplePhisicalState { get; set; }
        public DateTime SampleAnalisysExpectedDate { get; set; }
        public DateTime? SampleAnalisysDate { get; set; }
        public bool SampleAnalisysDone { get; set; }
        public string? SampleAnalysisResult { get; set; }
        public UserDTO Analisty { get; set; }
    }
}
