using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserInteraction : BaseEntity
    {
        public UserInteraction()
        {
            
        }

        public UserInteraction(string creatorId, int interactionTypeId, string description, string targetId, string laboratoryId) : base(creatorId)
        {
            UserInteractionTypeId = interactionTypeId;
            Description = description;
            TargetId = targetId;
            LaboratoryId=laboratoryId;
        }

        public string Description { get; set; }
        public string TargetId { get; set; }
        public string UserId { get; set; }
        public string LaboratoryId { get; set; }
        public virtual User User { get; set; }
        public int UserInteractionTypeId { get; set; }
        public virtual UserInteractionType UserInteractionType { get; set; }
    }
}
