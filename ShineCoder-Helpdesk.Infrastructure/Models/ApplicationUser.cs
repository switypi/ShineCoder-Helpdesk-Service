using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		[MaxLength(50)]
		public string FirstName { get; set; }
		[MaxLength(50)]
		public string LastName { get; set; }
		public UserTypeEnum UserType { get; set; }
		[ForeignKey(nameof(Department))]
		public Int32? DepartmentId { get; set; }
		public Department? Department { get; set; }
		[MaxLength(100)]
		public string JobTitle { get; set; }
		[MaxLength(50)]
		public string City { get; set; }
		[MaxLength(50)]
		public string State { get; set; }
		[MaxLength(250)]
		public string Address { get; set; }

		public bool Active { get; set; }
	}
}
