using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CrearedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
