using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Core.Models
{
	public class TicketsModel
	{
        public string Tkt_Number { get; set; }
        [Required(ErrorMessage = "Ticket description is required.")]
		public string Tkt_Desc { get; set; }
		[Required(ErrorMessage = "Ticket subject is required.")]
		public string Tkt_Subject { get; set; }
		[Required(ErrorMessage = "Ticket requestor is required.")]
		public Int32 Tkt_RequestUserId { get; set; }
		public DateTime? Tkt_DueDate { get; set; }
		[Required(ErrorMessage = "Ticket status is required.")]
		public Int32 TicketStatusId { get; set; }
		[Required(ErrorMessage = "Ticket priority is required.")]
		public Int32 TicketPriorityId { get; set; }
        [Required(ErrorMessage = "User location is required.")]
        public Int32? Tkt_LocationId { get; set; }
        [Required(ErrorMessage = "Department is required.")]
        public Int32? Tkt_DepartmentId { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public Int32? Tkt_CategoryId { get; set; }

		public Int32? Tkt_SubCategoryId { get; set; }

		public Int32? Tkt_RequestTypeId { get; set; }
		[Required(ErrorMessage = "Ticket mode is required.")]
		public Int32? Ticket_ModeId { get; set; }
        public Int32? TicketLevelId { get; set; }
        
        public Int32? TicketUrgencyId { get; set; }

        public Int32? Tkt_ImpactId { get; set; }
        [Required(ErrorMessage = "Attachment is required.")]
        public IList<Ticket_Attachments> Ticket_Attachments { get; set; }
    }
}
