using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core.Models
{
    public class RoleModel
    {
        public int  Id { get; set; }
        public string Name { get; set; }

        public string NormalizedName { get; set; }
       
        public bool IsActive { get; set; }
        public bool IsClient { get; set; }
        public bool IsAgent { get; set; }
    }
}
