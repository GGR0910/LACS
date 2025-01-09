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

        public User(string? creatorId, string username, string email, string encryptedPassword, string departamentName) : base(creatorId)
        {
            UserLaboratories = new List<UserLaboratory>();
            UserInteractions = new List<UserInteraction>();
            Samples = new List<Sample>();
            Submissions = new List<FormSubmit>();
            UserName = username;
            Email = email;
            EncryptedPassword = encryptedPassword;
            EmailConfirmed = false;
            DepartamentName=departamentName;
        }

        public string DepartamentName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public DateTime? LastAcess { get; set; }
        public bool EmailConfirmed { get; set; }
        public virtual UserLaboratory? CurrentUserLaboratory { get { return UserLaboratories.FirstOrDefault(x => x.IsCurrent == true && !x.Deleted); } }
        public virtual ICollection<UserInteraction> UserInteractions { get; set; }
        public virtual ICollection<FormSubmit> Submissions { get; set; }
        public virtual ICollection<Sample> Samples { get; set; }
        public virtual ICollection<UserLaboratory> UserLaboratories { get; set; }
        public virtual ICollection<AnalystAnalisysResponsible> AnalystAnalisys { get; set; }

        public void Delete(string loggedUserId)
        {
            Deleted = true;
            Update(loggedUserId);
        }

        public void Edit(string userName, string email, int roleId ,string departamentName, string id)
        {
            UserName = userName;
            Email = email;
            DepartamentName = departamentName;

            Update(id);
        }
    }
}
