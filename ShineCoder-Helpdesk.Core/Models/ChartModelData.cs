using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core.Models
{
	public  class ChartModelData
	{
		public string Status { get; set; }
		public int Count { get; set; }

	}

	public class ChartModelDataByMonth
	{
		public string Month { get; set; }
		public int NewCount { get; set; }
		public int ClosedCount { get; set; }
		public int OpenCount { get; set; }

	}
}
