using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core.Models
{
	public class TicketAssignedModel
	{
		public int TicketId {  get; set; }
		public int AssignedUserId { get; set; }
	}
}
