using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;

namespace ShineCoder_Helpdesk.Core.Helpers
{
	public class HelpDeskError
	{
		public HelpDeskError(bool isSucceeded = false, string message = "", IEnumerable<IdentityError> error = null, JArray result = null)
		{
			Succeeded = isSucceeded;
			Message = message;
			Errors = error;
			Result = result;

		}

		public JArray Result { get; set; }

		public bool Succeeded { get; set; }
		public string Message { get; set; }
		public IEnumerable<IdentityError> Errors { get; set; }
	}

}
