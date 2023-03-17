using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class BaseEntityDTO
    {
        public DateTime DateCreated { get; set; }

        public string CreatedById { get; set; }

        public DateTime? LastModified { get; set; }

        public string ModifiedById { get; set; }

        public bool IsDeleted { get; set; }
    }
}

