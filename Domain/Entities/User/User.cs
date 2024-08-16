using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public User() 
        {
            UserInteractions = new List<UserInteraction>();
            Samples = new List<Sample>();
            Submissions = new List<AnalisysFormSubmit>();
            UserLaboratories = new List<UserLaboratory>();
        }

        public User(string? creatorId, string username, string email, string encryptedPassword, string departamentName) : base(creatorId)
        {
            UserLaboratories = new List<UserLaboratory>();
            UserInteractions = new List<UserInteraction>();
            Samples = new List<Sample>();
            Submissions = new List<AnalisysFormSubmit>();
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
        public string? CurrentUserLaboratoryId { get; set; }
        public virtual UserLaboratory? CurrentUserLaboratory { get; set; }
        public virtual ICollection<UserInteraction> UserInteractions { get; set; }
        public virtual ICollection<AnalisysFormSubmit> Submissions { get; set; }
        public virtual ICollection<Sample> Samples { get; set; }
        public virtual ICollection<UserLaboratory> UserLaboratories { get; set; }

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
