using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class APIJWTSession : BaseEntity
    {
        public APIJWTSession()
        {

        }
        public APIJWTSession(string creatorId, User user, string key)
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
            CreatedBy = creatorId;
            Deleted = false;
            JWTKeyUsed = key;
            User = user;
            UserId = user.Id;
            DateLimitToUse = DateTime.Now.AddHours(2);
        }
        public string JWTKeyUsed { get; set; }
        public virtual User User { get; set; }
        public string UserId { get; set;}
        public DateTime DateLimitToUse { get; set; }

    }
}
