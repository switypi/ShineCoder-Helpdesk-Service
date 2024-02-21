using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShineCoder_Helpdesk.Core.Enums;

namespace ShineCoder_Helpdesk.Core.Models
{
    public class UserRoleModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public UserTypeEnum UserType { get; set; }
    }
}
