 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Infrastructure.Models
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}
