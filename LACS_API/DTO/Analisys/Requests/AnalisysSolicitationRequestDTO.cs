using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LACS_API.DTO.Analisys.Requests
{
    public class AnalisysSolicitationRequestDTO 
    {
        [Required]
        public string RequesterId { get; set; }

        [Required]
        public int SoliciationTypeId { get; set; }

        [Required]
        public string SamplesDescription { get; set; }

        [Required]
        public string AnalysisGoalDescription { get; set; }

        [Required]
        public int AnalisysTypeId { get; set; }
        public string? DesiredMagnefication { get; set; }

        [Required]
        public bool NeedsRecobriment { get; set; }
        public string? RecobrimentMaterial { get; set; }
        public string? SpecialPrecautions { get; set; }

        [Required]
        public DateTime DesiredDeadline { get; set; }

        [Required]
        public string DeliveryLocation { get; set; }

        [Required]
        public bool DesireToAccompanyAnalysis { get; set; }
        public string? Observations { get; set; }
        public int SampleAmaunt { get; set; }
        public int SampleTypeId { get; set; }
        public int SamplePhisicalStateId { get; set; }

    }
}
