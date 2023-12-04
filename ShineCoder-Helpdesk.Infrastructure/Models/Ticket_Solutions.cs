using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Infrastructure.Models
{
	public class Ticket_Solutions : BaseEntity
	{
		public string tkt_solution_desc { get;set; }
		public Tickets tickets { get; set; }


	}
}
