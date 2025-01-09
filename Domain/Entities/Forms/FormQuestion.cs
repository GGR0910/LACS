namespace Domain.Entities
{
    public class FormQuestion : BaseEntity
    {
        public string QuestionText { get; set; }
        public string QuestionInstructions { get; set; }
        public string QuestionPlaceholder { get; set; }
        public int QuestionTypeId { get; set; }
        public virtual FormQuestionType QuestionType { get; set; }
        public int Order { get; set; }
        public string SectionId { get; set; }
        public virtual FormSection Section { get; set; }
        public bool IsRequired { get; set; }
        public virtual ICollection<FormQuestionOption> Options { get; set; }
        public virtual ICollection<FormAnswer> Answers { get; set; }
    }
}
