namespace Domain.Entities
{
    public class FormQuestionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<FormQuestion> Questions { get; set; }
    }
}
