using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ShineCoder_Helpdesk.Infrastructure.Models
{
	public class ApplicationRole:IdentityRole
	{
		public bool IsActive { get; set; }
		public bool IsClient { get; set; }
		public bool IsAgent { get; set; }

	}
}
