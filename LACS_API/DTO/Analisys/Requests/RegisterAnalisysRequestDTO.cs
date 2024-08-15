using System.ComponentModel.DataAnnotations;

namespace LACS_API.DTO
{
    public class RegisterAnalisysRequestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int AmountDonePerDay { get; set; }
        [Required]
        public string SampleDeliverObservations { get; set; }
        [Required]
        public string AnalistsNames { get; set; }
        [Required]
        public bool AllowWatching { get; set; }
        [Required]
        public string LaboratoryId { get; set; }
    }
}
