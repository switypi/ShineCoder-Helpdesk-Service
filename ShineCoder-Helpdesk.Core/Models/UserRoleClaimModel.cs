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

        public int UserId { get; set; }

        public List<UserClaimListModel> UserClaimList { get; set; }
        public List<UserClaimListModel> RoleClaimList { get; set; }



    }

    public class UserClaimListModel
    {
		public bool IsFullAccess { get; set; }
		public bool IsAddAccess { get; set; }
		public bool IsEditAccess { get; set; }
		public bool IsViewAccess { get; set; }
		public bool IsDeleteAccess { get; set; }
		public bool IsPrintAccess { get; set; }
		public bool IsExportAccess { get; set; }
		public bool IsUpdateTicketStatusAccess { get; set; }
	}
    public class RoleClaimListModel
    {
        public bool IsNewAccess { get; set; }
        public bool IsOpenAccess { get; set; }
        public bool IsEditAccess { get; set; }
        public bool IsViewAccess { get; set; }
        public bool IsDeleteAccess { get; set; }
        public bool IsPrintAccess { get; set; }
        public bool IsExportAccess { get; set; }
        public bool IsUpdateTicketStatusAccess { get; set; }
    }
}
