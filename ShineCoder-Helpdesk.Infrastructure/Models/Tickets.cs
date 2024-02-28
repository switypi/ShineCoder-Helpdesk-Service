using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Infrastructure.Models
{
    public class Tickets : BaseEntity
    {
        public string Ticket_Desc { get; set; }

		
        public string Tkt_Number { get; set; }

        public string Ticket_Subject { get; set; }

		[ForeignKey(nameof(RequestUser))]
		public Int32? Tkt_RequestUserId { get; set; }
		public ApplicationUser RequestUser { get; set; }


		[ForeignKey(nameof(AssignedUser))]
		public Int32? Tkt_AssignedUserId { get; set; }
		public ApplicationUser AssignedUser { get; set; }
		

        public DateTime? Tkt_DueDate { get; set; }

        [ForeignKey(nameof(Ticket_Status))]
        public Int32? TicketStatusId { get; set; }
        public Ticket_Status Ticket_Status { get; set; }

		[ForeignKey(nameof(Ticket_Priorities))]
		public Int32? TicketPriorityId { get; set; }
		public Ticket_Priorities Ticket_Priorities { get; set; }

		[ForeignKey(nameof(Ticket_Location))]
		public Int32? Tkt_LocationId { get; set; }
		public Location? Ticket_Location { get; set; }


		[ForeignKey(nameof(Ticket_Department))]
		public Int32? Tkt_DepartmentId { get; set; }
		public Department? Ticket_Department { get; set; }

		[ForeignKey(nameof(Ticket_Category))]
		public Int32? Tkt_CategoryId { get; set; }
		public Category? Ticket_Category { get; set; }

		[ForeignKey(nameof(Ticket_SubCategory))]
		public Int32? Tkt_SubCategoryId { get; set; }
		public SubCategory? Ticket_SubCategory { get; set;}

		[ForeignKey(nameof(Tickett_RequestType))]
		public Int32? Tkt_RequestTypeId { get; set; }
		public RequestType? Tickett_RequestType { get; set; }

		[ForeignKey(nameof(Ticket_Mode))]
		public Int32? Ticket_ModeId { get; set; }
		public Ticket_Mode? Ticket_Mode { get; set; }

		[ForeignKey(nameof(Ticket_Level))]
		public Int32? TicketLevelId { get; set; }
		public Ticket_Level? Ticket_Level { get; set; }

        [ForeignKey(nameof(Ticket_Impact))]
        public Int32? Tkt_ImpactId { get; set; }
        public Ticket_Impact? Ticket_Impact { get; set; }

		[ForeignKey(nameof(Tkt_UpdateReason))]
		public Int32? Tkt_UpdateReasonId { get; set; }
		public Tkt_UpdateReason? Tkt_UpdateReason { get; set; }

		public string? StatusUpdateReason { get; set; }


		public IList<Ticket_Attachments> Ticket_Attachments { get; set;}

	}
}
