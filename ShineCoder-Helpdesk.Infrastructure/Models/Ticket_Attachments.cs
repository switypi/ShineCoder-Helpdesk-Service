using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Infrastructure.Models
{
	public class Ticket_Attachments : BaseEntity
	{
		public string Name { get; set; }
		
		public string Extension { get; set; }
		public byte[] ImageBytes { get; set; }
		[ForeignKey(nameof(Tickets))]
		public Int32? TicketId { get; set; }
		public Tickets? Ticket { get; set; }
	}
}
