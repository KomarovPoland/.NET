using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseEntity
    {

        [ScaffoldColumn(false)]
        public DateTime DateCreated { get; set; }

        [ScaffoldColumn(false)]
        public string CreatedById { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? LastModified { get; set; }

        [ScaffoldColumn(false)]
        public string ModifiedById { get; set; }

        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }
    }
}
