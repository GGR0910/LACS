
namespace Domain.Entities
{
    public class Form : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public decimal FormVersion { get; set; }
        public bool CollectDetailedSampleInformation { get; set; }
        public virtual IEnumerable<FormSubmit> Submissions { get; set; }
        public virtual IEnumerable<FormSection> Sections { get; set; }
        public virtual IEnumerable<AnalisysForm> AnalisysForms { get; set; }
        public virtual Analisys Analisys { get { return AnalisysForms.First(x => !x.Deleted && x.Current).Analisys; } }

    }
}
