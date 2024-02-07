using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Infrastructure
{
	public abstract class BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		[MaxLength(256)]
		public string? CreatedBy { get; set; }
		[MaxLength(256)]
		public string? UpdatedBy { get; set; }
		public bool? Active { get; set; }
	}
}
