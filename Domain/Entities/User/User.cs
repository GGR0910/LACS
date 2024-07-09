using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public User() { }
        public User(string creatorId, string username, string email, string encryptedPassword) : base(creatorId)
        {
            UserName = username;
            Email = email;
            EncryptedPassword = encryptedPassword;
            Active = true;
            EmailConfirmed = false;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string EncryptedPassword { get; set; }
        public DateTime? LastAcess { get; set; }
        public bool Active { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
