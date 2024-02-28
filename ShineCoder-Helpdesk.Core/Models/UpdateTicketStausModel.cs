using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShineCoder_Helpdesk.Core.Enums;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Core.Models
{
	public class UpdateTicketStausModel
	{
		public int TicketId { get; set; }
		public string TicketNumber { get; set; }
		public string	StatusUpdateReason { get; set; }

		public Int32 TktUpdateReasonId { get; set; }
		public TicketStatusEnum TicketStatus { get; set; }
	}
}
