using System.ComponentModel.DataAnnotations;

namespace LACS_API.DTO.Analisys.Requests
{
    public class AssignSampleToAnalistRequestDTO : BaseRequestDTO
    {
        [Required]
        public List<string> SampleIds { get; set; }
        [Required]
        public bool AreSamplesAnalised { get; set; }
        [Required]
        public string AnalistId { get; set; }
    }
}
