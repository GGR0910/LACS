using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace LACS_API.DTO.Analisys.Responses
{
    public class SampleListDTO
    {
        public SampleListDTO()
        {
            
        }
        public SampleListDTO(Sample sample)
        {
            Id = sample.Id;
            SampleAnalisysExpectedDate = sample.SampleAnalisysExpectedDate;
            SampleAnalisysDone = sample.SampleAnalisysDone;
             SampleAnalisysDate = sample.SampleAnalisysDate;
        }
        public string Id { get; set; }
        public DateTime SampleAnalisysExpectedDate { get; set; }
        public DateTime? SampleAnalisysDate { get; set; }
        public bool SampleAnalisysDone { get; set; }
        public UserDTO Requester { get; set; }
        public UserDTO Analist { get; set; }
    }
}
