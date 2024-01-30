using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core.Enums
{
	/// <summary>
	/// ENum values should match with db values
	/// </summary>
	public enum TicketStatusEnum:int
	{
		New=1,
		Open=2,
		Closed=3,
		Resolved=4,
		Assigned=5,
		OverDue=6,
		DueToday=7,
		UnAssigned=8,
		Pending=9

	}

	/// <summary>
	/// /// ENum values should match with db values
	/// </summary>
	public enum TicketPrioritiesEnum
	{
		Low=1,
		High=2,
		Medium=3
	}
}
