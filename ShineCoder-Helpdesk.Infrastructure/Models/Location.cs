using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Infrastructure.Models
{
    public  class Location :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsDefault { get; set; }
    }
}
