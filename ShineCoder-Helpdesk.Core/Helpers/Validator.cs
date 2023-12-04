using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShineCoder_Helpdesk.Core.Helpers
{
	public class CustomValidator : IValidator
	{
		public  IEnumerable<string> Validate(object item)
		{
			var context = new ValidationContext(item, serviceProvider: null, items: null);
			var errorResults = new List<ValidationResult>();
			//Perform validation
			var isValid = Validator.TryValidateObject(item, context, errorResults, true);

			IEnumerable<string> errorMessages = errorResults?.Select(x => x.ToString());

			return errorMessages;
		}
	}
}
