namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public User() 
        {
            UserInteractions = new List<UserInteraction>();
            Samples = new List<Sample>();
            Submissions = new List<FormSubmit>();
            UserLaboratories = new List<UserLaboratory>();
        }

        public User(string? creatorId, string username, string email, string encryptedPassword, string document) : base(creatorId)
        {
            UserLaboratories = new List<UserLaboratory>();
            UserInteractions = new List<UserInteraction>();
            Samples = new List<Sample>();
            Submissions = new List<FormSubmit>();
            UserName = username;
            Email = email;
            EncryptedPassword = encryptedPassword;
            EmailConfirmed = false;
            Document=document;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public DateTime? LastAcess { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Document { get; set; }
        public virtual UserLaboratory? CurrentUserLaboratory { get { return UserLaboratories.FirstOrDefault(x => x.IsCurrent == true && !x.Deleted); } }
        public virtual ICollection<UserInteraction> UserInteractions { get; set; }
        public virtual ICollection<FormSubmit> Submissions { get; set; }
        public virtual ICollection<Sample> Samples { get; set; }
        public virtual ICollection<UserLaboratory> UserLaboratories { get; set; }
        public virtual ICollection<AnalystAnalisysResponsible> AnalystAnalisys { get; set; }
        public virtual ICollection<Solicitation> Solicitations { get; set; }

    }
}
