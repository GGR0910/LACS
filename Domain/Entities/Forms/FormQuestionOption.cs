namespace Domain.Entities
{
    public class FormQuestionOption : BaseEntity
    {
        public string Option { get; set; }
        public string OptionName { get; set; }
        public bool Enabled { get; set; }
        public string QuestionId { get; set; }
        public virtual FormQuestion Question { get; set; }
    }
}
