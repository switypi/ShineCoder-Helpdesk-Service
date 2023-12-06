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
        public string Tkt_Desc { get; set; }
        public string Tkt_Number { get; set; }

        public string Tkt_Subject { get; set; }

        public Int32 Tkt_RequestUserId { get; set; }

        public string Tkt_RequestUserName { get; set; }
        public Int32? Tkt_AssignedUser { get; set; }
        public string Tkt_AssignedUserName { get; set; }

        public DateTime? Tkt_DueDate { get; set; }

        [ForeignKey(nameof(Tkt_Status))]
        public Int32 TicketStatusId { get; set; }
        public Ticket_Status Tkt_Status { get; set; }

		[ForeignKey(nameof(Tkt_Priorities))]
		public Int32 TicketPriorityId { get; set; }
		public Ticket_Priorities Tkt_Priorities { get; set; }

		[ForeignKey(nameof(Tkt_Location))]
		public Int32? Tkt_LocationId { get; set; }
		public Location? Tkt_Location { get; set; }


		[ForeignKey(nameof(Tkt_Department))]
		public Int32? Tkt_DepartmentId { get; set; }
		public Department? Tkt_Department { get; set; }

		[ForeignKey(nameof(Tkt_Category))]
		public Int32? Tkt_CategoryId { get; set; }
		public Category? Tkt_Category { get; set; }

		[ForeignKey(nameof(Tkt_SubCategory))]
		public Int32? Tkt_SubCategoryId { get; set; }
		public SubCategory? Tkt_SubCategory { get; set;}

		[ForeignKey(nameof(Tkt_RequestType))]
		public Int32? Tkt_RequestTypeId { get; set; }
		public RequestType? Tkt_RequestType { get; set; }

		[ForeignKey(nameof(Ticket_Mode))]
		public Int32 Ticket_ModeId { get; set; }
		public Ticket_Mode Ticket_Mode { get; set; }



        



    }
}
