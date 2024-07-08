using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {

        }
        public BaseEntity(string creatorId)
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
            CreatedBy = creatorId;
            Deleted = false;
        }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public void Update(string userId)
        {
            UpdatedAt = DateTime.Now;
            UpdatedBy = userId;
        }
    }
}
