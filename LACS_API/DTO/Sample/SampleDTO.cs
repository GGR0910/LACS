using Domain.Entities;
using LACS_API.DTO.EnumDTOs;

namespace LACS_API.DTO.Sample
{
    public class SampleDTO
    {
        public SampleDTO()
        {

        }

        public string Id { get; set; }
        public SampleTypeDTO SampleType { get; set; }
        public SamplePhisicalStateDTO SamplePhisicalState { get; set; }
        public DateTime SampleAnalisysExpectedDate { get; set; }
        public DateTime? SampleAnalisysDate { get; set; }
        public bool SampleAnalisysDone { get; set; }
        public string? SampleAnalysisResult { get; set; }
        public UserDTO Analisty { get; set; }
    }
}
