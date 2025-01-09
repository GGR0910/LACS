
namespace Domain.Entities
{
    public class RequesterNotes : BaseEntity
    {
        public string NoteText { get; set; }
        public bool Important { get; set; }
        public string SolicitationId { get; set; }
        public virtual Solicitation Solicitation { get; set; }
    }
}
