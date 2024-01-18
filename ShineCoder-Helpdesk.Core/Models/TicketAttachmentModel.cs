using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core.Models
{
	public class TicketAttachmentModel
	{
		public Int32 Id { get; set; }
		public string Name { get; set; }
		public string Extension { get; set; }
		public byte[] ImageBytes { get; set; }
	}
}
