namespace Domain.Entities { 
    public class FormSubmit : BaseEntity
    {
        public string FormId { get; set; }
        public virtual Form Form { get; set; }
        public string RequesterId { get; set; }
        public virtual User Requester { get; set; }
        public string SolicitationId { get; set; }
        public virtual Solicitation Solicitation { get; set; }
        public virtual ICollection<FormAnswer> Answers { get; set; }
    }
}
