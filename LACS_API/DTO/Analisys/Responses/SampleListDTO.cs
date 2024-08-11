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
            Analist = sample.AnalistId.IsNullOrEmpty() ? null : new UserDTO() { Id = sample.AnalistId, UserName = sample.Analist.UserName, Email = sample.Analist.Email, DepartamentName = sample.Analist.DepartamentName, Deleted = sample.Analist.Deleted };
            Requester = new UserDTO() { Id = sample.Solicitation.RequesterId, UserName = sample.Solicitation.Requester.UserName, Email = sample.Solicitation.Requester.Email, DepartamentName = sample.Solicitation.Requester.DepartamentName, Deleted = sample.Solicitation.Requester.Deleted };
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
