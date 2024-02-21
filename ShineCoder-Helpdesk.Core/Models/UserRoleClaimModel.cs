using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core.Models
{
    public class UserRoleClaimModel
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public List<ClaimListModel> ClaimList { get; set; }

      
    }

    public class ClaimListModel
    {
		public bool IsFullAccess { get; set; }
		public bool IsAddAccess { get; set; }
		public bool IsEditAccess { get; set; }
		public bool IsViewAccess { get; set; }
		public bool IsDeleteAccess { get; set; }
	}
}
