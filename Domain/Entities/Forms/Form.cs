
namespace Domain.Entities
{
    public class Form : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string AnalisysId { get; set; }
        public virtual Analisys Analisys { get; set; }
        public virtual IEnumerable<FormSubmit> Submissions { get; set; }
        public virtual IEnumerable<FormSection> Sections { get; set; }

    }
}
