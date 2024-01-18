using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShineCoder_Helpdesk.Infrastructure.Enums;

namespace ShineCoder_Helpdesk.Infrastructure.Models
{
	public class ApplicationUser : IdentityUser<Int32>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public UserTypeEnum UserType { get; set; }
		[ForeignKey(nameof(Department))]
		public Int32? DepartmentId { get; set; }
		public Department? Department { get; set; }
	}
}
