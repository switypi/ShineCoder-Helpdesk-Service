using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core.Models
{
	public class UserRolePermissionModel
	{
		public int UserId { get; set; }
		public int RoleId { get; set; }
		public string? RoleName { get; set; }
        public RoleClaimsModel RoleClaim { get; set; }
        public UserClaimModel UserClaim { get; set; }
		
	}

	public class RoleClaimsModel
	{
        public bool? IsNewListAccess { get; set; }
        public bool? IsOpenListAccess { get; set; }
        public bool? IsOverDueListAccess { get; set; }
        public bool? IsDueTodayListAccess { get; set; }
        public bool? IsResolvedListAccess { get; set; }

        public bool? IsCompletedListAccess { get; set; }
        public bool? IsMasterDataListAccess { get; set; }
        public bool? IsUserManagementAccess { get; set; }
        public bool? IsAppSettingAccess { get; set; }
    }

	public class UserClaimModel
	{
        public bool? IsFullAccess { get; set; }
        public bool? IsAddAccess { get; set; }
        public bool? IsEditAccess { get; set; }
        public bool? IsViewAccess { get; set; }
        public bool? IsDeleteAccess { get; set; }

        public bool? IsPrintAccess { get; set; }
        public bool? IsIsExportAccess { get; set; }
        public bool? IsUpdateTicketStatusAccess { get; set; }
    }
}
