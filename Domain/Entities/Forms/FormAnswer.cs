namespace Domain.Entities
{
    public class FormAnswer : BaseEntity
    {

        public string Answer { get; set; }
        public string QuestionId { get; set; }
        public virtual FormQuestion Question { get; set; }
        public string FormSubmitId { get; set; }
        public virtual FormSubmit Submission { get; set; }

    }
}
