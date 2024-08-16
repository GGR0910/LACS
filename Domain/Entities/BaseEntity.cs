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
        public BaseEntity(string? creatorId)
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
            CreatedById = creatorId;
            Deleted = false;
        }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Deleted { get; set; }
        public string? CreatedById { get; set; }
        public virtual UserLaboratory CreatedByUserLaboratory { get; set; }
        public string? UpdatedById { get; set; }
        public virtual UserLaboratory UpdatedByUserLaboratory { get; set; }

        public void Update(string userLaboratoryId)
        {
            UpdatedAt = DateTime.Now;
            UpdatedById = userLaboratoryId;
        }

        public void Update()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}
