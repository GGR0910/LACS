namespace LACS_API.DTO
{
    public class SubmitionDTO
    {
        public string FormId { get; set; }
        public ICollection<FormAnswerDTO> Answers { get; set; }
    }
}
