using Contracts.EnumDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class ArrivalDTO
    {
        public int Id { get; set; }
        public ArrivalTimeDTO ArrivalTime { get; set; }
        public CampusDTO Campus { get; set; }
        public string UserId { get; set; }
    }
}
