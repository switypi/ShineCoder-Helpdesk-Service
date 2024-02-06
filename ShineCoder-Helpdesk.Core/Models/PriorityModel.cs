﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core.Models
{
	public class PriorityModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool? IsDefault { get; set; }
		public bool Active { get; set; }
	}
}
