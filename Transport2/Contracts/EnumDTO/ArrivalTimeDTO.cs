using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Contracts.EnumDTO
{
    public enum ArrivalTimeDTO
    {
        [Display(Name = "9:00")]
        Nine = 1
    }
}
