using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AnalisysForm : BaseEntity
    {
        public string FormId { get; set; }
        public Form Form { get; set; }
        public string AnalisysId { get; set; }
        public Analisys Analisys { get; set; }
        public bool Current { get; set; }
    }
}
