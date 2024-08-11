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
        }

        public User(string creatorId, string username, string email, string encryptedPassword, string departamentName, int roleId, string environmentId) : base(creatorId)
        {
            UserName = username;
            Email = email;
            EncryptedPassword = encryptedPassword;
            EmailConfirmed = false;
            DepartamentName=departamentName;
            RoleId = roleId;
            EnvironmentId=environmentId;
        }

        public string DepartamentName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public DateTime? LastAcess { get; set; }
        public bool EmailConfirmed { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public string EnvironmentId { get; set; }
        public virtual Environment Environment { get; set; }
        public virtual ICollection<UserInteraction> UserInteractions { get; set; }
        public virtual ICollection<AnalisysFormSubmit> Submissions { get; set; }
        public virtual ICollection<Sample> Samples { get; set; }
    }
}
