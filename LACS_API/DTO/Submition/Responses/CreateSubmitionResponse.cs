using Domain.Entities;

namespace LACS_API.DTO
{
    public class CreateSubmitionResponse
    {
        public static object SerializeToReturn(Solicitation solicitation)
        {
            return new
            { 
                solicitation.Id,
                solicitation.FormSubmit.FormId,
                solicitation.ExpectedCompletionDate,
                solicitation.ResponsibleAnalist.UserName
            };
        }
    }
}
