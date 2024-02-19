using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ShineCoder_Helpdesk.Infrastructure.Models
{
	public class ApplicationRole : IdentityRole<Int32>
	{

		public string RoleName { get; set; }

		public bool IsActive { get; set; }
		public bool IsClient { get; set; }
		public bool IsAgent { get; set; }

	}
}
