using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core.Models
{
    public class UserModel
    {
        public int Id { get; set; }
		
        public string? DisplayName { get; set; }

		[Required(ErrorMessage = "FirstName is required.")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "LastName is required.")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "UserName is required.")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress]
		public string Email { get; set; }
		public Int32? DepartmentId { get; set; }
		public int? RoleId { get; set; }
		public string RoleName { get; set; }
		[Required(ErrorMessage = "PhoneNumber is required.")]
		public string PhoneNumber { get; set; }
		[Required(ErrorMessage = "JobTitle is required.")]
		public string JobTitle { get; set; }
		[Required(ErrorMessage = "City is required.")]
		public string City { get; set; }
		[Required(ErrorMessage = "State is required.")]
		public string State { get; set; }
		[Required(ErrorMessage = "Address is required.")]
		public string Address { get; set; }
		public byte[] ImageBytes { get; set; }

		public bool Active { get; set; }
	}
}
