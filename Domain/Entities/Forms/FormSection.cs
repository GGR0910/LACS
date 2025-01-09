using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FormSection : BaseEntity
    {
        public string Title { get; set; }
        public int Order { get; set; }
        public virtual IEnumerable<FormQuestion> Questions { get; set; }
        public string FormId { get; set; }
        public virtual Form Form { get; set; }
    }
}
