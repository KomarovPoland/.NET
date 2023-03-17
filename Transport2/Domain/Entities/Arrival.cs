using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Arrival : BaseEntity
    {
        public int Id { get; set; }
        public ArrivalTime ArrivalTime { get; set; }
        public Campus Campus { get; set; }
        public string UserId { get; set; }
    }
}
